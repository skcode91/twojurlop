using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TwojUrlop.Common.Models.Entities;
using TwojUrlop.DataAccess.DatabaseContext;
using TwojUrlop.DomainModel.Authorization.Commands.SignUp;
using Enums = TwojUrlop.Common.Enums;

namespace TwojUrlop.Domain.Authorization.Commands;
public class SignUpHandler : ISignUpHandler
{
    private readonly UserManager<User> _userManager;
    private readonly TwojUrlopDbContext _context;

    public SignUpHandler(UserManager<User> userManager, TwojUrlopDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task Handle(SignUpRequest request)
    {
        User signUpUserData = request.Adapt<User>();

        signUpUserData.UserName = Guid.NewGuid().ToString();
        signUpUserData.RoleId = (int)Enums.Role.Worker;

        string username = request.Email.ToUpperInvariant();
        var user = await _context.User
            .FirstOrDefaultAsync(x => x.UserName == username);

        if (user != null)
        {
            throw new Exception();
        }

        signUpUserData.CreateDateTime = DateTime.Now.ToUniversalTime();

        IdentityResult createUserResult = await _userManager.CreateAsync(signUpUserData, request.Password);

        if (!createUserResult.Succeeded)
        {
            throw new Exception();
        }

        _context.SaveChanges();
    }
}
