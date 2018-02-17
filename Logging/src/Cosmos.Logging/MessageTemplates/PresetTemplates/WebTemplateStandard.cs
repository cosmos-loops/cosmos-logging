namespace Cosmos.Logging.MessageTemplates.PresetTemplates {
        public static class WebTemplateStandard {
        public const string WebLog400 = @"
FX NAME: {@FxName}
DATETIME: {$Date}
USED TIME: {@UsedTime}
STAT CODE: {@StausCode}
EXCP INFO: {@ExceptionDetails}
";

        public const string WebLog500 = @"
FX NAME: {@FxName}
DATETIME: {$Date}
USED TIME: {@UsedTime}
STAT CODE: {@StatusCode}
EXCEPTION TYPE: {@ExceptionType}
MESSAGE: {@ExceptionMessage}
    REAL EXCEPTIOM TYPE: {@RealExceptionType}
    REAL MESSAGE: {@RealExceptionMessage}
EXCP INFO: {@ExceptionDetails}
";

        public const string Normal = @"
FX NAME: {@FxName}
DATETIME: {$Date}
USED TIME: {@UsedTime}
STAT CODE: {@StatusCode}
";

        public const string LongNormal = @"
FX NAME: {@FxName}
DATETIME: {$Date}
USED TIME: {@UsedTime}
STAT CODE: {@StatusCode}
";
    }
}