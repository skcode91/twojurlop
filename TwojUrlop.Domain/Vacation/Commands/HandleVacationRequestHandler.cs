using TwojUrlop.DomainModel.Vacation.Commands.HandleVacationRequest;
using TwojUrlop.DataAccess.DatabaseContext;
using TwojUrlop.Common.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Enums = TwojUrlop.Common.Enums;

namespace TwojUrlop.Domain.Vacation.Commands;

public class HandleVacationRequestHandler : IHandleVacationRequestHandler
{
    private readonly TwojUrlopDbContext _context;
    public HandleVacationRequestHandler(TwojUrlopDbContext context)
    {
        _context = context;
    }

    public async Task Handle(HandleVacationRequestRequest request)
    {
        var vacationRequest = await _context.VacationRequest.
            FirstOrDefaultAsync(x => x.Id == request.VacationRequestId);

        if(vacationRequest == null)
        {
            throw new Exception(message: "Vacation request not found");
        }

        var user = await _context.User. 
            FirstOrDefaultAsync(x =>  x.Id == request.UserId);

        if(user == null)
        {
            throw new Exception(message: "User is not found");
        }

        if(user.RoleId != (int)Enums.Role.Manager)
        {
            throw new Exception(message: "User have not permissions");
        }

        if(user.Id == vacationRequest.UserId)
        {
            throw new Exception(message: "User can not accept own request");
        }
        
        vacationRequest.StatusId = (int)request.newRequestStatus;

        if(request.newRequestStatus == Enums.VacationRequestStatus.Accepted)
        {
            var vacation = CreateNewVacation(vacationRequest);
            await _context.Vacation.AddAsync(vacation);
            //TODO: Add adding years and testing
        }

        await _context.SaveChangesAsync();

    }
    private Common.Models.Entities.Vacation CreateNewVacation(VacationRequest vacationRequest)
    {
        var newVacation = new Common.Models.Entities.Vacation(); 
        newVacation.DaysCount = vacationRequest.DaysCount;
        newVacation.StartDate = vacationRequest.StartDate;
        newVacation.EndDate = vacationRequest.EndDate;
        return newVacation;
    }
}