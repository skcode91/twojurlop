using Microsoft.AspNetCore.Builder;
using TwojUrlop.Common.Models.Settings;

namespace TwojUrlop.DependencyInjection.Extensions;
public static class ApplicationBuilderExtensions
{
    public static void ConfigureCommonPipeline(this IApplicationBuilder app, SecuritySettings securitySettings, bool isDevelopment)
    {
        if (isDevelopment || true)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
        }
        app.UseCorsConfig(securitySettings);


        if (!isDevelopment)
            app.UseHttpsRedirection();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
