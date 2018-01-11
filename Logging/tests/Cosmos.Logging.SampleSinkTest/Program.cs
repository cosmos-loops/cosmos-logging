using System;
using Cosmos.Logging.Events;
using Cosmos.Logging.RunsOn.Console;
using Cosmos.Logging.RunsOn.Console.Settings;
using Cosmos.Logging.Sinks.SampleLogSink;

namespace Cosmos.Logging.SampleSinkTest {

    class Program {
        static void Main(string[] args) {

            try {
                LOGGER.Initialize().RunsOnConsole()
                    .WriteToSampleLog(s => s.Level = LogEventLevel.Error)
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