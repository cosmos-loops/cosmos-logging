using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Cosmos
{
    public static class JTokenExtensions
    {
        public static JToken GetToken(this JToken token, string key) => token[key];

        public static string GetString(this JToken token, string key) => token[key].ToString();

        public static bool GetBool(this JToken token, string key) => token[key].ToObject<bool>();

        public static int GetInt(this JToken token, string key) => token[key].ToObject<int>();

        public static double GetDouble(this JToken token, string key) => token[key].ToObject<double>();

        public static List<T> GetList<T>(this JToken token, string key) => token[key].ToObject<List<T>>();

        public static Dictionary<TKey, TValue> GetDictionary<TKey, TValue>(this JToken token, string key) => token[key].ToObject<Dictionary<TKey, TValue>>();

        public static T GetObject<T>(this JToken token, string key) => token[key].ToObject<T>();
    }
}