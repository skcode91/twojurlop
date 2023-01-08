using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TwojUrlop.DomainModel.User.Queries.GetUserBaseInfo;
using TwojUrlop.DomainModel.User.Commands.AddUser;
using TwojUrlop.DomainModel.User.Commands.ChangeUserRole;
using TwojUrlop.DomainModel.User.Commands.ChangeUserStatus;
using TwojUrlop.DomainModel.User.Queries.GetUsers;
using TwojUrlop.DomainModel.Common;

namespace TwojUrlop.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : Controller
{
    private readonly IGetUserBaseInfoHandler _getUserBaseInfoHandler;
    private readonly IAddUserHandler _addUserHandler;
    private readonly IChangeUserRoleHandler _changeUserRoleHandler;
    private readonly IChangeUserStatusHandler _changeUserStatusHandler;
    private readonly IGetUsersHandler _getUsersHandler;
    public UserController(IGetUserBaseInfoHandler getUserBaseInfoHandler, IAddUserHandler addUserHandler,
    IChangeUserRoleHandler changeUserRoleHandler, IChangeUserStatusHandler changeUserStatusHandler,
    IGetUsersHandler getUsersHandler)
    {
        _getUserBaseInfoHandler = getUserBaseInfoHandler;
        _addUserHandler = addUserHandler;
        _changeUserRoleHandler = changeUserRoleHandler;
        _changeUserStatusHandler = changeUserStatusHandler;
        _getUsersHandler = getUsersHandler;
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

    [HttpPost("change-user-role")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task ChangeUserRole([FromBody] ChangeUserRoleRequest request)
    {
        await _changeUserRoleHandler.Handle(request);
    }

    [HttpPost("change-user-status")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task ChangeUserStatus([FromBody] ChangeUserStatusRequest request)
    {
        await _changeUserStatusHandler.Handle(request);
    }

    [HttpGet("users")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IEnumerable<UserDto>> GetUsers([FromQuery] GetUsersRequest request)
    {
        return await _getUsersHandler.Handle(request);
    }
}
