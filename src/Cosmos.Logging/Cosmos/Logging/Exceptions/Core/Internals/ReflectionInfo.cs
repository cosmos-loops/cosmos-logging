namespace Cosmos.Logging.Exceptions.Core.Internals {
    internal class ReflectionInfo {
        public ReflectionPropertyInfo[] Properties { get; set; }

        public ReflectionPropertyInfo[] PropertiesExceptBaseOnes { get; set; }
    }
}