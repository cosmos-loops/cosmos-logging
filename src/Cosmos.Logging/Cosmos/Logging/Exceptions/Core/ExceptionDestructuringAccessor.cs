namespace Cosmos.Logging.Exceptions.Core {
    internal class ExceptionDestructuringAccessor : IExceptionDestructuringAccessor {
        public ExceptionDestructuringProcessor Get() => ExceptionDestructuringContainer.GetInstance();
    }
}