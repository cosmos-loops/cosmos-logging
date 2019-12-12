namespace Cosmos.Logging.MessageTemplates.PresetTemplates {
    /// <summary>
    /// Orm template standard
    /// </summary>
    public static class OrmTemplateStandard {
        /// <summary>
        /// Simple sql log
        /// </summary>
        public const string SimpleSqlLog = @"
ORM NAME: {@OrmName}
DATETIME: {$Date}
SQL: {@Sql}
USER INFO: {@UserInfo}
";

        /// <summary>
        /// Normal
        /// </summary>
        public const string Normal = @"
ORM NAME: {@OrmName}
DATETIME: {$Date}
CONTEXT ID: {@ContextId}
SQL: {@Sql}
USED TIME: {@UsedTime}
USER INFO: {@UserInfo}
";

        /// <summary>
        /// Long normal
        /// </summary>
        public const string LongNormal = @"
ORM NAME: {@OrmName}
DATETIME: {$Date}
CONTEXT ID: {@ContextId}
SQL: {@Sql}
PARAMS: {@SqlParams}
USED TIME: {@UsedTime}
USER INFO: {@UserInfo}
";

        /// <summary>
        /// Error
        /// </summary>
        public const string Error = @"
ORM NAME: {@OrmName}
DATETIME: {$Date}
CONTEXT ID: {@ContextId}
SQL: {@Sql}
PARAMS: {@SqlParams}
EXCEPTION TYPE: {@ExceptionType}
MESSAGE: {@ExceptionMessage}
    REAL EXCEPTIOM TYPE: {@RealExceptionType}
    REAL MESSAGE: {@RealExceptionMessage}
USED TIME: {@UsedTime}
USER INFO: {@UserInfo}
";
    }
}