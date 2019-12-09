namespace Cosmos.Logging.Extensions.NHibernate.Core {
    public class EventIdKeys {
        public static readonly string Executed = "SqlOp_Executed";
        public static readonly string LongTimeExecuted = "SqlOp_LongTime_Executed";
        public static readonly string Error = "SqlOp_Error";
        public static readonly string Info = "SqlOp_Info";
        public static readonly string Warn = "SqlOp_Warn";
        public static readonly string Debug = "SqlOp_Debug";
        public static readonly string SqlExposure = "SqlOp_Exposure";
    }
}