using TwojUrlop.DomainModel.Vacation.Commands.HandleVacationRequest;
using TwojUrlop.DataAccess.DatabaseContext;
using TwojUrlop.Common.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Enums = TwojUrlop.Common.Enums;

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

        vacationRequest.StatusId = (int)request.newRequestStatus;
        await _context.SaveChangesAsync();

        switch(request.newRequestStatus)
        {
            case Enums.VacationRequestStatus.Accepted:
                await CreateVacation(vacationRequest);
                break;

            case Enums.VacationRequestStatus.Declined:
                break;
        }            
    }
    private async Task CreateVacation(VacationRequest vacationRequest)
    {
        var newVacationId = await CreateNewVacationElement(vacationRequest);
        var startYearId = await GetYearId(vacationRequest.StartDate.Year);
        await CreateNewVacationYearElement(newVacationId, startYearId);
        await SubstactionVacationDays(vacationRequest.DaysCount, startYearId, vacationRequest.UserId);
    }
    private async Task<int> CreateNewVacationElement(VacationRequest vacationRequest)
    {
        var newVacation = new Common.Models.Entities.Vacation(); 
        newVacation.DaysCount = vacationRequest.DaysCount;
        newVacation.StartDate = vacationRequest.StartDate;
        newVacation.EndDate = vacationRequest.EndDate;
        await _context.Vacation.AddAsync(newVacation);
        await _context.SaveChangesAsync();
        return newVacation.Id;
    }
    private async Task CreateNewVacationYearElement(int vacationId, int yearId)
    {
        var newVacationYear = new VacationYear();
        newVacationYear.VacationId = vacationId;
        newVacationYear.YearId = yearId;
        await _context.AddAsync(newVacationYear);
        await _context.SaveChangesAsync();
    }
    private async Task<int> GetYearId(int yearValue)
    {
        var year = await _context.Year.FirstOrDefaultAsync(x => x.Value == yearValue);
        if(year == null)
        {
            throw new Exception(message: "Year not exist");
        }
        return year.Id;
    }
    private async Task<VacationRequest> CheckIfRequestIsValid(HandleVacationRequestRequest request)
    {
        var vacationRequest = await _context.VacationRequest.
            FirstOrDefaultAsync(x => x.Id == request.VacationRequestId);
        if(vacationRequest == null)
        {
            throw new Exception(message: "Vacation request not found");
        }

        var user = await _context.User. 
            FirstOrDefaultAsync(x =>  x.Id == request.UserId);
        if(user == null)
        {
            throw new Exception(message: "User is not found");
        }
        if(user.RoleId != (int)Enums.Role.Manager)
        {
            throw new Exception(message: "User have not permissions");
        }
        if(user.Id == vacationRequest.UserId)
        {
            throw new Exception(message: "User can not accept own request");
        }

        return vacationRequest;
    }
    private async Task SubstactionVacationDays(int CountDays, int yearId, int userId)
    {
        var userVacationInfo = await GetUserVacationInfo(yearId, userId);
        if(userVacationInfo.DaysLeft - CountDays < 0)
        {
            throw new Exception(message: "Count days is greater than DaysLeft");
        }
        userVacationInfo.DaysLeft -= CountDays;
        await _context.SaveChangesAsync();
    }
    private async Task<UserVacationInfo> GetUserVacationInfo(int yearId, int userId)
    {
        var userVacationInfo = await _context.UserVacationInfo.FirstOrDefaultAsync(x => x.YearId == yearId && x.UserId == userId);
        if(userVacationInfo == null)
        {
            userVacationInfo = await CreateNewUserVacationInfoElement(yearId, userId);
        }
        return userVacationInfo;
    }
    private async Task<UserVacationInfo> CreateNewUserVacationInfoElement(int yearId, int userId)
    {
        UserVacationInfo newUserVacationInfo = new UserVacationInfo();
        newUserVacationInfo.UserId = userId;
        newUserVacationInfo.YearId = yearId;

        var vacationSize = await GetVacationSize(userId, yearId);
        newUserVacationInfo.VacationSizeId = vacationSize.Id;
        newUserVacationInfo.DaysLeft = vacationSize.Value;
        
        await _context.UserVacationInfo.AddAsync(newUserVacationInfo);
        await _context.SaveChangesAsync();
        return newUserVacationInfo;
    }

    private async Task<VacationSize> GetVacationSize(int userId, int yearId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        var year = await _context.Year.FirstOrDefaultAsync(x => x.Id == yearId);
        
        if(user == null)
        {
            throw new Exception(message:"user is not found");
        }
        if(year == null)
        {
            throw new Exception(message: "year is not found");
        }

        bool isLongVacationSize = (year.Value - user.HiringDate.Year + user.NumberOfYearsWorkedOnHiringDate) >= 10;
        var vacationSize = await _context.VacationSize.FirstOrDefaultAsync(x => x.Value == (isLongVacationSize ? 26 : 20));
        
        if (vacationSize == null)
        {
            throw new Exception(message: "Vacation Size is null");
        }

        return vacationSize;
    }   
}