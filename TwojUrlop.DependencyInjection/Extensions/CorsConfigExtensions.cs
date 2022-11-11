using Microsoft.AspNetCore.Builder;

namespace TwojUrlop.DependencyInjection.Extensions;
public static class CorsConfigExtensions
{
    public static void UseCorsConfig(this IApplicationBuilder app)
    {
        app.UseCors(options =>
        {
            options.AllowCredentials();
            options.AllowAnyMethod();
            options.AllowAnyHeader();
        });
    }
}
