using System;
using System.Threading.Tasks;
using LogService.Repositories;
using LogServiceModels;
using LogServiceRequestMessages;
using MassTransit;
using Serilog;
using Xunit;

namespace LogServiceTests
{
    public class UnitTest1
    {
            const string ToTransmit = "Test";

            [Fact]
            public async void ConsumeTest()
            {

                var log = new LoggerConfiguration()
                    .WriteTo.RollingFile("..\\..\\..\\..\\Logs\\LogServiceLogTEST-{Date}.txt")
                    .CreateLogger();

                log.Information("RollingFileTest");

                 var logConsumer = Bus.Factory.CreateUsingInMemory(cfg =>
                 {
                    cfg.ReceiveEndpoint("queue_name", ep =>
                    {
                        ep.Handler<LogRequest>(
                            async (context) =>
                            {
                                if (context.Message.LogMessage == ToTransmit)
                                {
                                    await context.RespondAsync(new AssertMessage() { Assert = true });
                                }
                                else
                                {
                                    await context.RespondAsync(new AssertMessage() { Assert = false });
                                }
                            });
                    });
                 });

                IRequestClient<LogRequest, AssertMessage> testClient =
                    new MessageRequestClient<LogRequest, AssertMessage>(logConsumer,
                        new Uri("loopback://localhost/queue_name"), TimeSpan.FromSeconds(30));

                logConsumer.Start();

                var res = await CheckMessage(testClient);
                Assert.True(res);


            }

            public async Task<bool> CheckMessage(IRequestClient<LogRequest, AssertMessage> _testClient)
            {
                var res = await _testClient.Request(new { LogMessage = ToTransmit });
                return res.Assert;
            }


    }
}
