namespace Services
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ITechnicalEmployeeDetailService, TechnicalEmployeeDetailService>();
            services.AddTransient<IPhysicalEmployeeDetailService, PhysicalEmployeeDetailService>();
            services.AddTransient<IOrderingTravelService, OrderingTravelService>();
            services.AddTransient<IHistoryTravelService, HistoryTravelService>();
            services.AddTransient<IDriverTemporaryLocationService, DriverTemporaryLocationService>();
            //services.AddRepositories(configuration);
            //services.AddMyDbContext(configuration.GetConnectionString("DefaultConnection"));
            services.AddAutoMapper(typeof(TechnicalEmployeeDetailProfile));
            services.AddAutoMapper(typeof(PhysicalEmployeeDetailProfile));
            services.AddAutoMapper(typeof(OrderingTravelProfile));
            services.AddAutoMapper(typeof(HistoryTravelProfile));
            services.AddAutoMapper(typeof(DriverTemporaryLocationProfile));
            return services;
        }
    }
}