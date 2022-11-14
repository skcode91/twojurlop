using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TwojUrlop.DependencyInjection.Extensions;
public static class ServiceCollectionExtensions
{
    public static void ConfigureCommonServices(this IServiceCollection service, IConfiguration configuration,
        string projectName)
    {
        service.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
        service.Configure<KestrelServerOptions>(options => { options.AllowSynchronousIO = true; });

        service.AddMapster();
        service.AddHttpContextAccessor();
        service.AddDataAccess(configuration);
        service.AddNetCoreIdentity(configuration);
        service.AddJwt(configuration);
        service.AddControllers();
        service.AddSwagger(projectName);
        //service.AddCors();
        service.AddMvc();
    }
}