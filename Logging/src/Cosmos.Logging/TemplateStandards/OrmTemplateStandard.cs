namespace Cosmos.Logging.TemplateStandards {
    public static class OrmTemplateStandard {
        public const string Normal = @"
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
EXCEPTION TYPE: {@ExceptionType}
MESSAGE: {@ExceptionMessage}
    REAL EXCEPTIOM TYPE: {@RealExceptionType}
    REAL MESSAGE: {@RealExceptionMessage}
USER INFO: {@UserInfo}
";
    }
}