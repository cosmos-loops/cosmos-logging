namespace Cosmos.Logging.Core.LogFields {
    /// <summary>
    /// Interface for Log field
    /// </summary>
    public interface ILogField {
        /// <summary>
        /// Type
        /// </summary>
        LogFieldTypes Type { get; }

        /// <summary>
        /// Sort
        /// </summary>
        int Sort { get; set; }
    }

    /// <summary>
    /// Interface for Log field
    /// </summary>
    /// <typeparam name="TTypeValue"></typeparam>
    public interface ILogField<out TTypeValue> : ILogField {
        /// <summary>
        /// Value
        /// </summary>
        TTypeValue Value { get; }
    }
}