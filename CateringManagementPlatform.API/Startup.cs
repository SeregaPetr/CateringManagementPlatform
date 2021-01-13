using System;
//using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CateringManagementPlatform.BLL;
using CateringManagementPlatform.BLL.Interfaces;
using CateringManagementPlatform.BLL.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CateringManagementPlatform.API
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCommanderContext(Configuration.GetConnectionString("CateringManagementPlatform"));

            services.AddControllers();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddUnitOfWork();

            services.AddScoped<IBarmanService, BarmanService>();
            services.AddScoped<ITableService, TableService>();
            services.AddScoped<IWaiterService, WaiterService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
