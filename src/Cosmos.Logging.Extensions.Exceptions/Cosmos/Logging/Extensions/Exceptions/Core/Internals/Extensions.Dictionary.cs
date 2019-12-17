using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Logging.Extensions.Exceptions.Core.Internals {
    internal static class DictionaryExtensions {
        public static Dictionary<string, object> MapToStrObjDictionary(this IDictionary dictionary) {
            return dictionary.Keys.Cast<object>().ToDictionary(key => key.ToString(), key => dictionary[key]);
        }
    }
}