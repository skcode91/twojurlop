using Microsoft.EntityFrameworkCore;
using TwojUrlop.DataAccess.DatabaseContext;
using TwojUrlop.DomainModel.Authorization.Queries;

namespace TwojUrlop.Domain.Authorization.Commands;
public class GetUsersFullnameHandler : IGetUsersFullnameHandler
{
    private readonly TwojUrlopDbContext _context;

    public GetUsersFullnameHandler(TwojUrlopDbContext context)
    {
        _context = context;
    }

    public async Task<List<string>> Handle()
    {
        var users = await _context.User.ToListAsync();

        if (users == null)
        {
            throw new Exception();
        }

        return users.Select(x => (x.FirstName + " " + x.LastName)).ToList();
    }
}


