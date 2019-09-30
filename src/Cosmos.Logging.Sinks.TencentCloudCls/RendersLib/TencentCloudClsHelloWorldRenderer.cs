﻿using System;
using System.Collections.Generic;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Formattings;
using Cosmos.Logging.Renders;
using Cosmos.Logging.Sinks.TencentCloudCls.Internals;

namespace Cosmos.Logging.Sinks.TencentCloudCls.RendersLib
{
    // ReSharper disable once InconsistentNaming
    [Renderer("HelloWorld", Constants.SinkKey)]
    public class TencentCloudClsHelloWorldRenderer : BasicPreferencesSinkRenderer
    {
        private const string Content = "Tencent Cloud CLS, Hello World";

        public override string Name => "HelloWorld";

        public override string SinkPrefix => Constants.SinkKey;

        public override string ToString(IList<FormatEvent> formattingEvents, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null)
        {
            return formattingEvents.ToFormat(Content, formatProvider);
        }

        public override string ToString(IList<Func<object, IFormatProvider, object>> formattingFuncs, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null)
        {
            return formattingFuncs.ToFormat(Content, formatProvider);
        }

        public override string ToString(string format, string paramsText,
            ILogEventInfo logEventInfo = null, IFormatProvider formatProvider = null)
        {
            return Content;
        }

        public override string ToString()
        {
            return ToString((string) null, null);
        }
    }
}