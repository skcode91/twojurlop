using Microsoft.EntityFrameworkCore;
using TwojUrlop.DataAccess.DatabaseContext;
using TwojUrlop.DomainModel.Vacation.Commands.DeleteVacationRequest;
using Enums = TwojUrlop.Common.Enums;

namespace TwojUrlop.Domain.Vacation.Commands;
public class DeleteVacationRequestHandler : IDeleteVacationRequestHandler
{
    private readonly TwojUrlopDbContext _context;

    public DeleteVacationRequestHandler(TwojUrlopDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteVacationRequestRequest request)
    {
        var vacationRequest = await _context.VacationRequest
            .FirstOrDefaultAsync(x => x.Id == request.VacationRequestId);

        if (vacationRequest == null)
        {
            throw new Exception(message: "vacation request not found");
        }

        if (vacationRequest.UserId != request.UserId)
        {
            throw new Exception(message: "Unauthorized");
        }

        vacationRequest.StatusId = (int)Enums.VacationRequestStatus.Deleted;

        await _context.SaveChangesAsync();
    }
}