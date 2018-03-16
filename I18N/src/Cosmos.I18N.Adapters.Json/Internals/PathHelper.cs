using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cosmos.I18N.Configurations;

namespace Cosmos.I18N.Adapters.Json.Internals {
    internal static class PathHelper {
        public static bool IsSeveralPath(string path) {
            return path.IndexOf('*') >= 0;
        }

        public static string Combine(I18NOptions options, string path, bool referenceToBasePath) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            return referenceToBasePath
                ? Path.Combine(options.PathBase, options.PathSegment, path)
                : path;
        }
        
        public static IEnumerable<string> GetSeveralPathList(I18NOptions options, string path) {
            var di = new DirectoryInfo(Path.Combine(options.PathBase, options.PathSegment));
            return di.GetFiles(path, SearchOption.AllDirectories).Select(x => x.FullName);
        }
    }
}