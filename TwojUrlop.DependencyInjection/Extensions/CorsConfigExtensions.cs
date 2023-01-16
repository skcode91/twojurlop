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
                // options.WithOrigins("http://localhost:3000");
                // options.WithOrigins("http://localhost:3001");
                // options.WithOrigins("https://localhost:3000");
                // options.WithOrigins("https://localhost");
                options.WithOrigins("https://twoj-urlop.azurewebsites.net");
                options.WithOrigins("http://twoj-urlop.azurewebsites.net");

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
