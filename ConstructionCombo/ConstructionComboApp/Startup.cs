using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ConstructionRepo.Data;
using ConstructionRepo.DataAccess.DataAccessClasses;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ConstructionComboApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Database Connection
            //services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevLiveConnection")));
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Data Access
            services.AddScoped<AccountDataAccess>();
            services.AddScoped<OrdersDataAccess>();

            // Business Logic

            // Add framework services.
            services.AddMvc();
            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            }));
            services.AddCors(o => o.AddPolicy("allowLiveSites", builder =>
            {
                builder.WithOrigins("http://b2kconstruction.com")
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            }));
            services.AddCors(o => o.AddPolicy("localHost", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, DataContext context)
        {
            //app.UseCors("allowLiveSites");
            app.UseCors("localHost");

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.Use(async (routecontext, next) =>
            {
                await next();
                if (routecontext.Response.StatusCode == 404 && !Path.HasExtension(routecontext.Request.Path.Value))
                {
                    routecontext.Request.Path = "/index.html";
                    await next();
                }
            })
                .UseDefaultFiles(new DefaultFilesOptions { DefaultFileNames = new List<string> { "index.html" } })
                .UseStaticFiles()
                .UseMvc();

            DbInitializer.Initialize(context); //initializes db
        }
    }
}
