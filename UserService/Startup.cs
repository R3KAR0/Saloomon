using System;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MassTransit;
using MassTransit.Util;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Serilog;
using Serilog.Events;
using UserService.Modules;
using UserService.Repositories;
using UserServiceModels;

namespace UserService
{
    public class Startup
    {

        public static IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Configuration = Configuration.GetSection("ApplicationSettings");


            //Log.Logger = new LoggerConfiguration()
            //    .ReadFrom.Configuration(configuration)
            //    .CreateLogger();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.RollingFile("..\\Logs\\UserService\\UserLog-{Date}.txt")
                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Debug)
                .CreateLogger();
        }


        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //HttpAccessor for reading request IPs
            services.AddHttpContextAccessor();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

            //var migrationAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            //services.AddDbContext<ApplicationUserContext>(builder => builder.UseSqlServer(Configuration["SqlConnectionString"], sql => sql.MigrationsAssembly(migrationAssembly)));

            services.AddDbContext<ApplicationUserContext>(options =>
                options.UseSqlServer(Configuration["SqlConnectionString"]));

            services.AddIdentityCore<ApplicationUser>(options => { });
            services.AddIdentityCore<ApplicationUser>(options => { });  
            services.AddScoped<IUserStore<ApplicationUser>, UserOnlyStore<ApplicationUser, ApplicationUserContext>>();
            services.AddScoped<UserManager<ApplicationUser>>();

            //Moved to DefaultModule!
            //services.AddScoped<UserManager<ApplicationUser>>();


            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<DefaultModule>();
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime, IBusControl bus, ApplicationUserContext context)
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

            app.UseMvc();

            var busHandle = TaskUtil.Await(() => bus.StartAsync());

            lifetime.ApplicationStopping
                .Register(() => busHandle.Stop());
        }
    }
}
