using System.Linq;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core.ObjectResolving.Rules {
    internal class ByteArrayResolveRule : IScalarResolveRule {
        private const int MaxLengthOfArray = 2 ^ 10;

        public bool TryResolve(object value, out MessagePropertyValue result) {
            if (value is byte[] valueBytes) {
                result = valueBytes.Length <= MaxLengthOfArray
                    ? new ScalarValue(valueBytes.ToArray())
                    : new ScalarValue($"{valueBytes.Take(16).Select(_ => _.ToString("X2"))}...({valueBytes.Length} bytes)");
                return true;
            }

            result = null;
            return false;
        }
    }
}