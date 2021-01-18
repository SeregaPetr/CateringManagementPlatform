using CateringManagementPlatform.BLL.AdminPanel.Interfaces;
using CateringManagementPlatform.BLL.AdminPanel.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CateringManagementPlatform.API.ServiceExtensions
{
    public static class AdminPanelServiceExtensions
    {
        public static void AddAdminPanelService(this IServiceCollection services)
        {
            services.AddScoped<IBarmanService, BarmanService>();
            services.AddScoped<IChefService, ChefService>();
            services.AddScoped<IDishService, DishService>();
            services.AddScoped<IGuestService, GuestService>();
            services.AddScoped<IManagerService, ManagerService>();
            services.AddScoped<ITableService, TableService>();
            services.AddScoped<IWaiterService, WaiterService>();
        }
    }
}
