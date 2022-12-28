using TwojUrlop.DomainModel.Vacation.Commands.SendVacationRequest;
using TwojUrlop.DataAccess.DatabaseContext;
using TwojUrlop.Common.Models.Entities;
using Mapster;
using Enums = TwojUrlop.Common.Enums;

namespace TwojUrlop.Domain.Vacation.Commands;

public class SendVacationRequestHandler : ISendVacationRequestHandler
{
    private readonly TwojUrlopDbContext _context;
    private int _vacationRequestId {get; set;} 
    private int _yearStartId {get; set;}
    private int _yearEndId {get; set;}
    public SendVacationRequestHandler(TwojUrlopDbContext context)
    {
        _context = context;
    }
    
    public async Task Handle(SendVacationRequestRequest request)
    {   
        await CreateVacationRequest(request);
        await GetOrCreateYear(request.StartDate.Year, request.EndDate.Year);
        await CreateVacationRequestYear(_yearStartId, _vacationRequestId);
        if(_yearStartId != _yearEndId)
        {
            await CreateVacationRequestYear(_yearEndId, _vacationRequestId);
        }
    }

    private async Task CreateVacationRequest(SendVacationRequestRequest request)
    {
        if(request == null)
        {
            throw new ArgumentNullException("Parameter is null");
        }
        VacationRequest newVacationRequest = request.Adapt<VacationRequest>();
        newVacationRequest.StatusId = (int)Enums.VacationRequestStatus.Active;
        await  _context.VacationRequest.AddAsync(newVacationRequest);
        await _context.SaveChangesAsync();

        _vacationRequestId = newVacationRequest.Id;
    }
    private async Task CreateVacationRequestYear(int yearId, int vacationRequestId)
    {
        VacationRequestYear vacationRequestYear = new VacationRequestYear();
        vacationRequestYear.VacationRequestId = vacationRequestId;
        vacationRequestYear.YearId = yearId; 
        await _context.AddAsync(vacationRequestYear);
        await _context.SaveChangesAsync();
    }
    private async Task GetOrCreateYear(int startDate, int endDate)
    {
        var yearStart = _context.Year.FirstOrDefault(x => x.Value == startDate);
        if(yearStart == null)
        {
            yearStart = await CreateYear(startDate);
        }
        _yearStartId = yearStart.Id;
        _yearEndId = yearStart.Id;

        if(startDate != endDate)
        {
            var yearEnd = _context.Year.FirstOrDefault(x => x.Value == endDate);
            if(yearEnd == null)
            {
                yearEnd = await CreateYear(endDate);
            }
            _yearEndId = yearEnd.Id;
        }
        
    }   
    private async Task<Year> CreateYear(int yearValue)
    {
        var year = new Year();
        year.Value = yearValue;
        await _context.Year.AddAsync(year);
        await _context.SaveChangesAsync();
        return year;
    }
}