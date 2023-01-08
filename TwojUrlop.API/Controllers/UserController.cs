using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TwojUrlop.DomainModel.User.Queries.GetUserBaseInfo;

namespace TwojUrlop.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : Controller
{
    private readonly IGetUserBaseInfoHandler _getUserBaseInfoHandler;
    public UserController(IGetUserBaseInfoHandler getUserBaseInfoHandler)
    {
        _getUserBaseInfoHandler = getUserBaseInfoHandler;
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

}
