using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MassTransit;
using MassTransit.Util;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatientService.Modules;
using PatientService.Repositories;
using Serilog;
using Serilog.Events;

namespace PatientService
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
                .WriteTo.RollingFile("..\\Logs\\PatientService\\PatientLog-{Date}.txt")
                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Debug)
                .CreateLogger();
        }

        /// <summary>
        /// 
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


        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime, IBusControl bus, PatientsServiceContext patientsServiceContext)
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


            // app.UseHttpsRedirection();
            app.UseMvc();

            //starts bus
            TaskUtil.Await(() => bus.StartAsync());

            //stops bus at service shutdown
            lifetime.ApplicationStopping.Register(() => bus.StopAsync());
        }
    }
}
