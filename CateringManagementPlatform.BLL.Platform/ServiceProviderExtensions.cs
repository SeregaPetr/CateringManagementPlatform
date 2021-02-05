using CateringManagementPlatform.BLL.Order;
using CateringManagementPlatform.BLL.Order.Interfaces;
using CateringManagementPlatform.BLL.Order.Services;
using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Interfaces;
using CateringManagementPlatform.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CateringManagementPlatform.BLL.Platform
{
    public static class ServiceProviderExtensions
    {

        public static IServiceCollection AddPlatformLibrary(this IServiceCollection services, string connectionString)
        {
            services.AddOrderLibrary(connectionString);

            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<IUnitOfWork, EFUnitOfWork>();

            services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(connectionString));

            return services;
        }
    }
}
