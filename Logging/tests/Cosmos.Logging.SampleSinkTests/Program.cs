using System;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.SampleLogSink;

namespace Cosmos.Logging.SampleSinkTests {

    class Program {
        static void Main(string[] args) {

            try {
                LOGGER.Initialize().RunsOnConsole()
                    .AddSampleLog(s => s.UseMinimumLevel(LogEventLevel.Error))
                    .AllDone();

                var logger = LOGGER.GetLogger<Program>(mode: LogEventSendMode.Manually);

                logger.LogInformation("hello, {$CallerMemberName} {$CallerFilePath:pl20} {$CallerLineNumber}");
                logger.LogError("world, {$CallerMemberName} {$CallerFilePath:pl20} {$CallerLineNumber}");
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