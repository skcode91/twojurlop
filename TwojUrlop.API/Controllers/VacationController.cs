using Microsoft.AspNetCore.Mvc;
using TwojUrlop.DomainModel.Vacation.Queries.GetVacationRequests;

namespace TwojUrlop.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VacationController : Controller
{
    private readonly IGetVacationRequestsHandler _getVacationRequestsHandler;

    public VacationController(IGetVacationRequestsHandler getVacationRequestsHandler)
    {
        _getVacationRequestsHandler = getVacationRequestsHandler;
    }

    [HttpGet("vacation-request")]
    public async Task<GetVacationRequestsResponse> GetVacationRequests([FromQuery] GetVacationRequestsRequest request)
    {
        return await _getVacationRequestsHandler.Handle(request);
    }
}
