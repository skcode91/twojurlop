
using Microsoft.EntityFrameworkCore;
using TwojUrlop.DataAccess.DatabaseContext;
using TwojUrlop.DomainModel.Common.Helpers;
using TwojUrlop.DomainModel.User.Commands.ChangeUserRole;
using Enums = TwojUrlop.Common.Enums;

namespace TwojUrlop.Domain.User.Commands;
public class ChangeUserRoleHandler : IChangeUserRoleHandler
{
    private readonly TwojUrlopDbContext _context;
    public ChangeUserRoleHandler(TwojUrlopDbContext context)
    {
        _context = context;
    }

    public async Task Handle(ChangeUserRoleRequest request)
    {
        var currentUser = await _context.User
            .FirstOrDefaultAsync(x => x.Id == request.CurrentUserId);

        if (currentUser == null)
        {
            throw new Exception("User not found");
        }

        if (!UserHelper.IsManagerOrAdmin(currentUser)
            || (request.RoleId == (int)Enums.Role.Admin && currentUser.RoleId == (int)Enums.Role.Manager))
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

        userEntity.RoleId = request.RoleId;

        await _context.SaveChangesAsync();
    }
}