using System;
using System.IO;
using Cosmos.Logging.Events;
using Cosmos.Logging.RunsOn.Console;
using Cosmos.Logging.RunsOn.Console.Settings;
using Cosmos.Logging.Sinks.Log4Net;
using Microsoft.Extensions.Configuration;

namespace Cosmos.Logging.Log4NetSinkTest {
    class Program {
        static void Main(string[] args) {
            try {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());

                LOGGER.Initialize(builder).RunsOnConsole()
                    .UseLog4Net(s => s.UseDefaultOriginConfigFilePath())
                    .AllDone();

                var logger = LOGGER.GetLogger(mode: LogEventSendMode.Manually);

                logger.Information("hello");
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