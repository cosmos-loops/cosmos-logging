using System;
using System.IO;
using Cosmos.Logging.Configurations;
using Microsoft.Extensions.Configuration;

namespace Cosmos.Logging.ConfigFileLoadingTests {
    class Program {
        static void Main(string[] args) {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());
            ConfigLoadingContext.Load(builder, "logging.json", FileTypes.Json);
            var root = builder.Build();
            Console.WriteLine(root["Nice"]);
            Console.ReadKey();
        }
    }
}