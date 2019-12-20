using System;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.SampleSinkTests {
    class Program {
        static void Main(string[] args) {

            try {
                LOGGER.Initialize().RunsOnConsole(o => o.EnableDisplayCallerInfo(ThreeValuedBoolean.False).EnableDisplayEventIdInfo(true))
                      .AddSampleLog(s => s.UseMinimumLevel(LogEventLevel.Error).EnableDisplayCallerInfo(true))
                      .AllDone();

                var logger = LOGGER.GetLogger<Program>(mode: LogEventSendMode.Manually);

                logger.LogInformation("hello");
                logger.LogInformation("hello {0},number={1}", new {A = "1"}, 2);
                logger.LogError("world", ctx => ctx.SetTags("Alex").SetTags("Lewis"));
                logger.LogError("Nice {@L}", ctx => ctx.SetParameter(new {L = "KK"}));
                logger.SubmitLogger();

                var logger2 = LOGGER.GetLogger<Program>(LogEventSendMode.Manually);
                logger2.LogInformation("hello level, length=完整000: {$Level}");
                logger2.SubmitLogger();
                logger2.LogInformation("hello level, length=井号001: {$Level:#}");
                logger2.SubmitLogger();
                logger2.LogInformation("hello level, length=井号002: {$Level:##}");
                logger2.SubmitLogger();
                logger2.LogInformation("hello level, length=井号003: {$Level:###}");
                logger2.SubmitLogger();
                logger2.LogInformation("hello level, length=井号004: {$Level:####}");
                logger2.SubmitLogger();
                logger2.LogInformation("hello level, length=井号011: {$Level:###########}");
                logger2.SubmitLogger();
                logger2.LogInformation("hello level, length=命令001: {$Level::length=1}");
                logger2.SubmitLogger();
                logger2.LogInformation("hello level, length=命令002: {$Level::length=2}");
                logger2.SubmitLogger();
                logger2.LogInformation("hello level, length=命令003: {$Level::length=3}");
                logger2.SubmitLogger();
                logger2.LogInformation("hello level, length=命令004: {$Level::length=4}");
                logger2.SubmitLogger();
                logger2.LogInformation("hello level, length=命令011: {$Level::length=11}");
                logger2.SubmitLogger();

                using (var scope = logger.BeginScope("OK")) {
                    
                }
                
                var future = logger.ToFuture();

                //future logger api style 1
                future
                   .SetLevel(LogEventLevel.Information)
                   .SetMessage("future log ====> Nice {@L} ====> [{$EventIdChains}][{$EventId}][{$EventName}][{$BizTraceId}]")
                   .SetTags("Alex", "Lewis")
                   .SetParameter(new {L = "KK2"})
                   .SetTrackInfo("1234567890","TrackTest", "biz123")
                   .SetException(new ArgumentNullException(nameof(args)))
                   .Submit();

                //future logger api style 2
                future.UseFields(
                    Fields.Level(LogEventLevel.Information),
                    Fields.Message("future log===> Nice {@L}"),
                    Fields.Tags("Alex", "Lewis"),
                    Fields.Args(new {L = "KK3"}),
                    Fields.Exception(new ArgumentNullException(nameof(args)))).Submit();

                var simple = logger.ToSimple();

                simple.LogInformation("Write log by simple logger");
                simple.LogError(new ArgumentException(), "Write log with exception for {0}", "Alex LEWIS");
                simple.LogInformation("Write log by simple logger{{helloworld}}{$NewLine}");

                Console.WriteLine("Hello World!");
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.StackTrace);
            }

            Console.ReadLine();
        }
    }
}