using Microsoft.AspNetCore.Mvc;
using TwojUrlop.DomainModel.Vacation.Commands.SendVacationRequest;
using TwojUrlop.Common.Models.Entities;
using System.Net;

namespace TwojUrlop.Controllers;

[Route("api/[contorller]")]
[ApiController]
public class VacationController :Controller
{
    private readonly ISendVacationRequestHandler _vacationRequestHandler;

    public VacationController(ISendVacationRequestHandler vacationRequestHandler)
    {
        _vacationRequestHandler = vacationRequestHandler;
    }

    [HttpPost("vacation-request")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task RequestVacation([FromBody] SendVacationRequestRequest request)
    {
         await _vacationRequestHandler.Handle(request);
    } 
}