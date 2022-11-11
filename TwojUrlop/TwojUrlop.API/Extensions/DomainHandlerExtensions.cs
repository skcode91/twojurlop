using TwojUrlop.Domain.Authorization.Commands;
using TwojUrlop.DomainModel.Authorization.Commands.SignUp;

namespace TwojUrlop.Extensions
{
    public static class DomainHandlerExtensions
    {
        public static void AddDomainHandlers(this IServiceCollection services)
        {
            services.AddTransient<ISignUpHandler, SignUpHandler>();
        }
    }
}

