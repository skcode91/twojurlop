using Microsoft.AspNetCore.Builder;
using TwojUrlop.Common.Models.Settings;

namespace TwojUrlop.DependencyInjection.Extensions;
public static class CorsConfigExtensions
{
    public static void UseCorsConfig(this IApplicationBuilder app, SecuritySettings securitySettings)
    {
        app.UseCors(options =>
        {
            if (securitySettings.CORSOrigin == "*")
            {
                options.AllowAnyOrigin();
            }
            else
            {
                options.WithOrigins(securitySettings.CORSOrigin);
                if (bool.Parse(securitySettings.CookieAllowCredentials))
                {
                    options.AllowCredentials();
                }
            }
            options.AllowAnyHeader();
            options.AllowAnyMethod();
        });
    }
}
