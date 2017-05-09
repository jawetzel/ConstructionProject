using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoreRepo.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Services;

namespace B2kConstructionApi
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
            //services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("LiveConnection")));
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("LocalHostConnection")));

            //services.AddScoped<AccountDataAccess>(); //sample Data Access DI For when we get there




            // Add framework services.
            services.AddMvc();

            services.AddCors(o => o.AddPolicy("allowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            }));
            services.AddCors(o => o.AddPolicy("allowLiveSite", builder =>
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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, Context context)
        {
            app.UseCors("allowAll");
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
            });
            app.UseDefaultFiles(new DefaultFilesOptions { DefaultFileNames = new List<string> { "index.html" } })
                .UseStaticFiles()
                .UseMvc();

            DbInitializer.Init(context);
        }
    }
}
