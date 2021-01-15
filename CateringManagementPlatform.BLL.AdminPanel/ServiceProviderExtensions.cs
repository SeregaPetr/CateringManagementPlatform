using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Interfaces;
using CateringManagementPlatform.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CateringManagementPlatform.BLL.AdminPanel
{
    public static class ServiceProviderExtensions
    {
        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
        }

        public static void AddCommanderContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(connectionString));
        }
    }
}
