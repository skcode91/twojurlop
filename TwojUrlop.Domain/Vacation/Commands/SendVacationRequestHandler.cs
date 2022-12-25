using TwojUrlop.DomainModel.Vacation.Commands.SendVacationRequest;
using TwojUrlop.DataAccess.DatabaseContext;
using TwojUrlop.Common.Models.Entities;
using Mapster;
using Enums = TwojUrlop.Common.Enums;

namespace TwojUrlop.Domain.Vacation.Commands;

public class SendVacationRequestHandler : ISendVacationRequestHandler
{
    private readonly TwojUrlopDbContext _context;
    public SendVacationRequestHandler(TwojUrlopDbContext context)
    {
        _context = context;
    }
    
    public async Task Handle(SendVacationRequestRequest request)
    {   
        if(request == null)
        {
            throw new ArgumentNullException("Parameter is null");
        }
        VacationRequest newVacationRequest = request.Adapt<VacationRequest>();
        newVacationRequest.StatusId = (int)Enums.VacationRequestStatus.Active;

        await  _context.AddAsync(newVacationRequest);
        await _context.SaveChangesAsync();
    }
}