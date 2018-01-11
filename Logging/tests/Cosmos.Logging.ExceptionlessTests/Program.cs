using System;
using System.IO;
using Cosmos.Logging.Events;
using Cosmos.Logging.RunsOn.Console;
using Cosmos.Logging.RunsOn.Console.Settings;
using Cosmos.Logging.Settings;
using Cosmos.Logging.Sinks.Exceptionless;
using Exceptionless.Configuration;
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
                    .WriteToExceptionless()
                    .AllDone();

                var logger = LOGGER.GetLogger(mode: LogEventSendMode.Manually);

                logger.Information("测试1", ctx => ctx.ForExceptionless(h => h.AddTags("CosmosLogging")));
                logger.Information("测试2", builder => builder.AddTags("CosmosLogging"));
                logger.Error("world");
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