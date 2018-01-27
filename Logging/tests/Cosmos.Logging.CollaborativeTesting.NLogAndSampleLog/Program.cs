using System;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.NLog;
using Cosmos.Logging.Sinks.SampleLogSink;

namespace Cosmos.Logging.CollaborativeTesting.NLogAndSampleLog {
    class Program {
        static void Main(string[] args) {
            try {
                LOGGER.Initialize().RunsOnConsole()
                    //.UseNLog(s=>s.EnableUsingDefaultConfig())
                    .AddNLog()
                    .AddSampleLog(s => s.UseMinLevel(LogEventLevel.Debug))
                    .AllDone();

                var logger = LOGGER.GetLogger(mode: LogEventSendMode.Manually);

                logger.LogInformation("hello");
                logger.LogError("world");
                logger.SubmitLogger();

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