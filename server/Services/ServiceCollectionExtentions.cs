using Services.ServicesImplementation;

namespace Services
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(TechnicalEmployeeDetailProfile));
            services.AddAutoMapper(typeof(PhysicalEmployeeDetailProfile));
            services.AddAutoMapper(typeof(OrderingTravelProfile));
            services.AddAutoMapper(typeof(HistoryTravelProfile));
            services.AddAutoMapper(typeof(DriverTemporaryLocationProfile));

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IDriverTemporaryLocationBlService, DriverTemporaryLocationBlService>();
            services.AddTransient<IHistoryTravelBlService, HistoryTravelBlService>();
            services.AddTransient<IOrderingTravelBlService, OrderingTravelBlService>();
            services.AddTransient<ITechnicalEmployeeDetailBlService, TechnicalEmployeeDetailBlService>();
            services.AddTransient<IPhysicalEmployeeDetailBlService, PhysicalEmployeeDetailBlService>();


            return services;
        }
    }
}