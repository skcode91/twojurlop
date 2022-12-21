using Microsoft.AspNetCore.Mvc;
using TwojUrlop.DomainModel.Vacation.Interfaces;
using TwojUrlop.Common.Models.Entities;
using System.Net;

namespace TwojUrlop.Controllers;

[Route("api/[contorller]")]
[ApiController]
public class VacationController :Controller
{
    private readonly IVacationRequestHandler _vacationRequestHandler;

    public VacationController(IVacationRequestHandler vacationRequestHandler)
    {
        _vacationRequestHandler = vacationRequestHandler;
    }

    [HttpPost("vacation-request")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<string> RequestVacation([FromBody] VacationRequest request)
    {
        return await _vacationRequestHandler.Handle(request);
    } 
}