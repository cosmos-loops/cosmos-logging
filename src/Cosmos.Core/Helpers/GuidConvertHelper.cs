using System;

namespace Cosmos.Helpers
{
    /// <summary>
    /// GUID convert helper
    /// </summary>
    public static class GuidConvertHelper
    {
        /// <summary>
        /// Convert from an object to guid
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Guid ToGuid(object obj)
        {
            if (obj == null)
                return Guid.Empty;

            Guid ret;
            return Guid.TryParse(obj.ToString(), out ret) ? ret : Guid.Empty;
        }

        /// <summary>
        /// Convert from an object to nullable guid
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Guid? ToNullableGuid(object obj)
        {
            if (obj == null)
                return null;

            Guid ret;
            if (Guid.TryParse(obj.ToString(), out ret))
            {
                return ret;
            }

            return null;
        }
    }
}
