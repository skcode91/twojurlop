using Microsoft.AspNetCore.Mvc;
using TwojUrlop.DomainModel.Vacation.Commands.DeleteVacationRequest;
using TwojUrlop.DomainModel.Vacation.Queries.GetVacationRequests;
using TwojUrlop.DomainModel.Vacation.Commands.SendVacationRequest;
using TwojUrlop.DomainModel.Vacation.Commands.HandleVacationRequest;
using TwojUrlop.DomainModel.Vacation.Queries.GetVacations;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using TwojUrlop.DomainModel.User.Queries.GetUserVacationYearInfo;

namespace TwojUrlop.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class VacationController : Controller
{
    private readonly ISendVacationRequestHandler _vacationRequestHandler;
    private readonly IGetVacationRequestsHandler _getVacationRequestsHandler;
    private readonly IDeleteVacationRequestHandler _deleteVacationRequestHandler;
    private readonly IHandleVacationRequestHandler _handleVacationRequestHandler;
    private readonly IGetVacationsHandler _getVacationsHandler;
    private readonly IGetUserVacationYearInfoHandler _getUserVacationYearInfoHandler;

    public VacationController(IGetVacationRequestsHandler getVacationRequestsHandler, IDeleteVacationRequestHandler deleteVacationRequestHandler,
        ISendVacationRequestHandler vacationRequestHandler, IHandleVacationRequestHandler handleVacationRequestHandler, IGetVacationsHandler getVacationsHandler,
        IGetUserVacationYearInfoHandler getUserVacationYearInfoHandler)
    {
        _getVacationRequestsHandler = getVacationRequestsHandler;
        _deleteVacationRequestHandler = deleteVacationRequestHandler;
        _vacationRequestHandler = vacationRequestHandler;
        _handleVacationRequestHandler = handleVacationRequestHandler;
        _getVacationsHandler = getVacationsHandler;
        _getUserVacationYearInfoHandler = getUserVacationYearInfoHandler;
    }

    [HttpGet("vacation-request")]
    public async Task<GetVacationRequestsResponse> GetVacationRequests([FromQuery] GetVacationRequestsRequest request)
    {
        return await _getVacationRequestsHandler.Handle(request);
    }

    [HttpGet("vacation")]
    public async Task<GetVacationsResponse> GetVacations([FromQuery] GetVacationsRequest request)
    {
        return await _getVacationsHandler.Handle(request);
    }

    [HttpDelete("vacation-request")]
    public async Task DeleteVacationRequest([FromBody] DeleteVacationRequestRequest request)
    {
        await _deleteVacationRequestHandler.Handle(request);
    }

    [HttpPost("vacation-request-send")]
    public async Task RequestVacation([FromBody] SendVacationRequestRequest request)
    {
        await _vacationRequestHandler.Handle(request);
    }

    [HttpPost("vacation-request-handle")]
    public async Task HandleRequestVacation([FromBody] HandleVacationRequestRequest request)
    {
        await _handleVacationRequestHandler.Handle(request);
    }

    [HttpGet("user-vacation-year-info")]
    public async Task<GetUserVacationYearInfoResponse> GetUserVacationYearInfo([FromQuery]GetUserVacationYearInfoRequest request)
    {
        return await _getUserVacationYearInfoHandler.Handle(request);
    }
}
