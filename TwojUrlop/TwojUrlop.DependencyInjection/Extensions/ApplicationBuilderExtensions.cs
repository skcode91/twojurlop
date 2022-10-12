using Microsoft.AspNetCore.Builder;

namespace TwojUrlop.DependencyInjection.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ConfigureCommonPipeline(this IApplicationBuilder app, bool isDevelopment)
        {
            if (isDevelopment)
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
            }
            if(!isDevelopment)
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
}