using TwojUrlop.Domain.Authorization.Commands;
using TwojUrlop.DomainModel.Authorization.Commands.SignUp;
using TwojUrlop.DomainModel.Authorization.Queries;

namespace TwojUrlop.Extensions
{
    public static class DomainHandlerExtensions
    {
        public static void AddDomainHandlers(this IServiceCollection services)
        {
            services.AddTransient<ISignUpHandler, SignUpHandler>();
            services.AddTransient<IGetUsersFullnameHandler, GetUsersFullnameHandler>();
        }
    }
}

