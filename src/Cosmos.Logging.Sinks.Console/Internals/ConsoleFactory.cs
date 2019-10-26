using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Cosmos.Logging.Sinks.Console.Internals
{
    internal static class ConsoleFactory
    {
        private const string DefaultKey = "default";
        private static bool RunsOnWindows { get; }
        
        //todo 增加一个 NameConsoleCache MAX 上限

        private static IConsole DefaultConsole { get; }
        private static readonly Dictionary<int, IConsole> NamedConsoleCache = new Dictionary<int, IConsole>();
        private static object _cacheLockObj = new object();

        static ConsoleFactory()
        {
            RunsOnWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            DefaultConsole = CreateConsoleImpl(DefaultKey);
        }

        public static IConsole CreateConsole() => DefaultConsole;

        public static IConsole CreateConsole(string key) => CreateConsoleImpl(key);

        private static IConsole CreateConsoleImpl(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                key = DefaultKey;

            var hash = key.GetHashCode();

            // ReSharper disable once InconsistentlySynchronizedField
            if (NamedConsoleCache.TryGetValue(hash, out var console))
                return console;

            lock (_cacheLockObj)
            {
                if (NamedConsoleCache.TryGetValue(hash, out console))
                    return console;

                if (RunsOnWindows)
                    console = new WindowsConsole();
                else
                    console = new UnixConsole();

                NamedConsoleCache.Add(hash, console);

                return console;
            }
        }
    }
}