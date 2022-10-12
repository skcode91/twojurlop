using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TwojUrlop.Common.Models.Entities;
using TwojUrlop.DataAccess.DatabaseContext;

namespace TwojUrlop.DependencyInjection.Extensions;

public static class IdentityConfigExtensions
{
    public static void AddNetCoreIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = false;
                options.Tokens.EmailConfirmationTokenProvider = "EmailDataProtectorTokenProvider";
            })
            .AddEntityFrameworkStores<TwojUrlopDbContext>()
            .AddDefaultTokenProviders();
    }
}