using System;
using Cosmos.Logging.Sinks.SampleLogSink;

namespace Cosmos.Logging.SampleSinkNfxTests {
    class Program {
        static void Main(string[] args) {

            try {
                LOGGER.Initialize().RunsOnConsole()
                    .AddSampleLog()
                    .AllDone();

                var logger = LOGGER.GetLogger<Program>();

                logger.LogInformation("hello world!");

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