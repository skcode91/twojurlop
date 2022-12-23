using TwojUrlop.DomainModel.Vacation.Commands.SendVacationRequest;
using TwojUrlop.DataAccess.DatabaseContext;
using TwojUrlop.Common.Models.Entities;
using Mapster;

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
        try
        {
            if(request == null)
            {
                throw new ArgumentNullException("Parameter is null");
            }
            VacationRequest newVacationRequest = request.Adapt<VacationRequest>();
            await  _context.AddAsync(newVacationRequest);
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}