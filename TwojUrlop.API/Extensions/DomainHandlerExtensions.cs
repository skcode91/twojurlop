using TwojUrlop.Domain.Authorization.Commands;
using TwojUrlop.Domain.Vacation.Commands;
using TwojUrlop.Domain.Vacation.Queries;
using TwojUrlop.DomainModel.Authorization.Commands.SignIn;
using TwojUrlop.DomainModel.Authorization.Commands.SignUp;
using TwojUrlop.DomainModel.Authorization.Queries;
using TwojUrlop.DomainModel.Vacation.Commands.DeleteVacationRequest;
using TwojUrlop.DomainModel.Vacation.Queries.GetVacationRequests;

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
    }
}


