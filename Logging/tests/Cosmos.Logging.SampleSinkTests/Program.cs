using System;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.SampleLogSink;

namespace Cosmos.Logging.SampleSinkTests {

    class Program {
        static void Main(string[] args) {

            try {
                LOGGER.Initialize().RunsOnConsole(o => o.EnableDisplayCallerInfo(ThreeValuedBoolean.False).EnableDisplayEventIdInfo(true))
                    .AddSampleLog(s => s.UseMinimumLevel(LogEventLevel.Error).EnableDisplayCallerInfo(true))
                    .AllDone();

                var logger = LOGGER.GetLogger<Program>(mode: LogEventSendMode.Manually);

                logger.LogInformation("hello");
                logger.LogError("world", ctx => ctx.SetTags("Alex").SetTags("Lewis"));
                logger.LogError("Nice {@L}", ctx => ctx.SetParameter(new {L = "KK"}));
                logger.SubmitLogger();
                
                var future = logger.ToFuture();
                future
                    .SetLevel(LogEventLevel.Information)
                    .SetMessage("future log===> Nice {@L}")
                    .SetTags("Alex", "Lewis")
                    .SetParameter(new{L="KK2"})
                    .SetException(new ArgumentNullException(nameof(args)))
                    .Submit();

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