using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Helpers
{
    /// <summary>
    /// Generic convert helper
    /// </summary>
    public static class GenericConvertHelper
    {
        /// <summary>
        /// Convert from an object to a TTo instance
        /// </summary>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="fromObj"></param>
        /// <returns></returns>
        public static TTo To<TTo>(object fromObj)
        {
            if (fromObj == null)
                return default(TTo);

            if (fromObj is string && string.IsNullOrWhiteSpace(fromObj.ToString()))
                return default(TTo);

            var fromObjType = Nullable.GetUnderlyingType(typeof(TTo)) ?? typeof(TTo);
            try
            {
                if (fromObjType.Name.ToLower() == "guid")
                    return (TTo)(object)GuidConvertHelper.ToGuid(fromObj);

                if (fromObj is IConvertible)
                    return (TTo)Convert.ChangeType(fromObj, fromObjType);

                return (TTo)fromObj;
            }
            catch
            {
                return default(TTo);
            }
        }

        /// <summary>
        /// Convert from string to a TTo instances list
        /// </summary>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="listStr"></param>
        /// <param name="splitChar"></param>
        /// <returns></returns>
        public static IEnumerable<TTo> ToList<TTo>(string listStr, char splitChar = ',')
        {
            var ret = new List<TTo>();
            if (string.IsNullOrWhiteSpace(listStr))
                return ret;

            var array = listStr.Split(splitChar);
            ret.AddRange(from each in array where !string.IsNullOrWhiteSpace(each) select To<TTo>(each));

            return ret;
        }
    }
}
