using System;
using AutoMapper;
using CateringManagementPlatform.Auth.Common;
using CateringManagementPlatform.BLL;
using CateringManagementPlatform.BLL.Interfaces;
using CateringManagementPlatform.BLL.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

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

            var authOptions = Configuration.GetSection("Auth").Get<AuthOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = authOptions.Issuer,

                        ValidateAudience = true,
                        ValidAudience = authOptions.Audience,

                        ValidateLifetime = true,

                        IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true
                    };
                });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddUnitOfWork();

            services.AddScoped<IBarmanService, BarmanService>();
            services.AddScoped<IChefService, ChefService>();
            services.AddScoped<IDishService, DishService>();
            services.AddScoped<IGuestService, GuestService>();
            services.AddScoped<IManagerService, ManagerService>();
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

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
