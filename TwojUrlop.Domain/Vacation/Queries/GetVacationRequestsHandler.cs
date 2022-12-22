using Microsoft.EntityFrameworkCore;
using TwojUrlop.DataAccess.DatabaseContext;
using TwojUrlop.DomainModel.Vacation.Queries.GetVacationRequests;
using Enums = TwojUrlop.Common.Enums;

namespace TwojUrlop.Domain.Vacation.Queries;
public class GetVacationRequestsHandler : IGetVacationRequestsHandler
{
    private readonly TwojUrlopDbContext _context;

    public GetVacationRequestsHandler(TwojUrlopDbContext context)
    {
        _context = context;
    }

    public async Task<GetVacationRequestsResponse> Handle(GetVacationRequestsRequest request)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.Id == request.UserId);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        bool isManager = user.RoleId == (int)Enums.Role.Manager || user.RoleId == (int)Enums.Role.Admin;

        var query = _context.VacationRequest
            .Where(x => x.StatusId == (int)Enums.VacationRequestStatus.Active)
            .Where(x => x.VacationRequestYears.Any(y => y.Year.Value == request.Year))
            .Select(x => new VacationRequestResponseItem()
            {
                Id = x.Id,
                UserId = x.UserId,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                DaysCount = x.DaysCount
            });

        return new GetVacationRequestsResponse()
        {
            VacationRequests = isManager ? query : query.Where(x => x.UserId == request.UserId)
        };
    }
}