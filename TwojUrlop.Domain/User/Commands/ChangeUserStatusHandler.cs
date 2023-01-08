
using Microsoft.EntityFrameworkCore;
using TwojUrlop.DataAccess.DatabaseContext;
using TwojUrlop.DomainModel.Common.Helpers;
using TwojUrlop.DomainModel.User.Commands.ChangeUserStatus;
using Enums = TwojUrlop.Common.Enums;

namespace TwojUrlop.Domain.User.Commands;
public class ChangeUserStatusHandler : IChangeUserStatusHandler
{
    private readonly TwojUrlopDbContext _context;
    public ChangeUserStatusHandler(TwojUrlopDbContext context)
    {
        _context = context;
    }

    public async Task Handle(ChangeUserStatusRequest request)
    {
        var currentUser = await _context.User
            .FirstOrDefaultAsync(x => x.Id == request.CurrentUserId);

        if (currentUser == null)
        {
            throw new Exception("User not found");
        }

        if (!UserHelper.IsManagerOrAdmin(currentUser))
        {
            throw new Exception("Unauthorized");
        }

        var userEntity = await _context.User
            .FirstOrDefaultAsync(x => x.Id == request.UserId);

        if (userEntity == null)
        {
            throw new Exception("User not found");
        }

        if (userEntity.RoleId == (int)Enums.Role.Admin && currentUser.RoleId == (int)Enums.Role.Manager)
        {
            throw new Exception("Unauthorized");
        }

        userEntity.StatusId = request.StatusId;

        await _context.SaveChangesAsync();
    }
}