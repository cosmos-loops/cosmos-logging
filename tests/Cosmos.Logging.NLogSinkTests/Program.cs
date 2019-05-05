using System;
using System.IO;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;
using Cosmos.Logging.Future;
using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Config;
using NLog.Targets;
using Cosmos.Logging.Sinks.NLog;

namespace Cosmos.Logging.NLogSinkTests {
    class Program {
        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args) {

            try {
                var root = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true).Build();

                LOGGER.Initialize(root).RunsOnConsole().AddNLog().AddSampleLog().AllDone();


//                LOGGER.Initialize("appsettings.json", FileTypes.Json).RunsOnConsole().AddNLog().AddSampleLog().AllDone();

                var logger1 = LOGGER.GetLogger<Program>(mode: LogEventSendMode.Manually);
                logger1.LogWarning("hello， {$Date} {$MachineName}");
                logger1.SubmitLogger();
//
//                var logger2 = LOGGER.GetLogger<Program>();
//                logger2.LogWarning("world");
//
//                var logger3 = LOGGER.GetLogger<Program>().ToFuture();
//                var logger4 = logger2.ToFuture();
//
//                var logger5 = FUTURE.GetFutureLogger<Program>();
//                logger5.SetLevel(LogEventLevel.Warning)
//                    .SetMessage("future log===> Nice {@L}")
//                    .SetTags("Alex", "Lewis")
//                    .SetParameter(new {L = "KK2"})
//                    .SetException(new ArgumentNullException(nameof(args)))
//                    .Submit();
//
//                logger5.UseFields(
//                    Fields.Level(LogEventLevel.Warning),
//                    Fields.Message("future log===> Nice {@L}"),
//                    Fields.Tags("Alex", "Lewis"),
//                    Fields.Args(new {L = "KK3"}),
//                    Fields.Exception(new ArgumentNullException(nameof(args)))).Submit();

                Console.WriteLine("Hello World!");
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.StackTrace);
            }

            Console.ReadLine();
        }

        private static NLog.Config.LoggingConfiguration GetNLogConfig() {
            var config = new NLog.Config.LoggingConfiguration();
            var consoleTarget = new ColoredConsoleTarget();
            config.AddTarget("console", consoleTarget);
            consoleTarget.Layout = @"${date:format=HH\:mm\:ss} ${logger} ${message}";
            var rule1 = new LoggingRule("a", LogLevel.Debug, consoleTarget);
            config.LoggingRules.Add(rule1);

            return config;
        }
    }
}