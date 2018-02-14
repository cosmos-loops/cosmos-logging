using System;
using Cosmos.I18N.Adapters.Json;
using Cosmos.I18N.Adapters.Xml;
using Cosmos.I18N.RunsOn.Console;

namespace Cosmos.I18N.Tests.ConsoleTest {
    class Program {
        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args) {

            CosmosLocalization.Initialize(config => { })
                .AddJsonResourceFrom("path1.json")
                .AddXmlResourceFrom("path2.xml")
                .AllDone();

            Console.ReadLine();
        }
    }
}