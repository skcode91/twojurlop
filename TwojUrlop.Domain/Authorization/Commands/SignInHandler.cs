using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Entities = TwojUrlop.Common.Models.Entities;
using TwojUrlop.Common.Models.Settings;
using TwojUrlop.DataAccess.DatabaseContext;
using TwojUrlop.DomainModel.Authorization.Commands.SignIn;

namespace TwojUrlop.Domain.Authorization.Commands;
public class SignInHandler : ISignInHandler
{
    private readonly TwojUrlopDbContext _context;
    private readonly UserManager<Entities.User> _userManager;
    private readonly SignInManager<Entities.User> _signInManager;
    private readonly JwtOptions _jwtOptions;

    public SignInHandler(TwojUrlopDbContext context, UserManager<Entities.User> userManager, SignInManager<Entities.User> signInManager,
    IOptions<JwtOptions> jwtOptions)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtOptions = jwtOptions.Value;
    }

    public async Task<SignInResponse> Handle(SignInRequest request)
    {
        var user = await _context.User
            .FirstOrDefaultAsync(x => x.NormalizedEmail == request.Login.ToUpperInvariant());

        if (user == null)
        {
            throw new Exception();
        }

        if (!await _userManager.CheckPasswordAsync(user, request.Password))
        {
            throw new Exception();
        }

        var userRoles = await _userManager.GetRolesAsync(user!);

        var claims = new List<Claim>
            {
                new Claim (ClaimTypes.Name, user.UserName),
                new Claim (JwtRegisteredClaimNames.Nbf,
                new DateTimeOffset (DateTime.Now).ToUnixTimeSeconds().ToString ()),
                new Claim (JwtRegisteredClaimNames.Exp,
                ((long)((DateTime.Now.AddMinutes(_jwtOptions.TokenExpirationMinutes) - new DateTime (1970, 1, 1, 0, 0, 0))
                    .TotalSeconds))
                    .ToString())
            };

        claims.AddRange(userRoles.Select(ur => new Claim(ClaimTypes.Role, ur)));

        try
        {
            var token = new JwtSecurityToken(
                 new JwtHeader(new SigningCredentials(

            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)), SecurityAlgorithms.HmacSha256)),

            new JwtPayload(claims));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);

            return new SignInResponse
            {
                AccessToken = encodedJwt,
                ExpiresIn = token.ValidTo,
                RoleId = user.RoleId,
                UserId = user.Id
            };
        }

        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }
}
