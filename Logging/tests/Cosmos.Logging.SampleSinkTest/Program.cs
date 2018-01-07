using System;
using Cosmos.Logging.Configuration;
using Cosmos.Logging.RunsOn.Console;
using Cosmos.Logging.Sinks.SampleLogSink;

namespace Cosmos.Logging.SampleSinkTest {
    class Program {
        static void Main(string[] args) {

            try {
                LOGGER.Initialize().RunsOnConsole()
                    .WriteToSampleLog()
                    .AllDone();

                var logger = LOGGER.GetLogger();

                logger.Information("hello world!");

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