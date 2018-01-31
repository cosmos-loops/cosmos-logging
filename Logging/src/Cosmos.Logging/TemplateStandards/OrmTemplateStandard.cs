namespace Cosmos.Logging.TemplateStandards {
    public static class OrmTemplateStandard {
        public const string SimpleSqlLog = @"
ORM NAME: {@OrmName}
DATETIME: {$Date}
SQL: {@Sql}
USER INFO: {@UserInfo}
";
        
        public const string Normal = @"
ORM NAME: {@OrmName}
DATETIME: {$Date}
CONTEXT ID: {@ContextId}
SQL: {@Sql}
USED TIME: {@UsedTime}
USER INFO: {@UserInfo}
";

        public const string LongNormal = @"
ORM NAME: {@OrmName}
DATETIME: {$Date}
CONTEXT ID: {@ContextId}
SQL: {@Sql}
PARAMS: {@SqlParams}
USED TIME: {@UsedTime}
USER INFO: {@UserInfo}
";

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