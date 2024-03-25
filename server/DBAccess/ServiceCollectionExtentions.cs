//namespace DBAccess
//{
//    public static class ServiceCollectionExtentions
//    {
//        public static void AddDALServices(this IServiceCollection services, string connectionString)
//        {
//            services.AddDbContext<TaxiStationContext>(options =>
//                options.UseSqlServer(connectionString));
//        }
//    }
//}
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
//using MyDAL.Repositories;

namespace DBAccess
{
    public static class DALServiceCollectionExtensions
    {
        public static void AddDALServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TaxiStationContext>(options =>
                options.UseSqlServer(connectionString));

            //services.AddScoped<IRepository, Repository>();
            // Add other DAL services here
        }
    }
}