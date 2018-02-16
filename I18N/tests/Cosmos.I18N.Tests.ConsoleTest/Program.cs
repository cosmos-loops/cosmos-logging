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
                    .ToGlobal(c => { })
                    .AddJsonResourceFrom(Path.Combine(Directory.GetCurrentDirectory(), "Resources/I18N", "Main.zh_CN.json"))
                    .AllDone();

                Console.WriteLine(new Text("Hello world", "Main", Locale.zh_CN));

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