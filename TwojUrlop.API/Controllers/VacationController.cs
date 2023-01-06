using Microsoft.AspNetCore.Mvc;
using TwojUrlop.DomainModel.Vacation.Commands.DeleteVacationRequest;
using TwojUrlop.DomainModel.Vacation.Queries.GetVacationRequests;
using TwojUrlop.DomainModel.Vacation.Commands.SendVacationRequest;
using TwojUrlop.DomainModel.Vacation.Commands.HandleVacationRequest;
using TwojUrlop.DomainModel.Vacation.Queries.GetVacations;
using System.Net;

namespace TwojUrlop.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VacationController : Controller
{
    private readonly ISendVacationRequestHandler _vacationRequestHandler;
    private readonly IGetVacationRequestsHandler _getVacationRequestsHandler;
    private readonly IDeleteVacationRequestHandler _deleteVacationRequestHandler;
    private readonly IHandleVacationRequestHandler _handlerVacationRequestHandler;
    private readonly IGetVacationsHandler _getVacationsHandler;
    public VacationController(IGetVacationRequestsHandler getVacationRequestsHandler, IDeleteVacationRequestHandler deleteVacationRequestHandler, 
        ISendVacationRequestHandler vacationRequestHandler, IHandleVacationRequestHandler handleVacationRequestHandler, IGetVacationsHandler getVacationsHandler)
    {
        _getVacationRequestsHandler = getVacationRequestsHandler;
        _deleteVacationRequestHandler = deleteVacationRequestHandler;
        _vacationRequestHandler = vacationRequestHandler;
        _handlerVacationRequestHandler = handleVacationRequestHandler;
        _getVacationsHandler = getVacationsHandler;
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
        await _handlerVacationRequestHandler.Handle(request);
    }
}
