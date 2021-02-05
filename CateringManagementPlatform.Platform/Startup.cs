using System;
using AutoMapper;
using CateringManagementPlatform.BLL.Platform;
using CateringManagementPlatform.BLL.Platform.HubConfig;
using CateringManagementPlatform.BLL.Platform.Interfaces;
using CateringManagementPlatform.BLL.Platform.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CateringManagementPlatform.Platform
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        //.AllowAnyOrigin()
                        //.AllowAnyMethod()
                        //.AllowAnyHeader();
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });

            services.AddSignalR(); //hub
            services.AddControllers();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddPlatformLibrary(Configuration.GetConnectionString("CateringManagementPlatform"));
            services.AddScoped<IDataForDepartmentService, DataForDepartmentService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<PlatformHub>("/signalr");
            });
        }
    }
}
