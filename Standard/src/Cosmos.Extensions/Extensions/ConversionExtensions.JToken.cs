using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static class JTokenConversionExtensions
    {
        public static int ToInt(this JToken token)
        {
            return token?.ToObject<int>() ?? default(int);
        }

        public static int ToInt(this JToken token, string sectionName)
        {
            return token[sectionName]?.ToObject<int>() ?? default(int);
        }

        public static long ToLong(this JToken token)
        {
            return token?.ToObject<long>() ?? default(long);
        }

        public static long ToLong(this JToken token, string sectionName)
        {
            return token[sectionName]?.ToObject<long>() ?? default(long);
        }

        public static double ToDouble(this JToken token)
        {
            return token?.ToObject<double>() ?? default(double);
        }

        public static double ToDouble(this JToken token, string sectionName)
        {
            return token[sectionName]?.ToObject<double>() ?? default(double);
        }

        public static float ToFloat(this JToken token)
        {
            return token?.ToObject<float>() ?? default(float);
        }

        public static float ToFloat(this JToken token, string sectionName)
        {
            return token[sectionName]?.ToObject<float>() ?? default(float);
        }

        public static List<T> ToList<T>(this JToken token)
        {
            return token?.ToObject<List<T>>();
        }

        public static List<T> ToList<T>(this JToken token, string sectionName)
        {
            return token[sectionName]?.ToObject<List<T>>();
        }

        public static IEnumerable<T> ToEnumerable<T>(this JToken token)
        {
            return token?.ToObject<IEnumerable<T>>();
        }

        public static IEnumerable<T> ToEnumerable<T>(this JToken token, string sectionName)
        {
            return token[sectionName]?.ToObject<IEnumerable<T>>();
        }

        public static Dictionary<T, K> ToDictionary<T, K>(this JToken token)
        {
            return token?.ToObject<Dictionary<T, K>>();
        }

        public static Dictionary<T, K> ToDictionary<T, K>(this JToken token, string sectionName)
        {
            return token[sectionName]?.ToObject<Dictionary<T, K>>();
        }

        public static DateTime ToDateTime(this JToken token)
        {
            return token?.ToObject<DateTime>() ?? default(DateTime);
        }

        public static DateTime ToDateTime(this JToken token, string sectionName)
        {
            return token[sectionName]?.ToObject<DateTime>() ?? default(DateTime);
        }

        public static Guid ToGuid(this JToken token)
        {
            return token?.ToObject<Guid>() ?? default(Guid);
        }

        public static Guid ToGuid(this JToken token, string sectionName)
        {
            return token[sectionName]?.ToObject<Guid>() ?? default(Guid);
        }
    }
}