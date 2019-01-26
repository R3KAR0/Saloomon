using System;
using Autofac;
using GatewayService.Validators;
using GreenPipes;
using LogServiceRequestMessages;
using LogServiceResponseMessages;
using MassTransit;
using Polly;
using UserServiceRequestMessages;
using UserServiceResponseMessages;

namespace GatewayService.Modules
{
    /// <inheritdoc />
    /// <summary>
    /// DEPENDENCY INJECTION
    /// TODO - Request Clients 
    /// </summary>
    public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            MultiValidatorBase.Validators.Add(typeof(SqlInjectionValidator<>));

            var timeout = TimeSpan.FromSeconds(10);

            builder.Register(c => Bus.Factory.CreateUsingRabbitMq(cfg =>
                    cfg.Host(new Uri(Startup.Configuration["RabbitMqUri"]), h =>
                    {
                        c = c.Resolve<IComponentContext>();
                        cfg.UseSerilog();
                        cfg.UseRetry(configurator => configurator.Interval(5, TimeSpan.FromMilliseconds(500)));
                        cfg.PrefetchCount = 50;
                        cfg.UseCircuitBreaker(cb =>
                        {
                            cb.TrackingPeriod = TimeSpan.FromMinutes(1);
                            cb.TripThreshold = 15;
                            cb.ActiveThreshold = 20;
                            cb.ResetInterval = TimeSpan.FromMinutes(4);
                        });
                        h.Username(Startup.Configuration["RabbitMqUser"]);
                        h.Password(Startup.Configuration["RabbitMqPassword"]);
                        

                    })
                ))
                .As<IBusControl>()
                .As<IPublishEndpoint>()
                .SingleInstance();

            #region LogRequestClients

            //GetAllLogsClient
            builder.Register(c => new MessageRequestClient<GetAllLogsRequest, LogListResponse>(
                    c.Resolve<IBusControl>(),
                    new Uri(Startup.Configuration["RabbitMqUri"] + Startup.Configuration["GetAllLogsQueue"]),
                    timeout
                ))
                .As<IRequestClient<GetAllLogsRequest, LogListResponse>>();


            //GetlogsByDateAfterClient
            builder.Register(c => new MessageRequestClient<GetLogsByDateAfter, LogListResponse>(
                    c.Resolve<IBusControl>(),
                    new Uri(Startup.Configuration["RabbitMqUri"] + Startup.Configuration["GetLogsByDateAfterQueue"]),
                    timeout
                ))
                .As<IRequestClient<GetLogsByDateAfter, LogListResponse>>();


            //GetlogsByDayBeforeClient
            builder.Register(c => new MessageRequestClient<GetLogsByDateBefore, LogListResponse>(
                    c.Resolve<IBusControl>(),
                    new Uri(Startup.Configuration["RabbitMqUri"] + Startup.Configuration["GetLogsByDateBeforeQueue"]),
                    timeout
                ))
                .As<IRequestClient<GetLogsByDateBefore, LogListResponse>>();


            //GetlogsByDateBetweenClient
            builder.Register(c => new MessageRequestClient<GetLogsByDateBetween, LogListResponse>(
                    c.Resolve<IBusControl>(),
                    new Uri(Startup.Configuration["RabbitMqUri"] + Startup.Configuration["GetLogsByDateBetweenQueue"]),
                    timeout
                ))
                .As<IRequestClient<GetLogsByDateBetween, LogListResponse>>();


            //GetlogsByLogLevelClient
            builder.Register(c => new MessageRequestClient<GetLogsByLevelRequest, LogListResponse>(
                    c.Resolve<IBusControl>(),
                    new Uri(Startup.Configuration["RabbitMqUri"] + Startup.Configuration["GetLogsByLevelQueue"]),
                    timeout
                ))
                .As<IRequestClient<GetLogsByLevelRequest, LogListResponse>>();


            #endregion


            #region UserRequestClients
            
            //LoginClient
            builder.Register(c => new MessageRequestClient<LoginRequest, LoginResponse>(
                    c.Resolve<IBusControl>(),
                    new Uri(Startup.Configuration["RabbitMqUri"] + Startup.Configuration["UserLoginQueue"]),
                    timeout
                ))
                .As<IRequestClient<LoginRequest, LoginResponse>>();



            builder.Register(c => new MessageRequestClient<RegisterRequest, RegisterResponse>(
                    c.Resolve<IBusControl>(),
                    new Uri(Startup.Configuration["RabbitMqUri"] + Startup.Configuration["UserRegistrationQueue"]),
                    timeout
                ))
                .As<IRequestClient<RegisterRequest, RegisterResponse>>();



            builder.Register(c => new MessageRequestClient<GetAllUsersRequest, GetAllUsersResponse>(
                    c.Resolve<IBusControl>(),
                    new Uri(Startup.Configuration["RabbitMqUri"] + Startup.Configuration["AllUsersRequestQueue"]),
                    timeout
                ))
                .As<IRequestClient<GetAllUsersRequest, GetAllUsersResponse>>();



            builder.Register(c => new MessageRequestClient<DeleteUserRequest, SuccessResponse>(
                    c.Resolve<IBusControl>(),
                    new Uri(Startup.Configuration["RabbitMqUri"] + Startup.Configuration["DeleteUserQueue"]),
                    timeout
                ))
                .As<IRequestClient<DeleteUserRequest, SuccessResponse>>();



            builder.Register(c => new MessageRequestClient<UpdateUserRequest, SuccessResponse>(
                    c.Resolve<IBusControl>(),
                    new Uri(Startup.Configuration["RabbitMqUri"] + Startup.Configuration["UpdateUserQueue"]),
                    timeout
                ))
                .As<IRequestClient<UpdateUserRequest, SuccessResponse>>();


            builder.Register(c => new MessageRequestClient<CreateAdminRequest, RegisterResponse>(
                    c.Resolve<IBusControl>(),
                    new Uri(Startup.Configuration["RabbitMqUri"] + Startup.Configuration["AdminQueue"]),
                    timeout
                ))
                .As<IRequestClient<CreateAdminRequest, RegisterResponse>>();

            ///TODO add missing CLIENTS

            #endregion



            #region PollyPolicies
            builder.Register(c =>
                {
                    var timeoutPolicy = Policy
                        .TimeoutAsync(90);

                    var retryPolicy = Policy
                        .Handle<RequestTimeoutException>()
                        .WaitAndRetryForeverAsync(attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)));

                    var circuitBreakerPolicy = Policy
                        .Handle<RequestTimeoutException>()
                        .AdvancedCircuitBreakerAsync(
                            failureThreshold: 0.20,
                            samplingDuration: TimeSpan.FromSeconds(35),
                            minimumThroughput: 30,
                            durationOfBreak: TimeSpan.FromSeconds(200)
                        );

                    return Policy.WrapAsync(timeoutPolicy, retryPolicy, circuitBreakerPolicy);
                })
                .As<Policy>()
                .SingleInstance();
            #endregion

        }



    }
}
