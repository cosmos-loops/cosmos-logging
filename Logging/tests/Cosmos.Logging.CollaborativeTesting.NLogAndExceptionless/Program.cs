using System;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.CollaborativeTesting.NLogAndExceptionless {
    class Program {

        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args) {
            try {
                LOGGER.Initialize().RunsOnConsole()
                    .AddNLog(s => s.UseMinimumLevel(LogEventLevel.Information).UseDefaultOriginConfigFilePath())
                    .AddExceptionless(s => s.UseMinimumLevel(LogEventLevel.Information).UseAppSettings())
                    .AddSampleLog(s => s.UseMinimumLevel(LogEventLevel.Information))
                    .AllDone();

                var logger = LOGGER.GetLogger<Program>(LogEventLevel.Verbose, mode: LogEventSendMode.Manually);

                logger.LogInformation("hello");
                logger.LogError("world");
                logger.SubmitLogger();

                var logger2 = LOGGER.GetLogger<Program>(LogEventLevel.Verbose);
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