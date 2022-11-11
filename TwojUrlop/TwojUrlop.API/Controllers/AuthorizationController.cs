using System.Net;
using Microsoft.AspNetCore.Mvc;
using TwojUrlop.DomainModel.Authorization.Commands.SignUp;

namespace TwojUrlop.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthorizationController : Controller
{
    private readonly ISignUpHandler _signUpHandler;

    public AuthorizationController(ISignUpHandler signUpHandler)
    {
        _signUpHandler = signUpHandler;
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