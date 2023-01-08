using TwojUrlop.DomainModel.Vacation.Queries.GetVacations;
using TwojUrlop.DataAccess.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Enums = TwojUrlop.Common.Enums;
using TwojUrlop.DomainModel.Common.Helpers;

namespace TwojUrlop.Domain.Vacation.Queries;

public class GetVacationHandler : IGetVacationsHandler
{
    private readonly TwojUrlopDbContext _context;
    public GetVacationHandler(TwojUrlopDbContext context)
    {
        _context = context;
    }
    public async Task<GetVacationsResponse> Handle(GetVacationsRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        bool isManager = UserHelper.IsManagerOrAdmin(user);

        var query = _context.Vacation
            .Where(x => x.VacationYears.Any(y => y.Year.Value == request.Year))
            .Select(x => new VacationsResponseItem()
            {
                Id = x.Id,
                UserId = x.UserId,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                DaysCount = x.DaysCount
            });

        return new GetVacationsResponse()
        {
            Vacations = isManager ? query : query.Where(x => x.UserId == request.UserId)
        };
    }
}