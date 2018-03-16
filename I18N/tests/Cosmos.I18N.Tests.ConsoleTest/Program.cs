using System;
using System.IO;
using Cosmos.I18N.Adapters.Json;
using Cosmos.I18N.Languages;
using Cosmos.I18N.RunsOn.Console;

namespace Cosmos.I18N.Tests.ConsoleTest {
    class Program {
        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args) {

            try {
                CosmosLocalization.Initialize()
                    .ToGlobal(c => c.SetPathBase(Directory.GetCurrentDirectory()).SetPathSegment("Resources/I18N"))
                    .AddJsonResourceFrom("Main.*.json")
                    .AllDone();

                Console.WriteLine(new Text("Hello world {0}", "Main", Locale.zh_CN, DateTime.Now));
                Console.WriteLine(new Text("Hello world {0}", "Main", Locale.en_US, DateTime.Now));
                Console.WriteLine(new Text("Hello world {0}", "Main", Locale.en_GB, DateTime.Now));

                Console.WriteLine("Hello world");
            }
            catch (Exception exception) {
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception.Source);
                Console.WriteLine(exception.StackTrace);
            }


            Console.ReadLine();
        }
    }
}