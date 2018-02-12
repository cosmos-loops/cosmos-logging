using System;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.CollaborativeTesting.NLogAndSampleLog {
    class Program {
        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args) {
            try {
                LOGGER.Initialize().RunsOnConsole()
                    //.UseNLog(s=>s.EnableUsingDefaultConfig())
                    .AddNLog()
                    .AddSampleLog(s => s.UseMinimumLevel(LogEventLevel.Debug))
                    .AllDone();

                var logger = LOGGER.GetLogger<Program>(mode: LogEventSendMode.Manually);

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