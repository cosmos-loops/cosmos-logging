namespace Cosmos.Logging.MessageTemplates.PresetTemplates {
    /// <summary>
    /// Web template standard
    /// </summary>
    public static class WebTemplateStandard {
        /// <summary>
        /// 400
        /// </summary>
        public const string WebLog400 = @"
FX NAME: {@FxName}
DATETIME: {$Date}
USED TIME: {@UsedTime}
STAT CODE: {@StausCode}
EXCP INFO: {@ExceptionDetails}
";

        /// <summary>
        /// 500
        /// </summary>
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

        /// <summary>
        /// Normal
        /// </summary>
        public const string Normal = @"
FX NAME: {@FxName}
DATETIME: {$Date}
USED TIME: {@UsedTime}
STAT CODE: {@StatusCode}
";

        /// <summary>
        /// Long normal
        /// </summary>
        public const string LongNormal = @"
FX NAME: {@FxName}
DATETIME: {$Date}
USED TIME: {@UsedTime}
STAT CODE: {@StatusCode}
";
    }
}