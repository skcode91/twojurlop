using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TwojUrlop.DomainModel.User.Queries.GetUserBaseInfo;
using TwojUrlop.DomainModel.User.Commands.AddUser;
using TwojUrlop.DomainModel.User.Commands.SetUserAsMenager;

namespace TwojUrlop.Controllers;
[Route("api/[controller]")]
[ApiController]
//[Authorize]
[AllowAnonymous]
public class UserController : Controller
{
    private readonly IGetUserBaseInfoHandler _getUserBaseInfoHandler;
    private readonly IAddUserHandler _addUserHandler;
    private readonly ISetUserAsMenagerHandler _setUserAsMenager;
    public UserController(IGetUserBaseInfoHandler getUserBaseInfoHandler, IAddUserHandler addUserHandler,
        ISetUserAsMenagerHandler setUserAsMenager)
    {
        _getUserBaseInfoHandler = getUserBaseInfoHandler;
        _addUserHandler = addUserHandler;
        _setUserAsMenager = setUserAsMenager;
    }
    /// <summary>
    /// Return test string
    /// </summary>
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
        //TODO: REWORK request.Pesel
        await _addUserHandler.Handle(request);
    }

    [HttpPost("User-Set-Menager")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task SetUserAsMenager([FromBody] SetUserAsMenagerRequest request)
    {
        await _setUserAsMenager.Handle(request);
    }

}
