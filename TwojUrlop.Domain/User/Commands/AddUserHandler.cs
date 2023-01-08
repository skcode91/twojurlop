using TwojUrlop.DomainModel.User.Commands.AddUser;
using TwojUrlop.DataAccess.DatabaseContext;
using TwojUrlop.Domain.Authorization.Commands;
using TwojUrlop.DomainModel.Common.Helpers;
using TwojUrlop.DomainModel.Authorization.Commands.SignUp;
using Microsoft.EntityFrameworkCore;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Entities = TwojUrlop.Common.Models.Entities;

namespace TwojUrlop.Domain.User.Commands;

public class AddUserHandler : IAddUserHandler
{
    private readonly TwojUrlopDbContext _context;
    private readonly SignUpHandler _signUpHandler;
    public AddUserHandler(TwojUrlopDbContext context, UserManager<Entities.User> userManager)
    {
        _context = context;
        _signUpHandler = new SignUpHandler(userManager, context);
    }
    public async Task Handle(AddUserRequest request)
    {
        var user = await _context.User.FirstOrDefaultAsync(x => x.Id == request.CurrentUserId);

        if(user == null)
        {
            throw new Exception(message: "User is not found");
        }

        if (!UserHelper.IsManagerOrAdmin(user))
        {
            throw new Exception("Unauthorized");
        }

        await _signUpHandler.Handle(request.Adapt<SignUpRequest>());
    }
}