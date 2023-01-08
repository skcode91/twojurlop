using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TwojUrlop.DomainModel.User.Queries.GetUserBaseInfo;
using TwojUrlop.DomainModel.User.Commands.AddUser;

namespace TwojUrlop.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : Controller
{
    private readonly IGetUserBaseInfoHandler _getUserBaseInfoHandler;
    private readonly IAddUserHandler _addUserHandler;
    public UserController(IGetUserBaseInfoHandler getUserBaseInfoHandler, IAddUserHandler addUserHandler)
    {
        _getUserBaseInfoHandler = getUserBaseInfoHandler;
        _addUserHandler = addUserHandler;
    }

    [HttpGet("user-base-info")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<GetUserBaseInfoResponse> GetUserBaseInfo([FromQuery] GetUserBaseInfoRequest request)
    {
        return await _getUserBaseInfoHandler.Handle(request);
    }

    [HttpPost("User-Add")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task AddUser([FromBody] AddUserRequest request)
    {
        await _addUserHandler.Handle(request);
    }

}
