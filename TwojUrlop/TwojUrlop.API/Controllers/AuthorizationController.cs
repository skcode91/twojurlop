using System.Net;
using Microsoft.AspNetCore.Mvc;
using TwojUrlop.DomainModel.Authorization.Commands.SignUp;
using TwojUrlop.DomainModel.Authorization.Queries;

namespace TwojUrlop.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthorizationController : Controller
{
    private readonly ISignUpHandler _signUpHandler;
    private readonly IGetUsersFullnameHandler _getUsersFullnameHandler;


    public AuthorizationController(ISignUpHandler signUpHandler, IGetUsersFullnameHandler getUsersFullnameHandler)
    {
        _signUpHandler = signUpHandler;
        _getUsersFullnameHandler = getUsersFullnameHandler;
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

    /// <summary>
    /// Get users first names with last names
    /// </summary>
    [HttpGet("get-users-fullname")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<List<string>> GetUsersFullname()
    {
        return await _getUsersFullnameHandler.Handle();
    }
}