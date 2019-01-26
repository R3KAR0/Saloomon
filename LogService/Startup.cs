using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using LogService.Modules;
using LogService.Repositories;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using TaskUtil = MassTransit.Util.TaskUtil;

namespace LogService
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        /// <summary>
        /// All configurations are set here
        /// Logger configuration is set
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            

            Configuration = configuration;
            Configuration = Configuration.GetSection("ApplicationSettings");

            //var serilogConfig = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            //Log.Logger = new LoggerConfiguration()
            //    .ReadFrom.Configuration(serilogConfig)
            //    .CreateLogger();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.RollingFile("..\\Logs\\LogService\\LogService-{Date}.txt")
                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Debug)
                .CreateLogger();


        }

        /// <summary>
        /// Container are injected here and services are populated (at runtime)
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<DefaultModule>();
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime, IBusControl bus)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //logServiceContext.Database.Migrate();


            app.UseHttpsRedirection();
            app.UseMvc();

            var busHandle = TaskUtil.Await(() => bus.StartAsync());

            lifetime.ApplicationStopping
                .Register(() => busHandle.Stop());
        }
    }
}
