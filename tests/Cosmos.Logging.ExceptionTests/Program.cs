using System;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.ExceptionTests
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                LOGGER.Initialize().RunsOnConsole(o => o.EnableDisplayCallerInfo(ThreeValuedBoolean.False).EnableDisplayEventIdInfo(true))
                    .AddSampleLog(s => s.UseMinimumLevel(LogEventLevel.Error).EnableDisplayCallerInfo(true))
                    .AddExceptionsIntegration()
                    .AllDone();

                var logger = LOGGER.GetLogger<Program>();

                var inner = new ArgumentNullException("test", "Inner exception");
                var exception = new InvalidOperationException("Invalid operation exception for test.", inner);
                

                logger.LogError(exception, @"
Gets exception '{$Exception:U:N}'
Inner exception '{$Exception:U:U/N}'
Type: {$Exception::type}
Message: {$Exception}
Inner Message: {$Exception::unwrap/M}
Detail: {$Exception:j:D}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.StackTrace);
            }

            Console.ReadLine();
        }
    }
}