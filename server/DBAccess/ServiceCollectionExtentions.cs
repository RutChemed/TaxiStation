using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DBAccess.DalImplementation;

namespace DBAccess
{
    public static class DALServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TaxiStationContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddTransient<ITechnicalEmployeeDetailService, TechnicalEmployeeDetailService>();
            services.AddTransient<IPhysicalEmployeeDetailService, PhysicalEmployeeDetailService>();
            services.AddTransient<IOrderingTravelService, OrderingTravelService>();
            services.AddTransient<IHistoryTravelService, HistoryTravelService>();
            services.AddTransient<IDriverTemporaryLocationService, DriverTemporaryLocationService>();

            return services;

        }
    }
}

