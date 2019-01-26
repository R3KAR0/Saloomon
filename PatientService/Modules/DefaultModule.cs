using System;
using Autofac;
using GreenPipes;
using MassTransit;
using PatientService.Consumers;
using PatientService.Repositories;

namespace PatientService.Modules
{
    public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new PatientsServiceContext())
                .AsSelf();
            builder.Register(c => new PatientsRepository(c.Resolve<PatientsServiceContext>())).AsSelf();

            builder.RegisterType<GetAllPatientsRequestConsumer>();
            builder.Register(c => Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                c = c.Resolve<IComponentContext>();
                var host = cfg.Host(new Uri(Startup.Configuration["RabbitMqUri"]), h =>
                {
                    cfg.UseSerilog(); 
                    cfg.UseRetry(configurator => configurator.Interval(5, TimeSpan.FromMilliseconds(500)));
                    cfg.UseCircuitBreaker(cb =>
                    {
                        cb.TrackingPeriod = TimeSpan.FromMinutes(1);
                        cb.TripThreshold = 15;
                        cb.ActiveThreshold = 20; 
                        cb.ResetInterval = TimeSpan.FromMinutes(4);
                    });

                    h.Username(Startup.Configuration["RabbitMqUser"]);
                    h.Password(Startup.Configuration["RabbitMqPassword"]);

                });

                cfg.ReceiveEndpoint(host, Startup.Configuration["GetAllPatientsQueue"], ep =>
                {
                    ep.Consumer(typeof(GetAllPatientsRequestConsumer), c.Resolve);
                });
            }))
            .As<IBusControl>()
            .As<IPublishEndpoint>()
            .SingleInstance();








        }
    }
}
