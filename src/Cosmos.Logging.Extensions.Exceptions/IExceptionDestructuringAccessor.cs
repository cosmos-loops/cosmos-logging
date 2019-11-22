using Cosmos.Logging.Extensions.Exceptions.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging
{
    public interface IExceptionDestructuringAccessor
    {
        ExceptionDestructuringProcessor Get();
    }
}