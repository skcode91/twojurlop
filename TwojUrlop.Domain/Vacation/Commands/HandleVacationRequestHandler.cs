using TwojUrlop.DomainModel.Vacation.Commands.HandleVacationRequest;
using TwojUrlop.DataAccess.DatabaseContext;
using TwojUrlop.Common.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Enums = TwojUrlop.Common.Enums;
using Entities = TwojUrlop.Common.Models.Entities;
using TwojUrlop.DomainModel.Common.Helpers;

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
        var vacationRequest = await CheckIfRequestIsValid(request);

        if (request.newRequestStatus == Enums.VacationRequestStatus.Accepted)
        {
            await CreateVacation(vacationRequest);
        }

        vacationRequest.StatusId = (int)request.newRequestStatus;

        await _context.SaveChangesAsync();
    }
    private async Task CreateVacation(VacationRequest vacationRequest)
    {
        var newVacationId = await CreateNewVacationElement(vacationRequest);
        var year = await GetYear(vacationRequest.StartDate.Year);
        await CreateNewVacationYearElement(newVacationId, year);
        await SubstactionVacationDays(vacationRequest.DaysCount, year, vacationRequest.User);
    }
    private async Task<int> CreateNewVacationElement(VacationRequest vacationRequest)
    {
        var newVacation = new Common.Models.Entities.Vacation()
        {
            DaysCount = vacationRequest.DaysCount,
            StartDate = vacationRequest.StartDate,
            EndDate = vacationRequest.EndDate,
            UserId = vacationRequest.UserId
        };
        await _context.Vacation.AddAsync(newVacation);
        await _context.SaveChangesAsync();
        return newVacation.Id;
    }
    private async Task CreateNewVacationYearElement(int vacationId, Year year)
    {
        var newVacationYear = new VacationYear()
        {
            VacationId = vacationId,
            YearId = year.Id,
        };
        await _context.AddAsync(newVacationYear);
        await _context.SaveChangesAsync();
    }
    private async Task<Year> GetYear(int yearValue)
    {
        var year = await _context.Year.AsTracking().FirstOrDefaultAsync(x => x.Value == yearValue);
        if (year == null)
        {
            throw new Exception(message: "Year not exist");
        }
        return year;
    }
    private async Task<VacationRequest> CheckIfRequestIsValid(HandleVacationRequestRequest request)
    {
        var vacationRequest = await _context.VacationRequest
            .AsTracking()
            .Include(x => x.User)
                .ThenInclude(y => y.UserVacationInfos)
            .FirstOrDefaultAsync(x => x.Id == request.VacationRequestId);

        if (vacationRequest == null)
        {
            throw new Exception(message: "Vacation request not found");
        }

        var user = await _context.User.
            FirstOrDefaultAsync(x => x.Id == request.UserId);

        if (user == null)
        {
            throw new Exception(message: "User is not found");
        }
        if (!UserHelper.IsManagerOrAdmin(user))
        {
            throw new Exception(message: "User have not permissions");
        }
        if (user.Id == vacationRequest.UserId)
        {
            throw new Exception(message: "User can not accept own request");
        }

        return vacationRequest;
    }
    private async Task SubstactionVacationDays(int CountDays, Year year, Entities.User user)
    {
        var userVacationInfo = await GetUserVacationInfo(year, user);
        if (userVacationInfo.DaysLeft - CountDays < 0)
        {
            throw new Exception(message: "Count days is greater than DaysLeft");
        }
        userVacationInfo.DaysLeft -= CountDays;
        await _context.SaveChangesAsync();
    }
    private async Task<UserVacationInfo> GetUserVacationInfo(Year year, Entities.User user)
    {
        var userVacationInfo = user.UserVacationInfos.FirstOrDefault(x => x.YearId == year.Id);
        if (userVacationInfo == null)
        {
            userVacationInfo = await CreateNewUserVacationInfoElement(year, user);
        }
        return userVacationInfo;
    }
    private async Task<UserVacationInfo> CreateNewUserVacationInfoElement(Year year, Entities.User user)
    {
        var vacationSize = await GetVacationSize(user, year);
        UserVacationInfo newUserVacationInfo = new UserVacationInfo()
        {
            UserId = user.Id,
            YearId = year.Id,
            VacationSizeId = vacationSize.Id,
            DaysLeft = vacationSize.Value
        };

        await _context.UserVacationInfo.AddAsync(newUserVacationInfo);
        await _context.SaveChangesAsync();
        return newUserVacationInfo;
    }

    private async Task<VacationSize> GetVacationSize(Entities.User user, Year year)
    {
        bool isLongVacationSize = (year.Value - user.HiringDate.Year + user.NumberOfYearsWorkedOnHiringDate) >= 10;
        var vacationSize = await _context.VacationSize.FirstOrDefaultAsync(x => x.Value == (isLongVacationSize ? 26 : 20));

        if (vacationSize == null)
        {
            throw new Exception(message: "Vacation Size is null");
        }

        return vacationSize;
    }
}