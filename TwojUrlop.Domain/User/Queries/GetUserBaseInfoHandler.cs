using Mapster;
using Microsoft.EntityFrameworkCore;
using TwojUrlop.DataAccess.DatabaseContext;
using TwojUrlop.DomainModel.Common.Helpers;
using TwojUrlop.DomainModel.User.Queries.GetUserBaseInfo;

namespace TwojUrlop.Domain.User.Queries;
public class GetUserBaseInfoHandler : IGetUserBaseInfoHandler
{
    private readonly TwojUrlopDbContext _context;
    public GetUserBaseInfoHandler(TwojUrlopDbContext context)
    {
        _context = context;
    }

    public async Task<GetUserBaseInfoResponse> Handle(GetUserBaseInfoRequest request)
    {
        var currentUser = await _context.User
            .FirstOrDefaultAsync(x => x.Id == request.CurrentUserId);

        if (currentUser == null)
        {
            throw new Exception("User not found");
        }

        if (request.UserId == currentUser.Id)
        {
            return currentUser.Adapt<GetUserBaseInfoResponse>();
        }

        if (!UserHelper.IsManagerOrAdmin(currentUser))
        {
            throw new Exception("Unauthorized");
        }

        var user = await _context.User
            .FirstOrDefaultAsync(x => x.Id == request.UserId);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        return user.Adapt<GetUserBaseInfoResponse>();
    }
}