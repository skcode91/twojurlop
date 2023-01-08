using Mapster;
using Microsoft.EntityFrameworkCore;
using TwojUrlop.DataAccess.DatabaseContext;
using TwojUrlop.DomainModel.Common;
using TwojUrlop.DomainModel.Common.Models;
using TwojUrlop.DomainModel.User.Queries.GetUserVacationYearInfo;
using Entities = TwojUrlop.Common.Models.Entities;
using Enums = TwojUrlop.Common.Enums;

namespace TwojUrlop.Domain.Vacation.Queries
{
    public class GetUserVacationYearInfoHandler : IGetUserVacationYearInfoHandler
    {
        private readonly TwojUrlopDbContext _context;

        public GetUserVacationYearInfoHandler(TwojUrlopDbContext context)
        {
            _context = context;
        }

        public async Task<GetUserVacationYearInfoResponse> Handle(GetUserVacationYearInfoRequest request)
        {
            if (request.CurrentUserId != request.UserId)
            {
                bool IsManagerOrAdmin = await _context.User
                    .AnyAsync(x => x.Id == request.UserId
                        && (x.RoleId == (int)Enums.Role.Manager
                        || x.RoleId == (int)Enums.Role.Admin));

                if (!IsManagerOrAdmin) throw new Exception("Unauthorized");
            }

            var user = await _context.User
                .Include(x => x.Vacations
                    .Where(y => y.VacationYears
                        .Any(z => z.Year.Value == request.Year)))
                .Include(x => x.VacationRequests
                    .Where(y => y.VacationRequestYears
                        .Any(z => z.Year.Value == request.Year)))
                .Include(x => x.UserVacationInfos
                    .Where(y => y.Year.Value == request.Year))
                    .ThenInclude(y => y.VacationSize)
                .FirstOrDefaultAsync(x => x.Id == request.UserId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return GetUserVacationYearInfo(user, request.Year);
        }
        private GetUserVacationYearInfoResponse GetUserVacationYearInfo(Entities.User user, int year)
        {
            var userDto = user.Adapt<UserDto>();
            var vacationsDto = user.Vacations.Adapt<IEnumerable<VacationDto>>();
            var requestsDto = user.VacationRequests.Adapt<IEnumerable<VacationRequestDto>>();
            int daysTotal = user.UserVacationInfos != null && user.UserVacationInfos.FirstOrDefault() != null ? user.UserVacationInfos.FirstOrDefault()!.VacationSize.Value : 0;
            int daysLeft = user.UserVacationInfos != null && user.UserVacationInfos.FirstOrDefault() != null ? user.UserVacationInfos.FirstOrDefault()!.DaysLeft : 0;

            return new GetUserVacationYearInfoResponse()
            {
                User = userDto,
                Vacations = vacationsDto,
                Requests = requestsDto,
                DaysTotal = daysTotal,
                DaysLeft = daysLeft,
                Year = year
            };
        }

    }
}