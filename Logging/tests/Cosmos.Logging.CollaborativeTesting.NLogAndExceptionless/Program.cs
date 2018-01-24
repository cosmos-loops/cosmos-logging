using System;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.Exceptionless;
using Cosmos.Logging.Sinks.NLog;
using Cosmos.Logging.Sinks.SampleLogSink;

namespace Cosmos.Logging.CollaborativeTesting.NLogAndExceptionless {
    class Program {
        
        static void Main(string[] args) {
            try {
                LOGGER.Initialize().RunsOnConsole()
                    .UseNLog(s =>
                    {
                        s.Level = LogEventLevel.Information;
                        s.UseDefaultOriginConfigFilePath();
                    })
                    .UseExceptionless(s =>
                    {
                        s.Level = LogEventLevel.Information;
                        s.UseAppSettings();
                    })
                    .UseSampleLog(s => s.Level = LogEventLevel.Information)
                    .AllDone();

                var logger = LOGGER.GetLogger(LogEventLevel.Verbose ,mode: LogEventSendMode.Manually);

                logger.LogInformation("hello");
                logger.LogError("world");
                logger.SubmitLogger();

                var logger2 = LOGGER.GetLogger(LogEventLevel.Verbose);
                logger2.LogInformation("submit log automatically");

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