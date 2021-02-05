using CateringManagementPlatform.DAL.EF;
using CateringManagementPlatform.DAL.Interfaces;
using CateringManagementPlatform.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CateringManagementPlatform.BLL.Order
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddOrderLibrary(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(connectionString));

            return services;
        }
    }
}
