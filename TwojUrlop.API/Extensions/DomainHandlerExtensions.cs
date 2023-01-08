using TwojUrlop.Domain.Authorization.Commands;
using TwojUrlop.Domain.Vacation.Commands;
using TwojUrlop.Domain.Vacation.Queries;
using TwojUrlop.DomainModel.Authorization.Commands.SignIn;
using TwojUrlop.DomainModel.Authorization.Commands.SignUp;
using TwojUrlop.DomainModel.Authorization.Queries;
using TwojUrlop.DomainModel.Vacation.Commands.DeleteVacationRequest;
using TwojUrlop.DomainModel.Vacation.Queries.GetVacationRequests;
using TwojUrlop.DomainModel.Vacation.Commands.SendVacationRequest;
using TwojUrlop.DomainModel.Vacation.Commands.HandleVacationRequest;
using TwojUrlop.DomainModel.Vacation.Queries.GetVacations;
using TwojUrlop.DomainModel.User.Queries.GetUserBaseInfo;
using TwojUrlop.DomainModel.User.Commands.AddUser;
using TwojUrlop.Domain.User.Queries;
using TwojUrlop.Domain.User.Commands;

namespace TwojUrlop.Extensions;
public static class DomainHandlerExtensions
{
    public static void AddDomainHandlers(this IServiceCollection services)
    {
        services.AddTransient<ISignUpHandler, SignUpHandler>();
        services.AddTransient<IGetUsersFullnameHandler, GetUsersFullnameHandler>();
        services.AddTransient<ISignInHandler, SignInHandler>();
        services.AddTransient<IGetVacationRequestsHandler, GetVacationRequestsHandler>();
        services.AddTransient<IDeleteVacationRequestHandler, DeleteVacationRequestHandler>();
        services.AddTransient<ISendVacationRequestHandler, SendVacationRequestHandler>();
        services.AddTransient<IHandleVacationRequestHandler, HandleVacationRequestHandler>();
        services.AddTransient<IGetVacationsHandler, GetVacationHandler>();
        services.AddTransient<IGetUserBaseInfoHandler, GetUserBaseInfoHandler>();
        services.AddTransient<IAddUserHandler, AddUserHandler>();
    }
}


