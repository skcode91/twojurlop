using Microsoft.AspNetCore.Mvc;
using TwojUrlop.DomainModel.Vacation.Commands.DeleteVacationRequest;
using TwojUrlop.DomainModel.Vacation.Queries.GetVacationRequests;

namespace TwojUrlop.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VacationController : Controller
{
    private readonly IGetVacationRequestsHandler _getVacationRequestsHandler;
    private readonly IDeleteVacationRequestHandler _deleteVacationRequestHandler;
    public VacationController(IGetVacationRequestsHandler getVacationRequestsHandler, IDeleteVacationRequestHandler deleteVacationRequestHandler)
    {
        _getVacationRequestsHandler = getVacationRequestsHandler;
        _deleteVacationRequestHandler = deleteVacationRequestHandler;
    }

    [HttpGet("vacation-request")]
    public async Task<GetVacationRequestsResponse> GetVacationRequests([FromQuery] GetVacationRequestsRequest request)
    {
        return await _getVacationRequestsHandler.Handle(request);
    }

    [HttpDelete("vacation-request")]
    public async Task DeleteVacationRequest([FromBody] DeleteVacationRequestRequest request)
    {
        await _deleteVacationRequestHandler.Handle(request);
    }
}
