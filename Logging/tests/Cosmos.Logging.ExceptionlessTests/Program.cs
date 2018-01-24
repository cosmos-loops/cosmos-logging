using System;
using System.IO;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.Exceptionless;
using Microsoft.Extensions.Configuration;

namespace Cosmos.Logging.ExceptionlessTests {
    class Program {
        static void Main(string[] args) {
            try {
                //var configBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                //    .AddXmlFile("App.Config", true, true);

                var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddXmlFile("App.Config", true, true).Build();

                LOGGER.Initialize(config).RunsOnConsole()
                    .UseExceptionless()
                    .AllDone();

                var logger = LOGGER.GetLogger(mode: LogEventSendMode.Manually);

                logger.LogInformation("测试1", ctx => ctx.ForExceptionless(h => h.AddTags("CosmosLogging")));
                logger.LogInformation("测试2", builder => builder.AddTags("CosmosLogging"));
                logger.LogError("world");
                logger.SubmitLogger();

                Console.WriteLine("Hello World!");
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.StackTrace);
            }

            Console.ReadLine();
        }
    }
}