using TwojUrlop.DomainModel.User.Commands.SetUserAsMenager;
using TwojUrlop.DataAccess.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using TwojUrlop.DomainModel.Common.Helpers;
using Enums = TwojUrlop.Common.Enums;

namespace TwojUrlop.Domain.User.Commands;

public class SetUserAsMenagerHandler : ISetUserAsMenagerHandler
{
    private readonly TwojUrlopDbContext _context;
    public SetUserAsMenagerHandler(TwojUrlopDbContext context)
    {
        _context = context;
    }
    public async Task Handle(SetUserAsMenagerRequest request)
    {
        var sendRequestUser = await _context.User.FirstOrDefaultAsync(x => x.Id == request.UserSentRequestId);
        if(sendRequestUser == null)
        {
            throw new Exception(message: "User not found");
        }
        if (!UserHelper.IsManagerOrAdmin(sendRequestUser))
        {
            throw new Exception("Unauthorized");
        }

        var changeRoleUser = await _context.User.FirstOrDefaultAsync(x => x.Id == request.UserChangeRoleId);
        if(changeRoleUser == null)
        {
            throw new Exception(message: "User not found");
        }
        if (UserHelper.IsManagerOrAdmin(changeRoleUser))
        {
            throw new Exception("User already is admin");
        }

        changeRoleUser.RoleId = (int)Enums.Role.Manager;

        await _context.SaveChangesAsync();
    }
}