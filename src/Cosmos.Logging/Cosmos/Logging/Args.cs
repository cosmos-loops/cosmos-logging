using Cosmos.Serialization.Json;

namespace Cosmos.Logging {
    /// <summary>
    /// Args
    /// </summary>
    public class Args {
        private object[] _args;

        /// <summary>
        /// Create a new instance of <see cref="Args"/>.
        /// </summary>
        /// <param name="args"></param>
        public Args(params object[] args) => _args = args;

        /// <summary>
        /// explicit
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static explicit operator object[](Args args) {
            return args._args;
        }

        /// <inheritdoc />
        public override string ToString() {
            return _args.ToJson();
        }
    }
}