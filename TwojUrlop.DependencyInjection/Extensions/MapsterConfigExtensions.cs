using AIA.DependencyInjection.Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace TwojUrlop.DependencyInjection.Extensions;

public static class MapsterConfigExtensions
{
    public static void AddMapster(this IServiceCollection services)
    {
        services.AddSingleton<IMapsterConfiguration, MapsterConfiguration>();
    }
}

