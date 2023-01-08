using Mapster;
using Microsoft.EntityFrameworkCore;
using TwojUrlop.DataAccess.DatabaseContext;
using TwojUrlop.DomainModel.Common;
using TwojUrlop.DomainModel.Common.Helpers;
using TwojUrlop.DomainModel.User.Queries.GetUsers;
using Enums = TwojUrlop.Common.Enums;

namespace TwojUrlop.Domain.User.Queries;
public class GetUsersHandler : IGetUsersHandler
{
    private readonly TwojUrlopDbContext _context;
    public GetUsersHandler(TwojUrlopDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserDto>> Handle(GetUsersRequest request)
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

        var usersEntity = _context.User.Where(x => x.Id != request.CurrentUserId && x.StatusId != (int)Enums.Status.Deleted);

        return usersEntity.Adapt<IEnumerable<UserDto>>();
    }
}