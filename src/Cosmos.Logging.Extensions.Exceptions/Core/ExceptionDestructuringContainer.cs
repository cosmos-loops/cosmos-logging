using System;

namespace Cosmos.Logging.Extensions.Exceptions.Core
{
    internal static class ExceptionDestructuringContainer
    {
        private static ExceptionDestructuringProcessor Instance { get; set; }

        public static ExceptionDestructuringProcessor GetInstance()
        {
            if (Instance is null)
                throw new InvalidOperationException("Cannot get the instance of exception destructuring processor");

            return Instance;
        }

        public static void SetInstance(ExceptionDestructuringProcessor processor)
        {
            if (Instance != null)
                throw new InvalidOperationException("The instance of exception destructuring processor has been set.");

            Instance = processor ?? throw new ArgumentNullException(nameof(processor));
        }
    }
}