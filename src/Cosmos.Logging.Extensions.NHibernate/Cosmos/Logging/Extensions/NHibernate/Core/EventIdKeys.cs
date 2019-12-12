namespace Cosmos.Logging.Extensions.NHibernate.Core {
    /// <summary>
    /// Event id keys
    /// </summary>
    public class EventIdKeys {
        /// <summary>
        /// Executed
        /// </summary>
        public static readonly string Executed = "SqlOp_Executed";

        /// <summary>
        /// Long time executed
        /// </summary>
        public static readonly string LongTimeExecuted = "SqlOp_LongTime_Executed";

        /// <summary>
        /// Error
        /// </summary>
        public static readonly string Error = "SqlOp_Error";

        /// <summary>
        /// Info
        /// </summary>
        public static readonly string Info = "SqlOp_Info";

        /// <summary>
        /// Warn
        /// </summary>
        public static readonly string Warn = "SqlOp_Warn";

        /// <summary>
        /// Debug
        /// </summary>
        public static readonly string Debug = "SqlOp_Debug";

        /// <summary>
        /// Sql exposure
        /// </summary>
        public static readonly string SqlExposure = "SqlOp_Exposure";
    }
}