namespace Cosmos.Logging.Extensions.Exceptions.Core {
    internal class ExceptionDestructuringAccessor : IExceptionDestructuringAccessor {
        public ExceptionDestructuringProcessor Get() => ExceptionDestructuringContainer.GetInstance();
    }
}