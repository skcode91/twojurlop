using Microsoft.EntityFrameworkCore;
using TwojUrlop.DataAccess.DatabaseContext;
using TwojUrlop.DomainModel.Common.Helpers;
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

        bool isManager = UserHelper.IsManagerOrAdmin(user);

        var query = _context.VacationRequest
            .Where(x => x.StatusId != (int)Enums.VacationRequestStatus.Deleted)
            .Where(x => x.VacationRequestYears.Any(y => y.Year.Value == request.Year))
            .Include(x => x.User)
            .Select(x => new VacationRequestResponseItem()
            {
                Id = x.Id,
                UserId = x.UserId,
                UserFullName = x.User.FirstName + " " + x.User.LastName,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                DaysCount = x.DaysCount,
                StatusId = x.StatusId,
            });

        return new GetVacationRequestsResponse()
        {
            VacationRequests = isManager ? query : query.Where(x => x.UserId == request.UserId)
        };
    }
}