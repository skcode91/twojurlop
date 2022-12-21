using TwojUrlop.DomainModel.Vacation.Interfaces;
using TwojUrlop.DataAccess.DatabaseContext;
using TwojUrlop.Common.Models.Entities;

namespace TwojUrlop.Domain.Vacation.Commands;

public class VacationRequestHandler : IVacationRequestHandler
{
    private readonly TwojUrlopDbContext _context;
    public VacationRequestHandler(TwojUrlopDbContext context)
    {
        _context = context;
    }
    
    public async Task<string> Handle(VacationRequest request)
    {
        try
        {
            if(request == null)
            {
                throw new ArgumentNullException("Parameter is null");
            }
            await Task.Run(() => _context.Add(request));
            return "Request is sended to supervisor";
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}