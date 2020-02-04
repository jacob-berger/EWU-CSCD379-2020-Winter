using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecretSanta.Business;
using SecretSanta.Business.Services;
using SecretSanta.Data;
using System;
using System.Reflection;

namespace SecretSanta.Api
{
    // Justification: Disable until ConfigureServices is added back.
#pragma warning disable CA1052 // Static holder types should be Static or NotInheritable
    public class Startup
    #pragma warning restore CA1052 // Static holder types should be Static or NotInheritable
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public static void ConfigureServices(IServiceCollection services)
        {
            SqliteConnection sqliteConnection = new SqliteConnection("DataSource=:memory:");

            sqliteConnection.Open();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.EnableSensitiveDataLogging().UseSqlite(sqliteConnection);
            });

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGiftService, GiftService>();
            services.AddScoped<IGroupService, GroupService>();
            Type profileType = typeof(AutomapperConfigurationProfile);
            Assembly assembly = profileType.Assembly;
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddAutoMapper(new[] { assembly });

            services.AddSwaggerDocument();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseMvc();
        }
    }
}
