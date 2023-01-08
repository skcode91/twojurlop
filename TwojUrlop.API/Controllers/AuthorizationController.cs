using System.Net;
using Microsoft.AspNetCore.Mvc;
using TwojUrlop.DomainModel.Authorization.Commands.SignIn;
using TwojUrlop.DomainModel.Authorization.Commands.SignUp;
using TwojUrlop.DomainModel.Authorization.Queries;

namespace TwojUrlop.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthorizationController : Controller
{
    private readonly ISignInHandler _signInHandler;
    private readonly ISignUpHandler _signUpHandler;
    private readonly IGetUsersFullnameHandler _getUsersFullnameHandler;

    public AuthorizationController(ISignInHandler signInHandler, ISignUpHandler signUpHandler, IGetUsersFullnameHandler getUsersFullnameHandler)
    {
        _signInHandler = signInHandler;
        _signUpHandler = signUpHandler;
        _getUsersFullnameHandler = getUsersFullnameHandler;
    }

    /// <summary>
    /// Login user
    /// </summary>
    [HttpPost("sign-in")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<SignInResponse> SignIn([FromBody] SignInRequest request)
    {
        return await _signInHandler.Handle(request);
    }

    /// <summary>
    /// Register new user
    /// </summary>
    [HttpPost("sign-up")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task SignUp([FromBody] SignUpRequest request)
    {
        await _signUpHandler.Handle(request);
    }
}