
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TwojUrlop.Common.Constrants;
using TwojUrlop.Common.Models.Interfaces;
using TwojUrlop.Common.Models.Settings;
using TwojUrlop.DataAccess.DatabaseContext;

namespace TwojUrlop.DependencyInjection.Extensions
{
    public static class DataAccessConfigExtensions
    {
        public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration, bool debugLogging = false)
        {
            services.Configure<ConnectionStringSettings>(configuration.GetSection("ConnectionStrings"));

            services.AddDbContextPool<TwojUrlopDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString(SettingsValue.DatabaseNameConnection),
                    x => x.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery));
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
                options.ConfigureWarnings(x => x.Ignore(CoreEventId.FirstWithoutOrderByAndFilterWarning, CoreEventId.RowLimitingOperationWithoutOrderByWarning));

                if (debugLogging)
                {
                    options.LogTo(x => Debug.WriteLine(x));
                }
            });

            services.AddScoped<ITwojUrlopDbContext>(provider => provider.GetService<TwojUrlopDbContext>());
            
            services.AddDataProtection().PersistKeysToDbContext<TwojUrlopDbContext>();
        }
    }
}