using Cosmos.Logging.Core;

namespace Cosmos.Logging.RunsOn.NancyFX.Core {
    /// <summary>
    /// Handler logger container
    /// </summary>
    internal static class HandlerLoggerContainer {
        public static ILogger ErrorHandlerLogger<T>() => StaticServiceResolver.Instance.GetLogger<T>();
    }
}