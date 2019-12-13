using System;
using System.IO;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.Log4Net;
using Microsoft.Extensions.Configuration;

namespace Cosmos.Logging.Log4NetSinkTests {
    class Program {
        static void Main(string[] args) {
            try {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());

                LOGGER.Initialize(builder).RunsOnConsole()
                    .AddLog4Net(s => s.UseDefaultOriginalConfigFilePath())
                    .AllDone();

                var logger = LOGGER.GetLogger<Program>(mode: LogEventSendMode.Manually);

                logger.LogInformation("hello");
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