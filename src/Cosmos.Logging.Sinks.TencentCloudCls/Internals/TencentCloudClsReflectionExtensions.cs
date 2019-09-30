using System.Collections.Generic;
using ClsContent = TencentCloud.Cls.Log.Types.Content;

namespace Cosmos.Logging.Sinks.TencentCloudCls.Internals
{
    internal static class ClsReflectionExtensions
    {
        public static List<ClsContent> AddContent(this List<ClsContent> contents, string key, string value)
        {
            contents.Add(new ClsContent {Key = key, Value = value});
            return contents;
        }
    }
}