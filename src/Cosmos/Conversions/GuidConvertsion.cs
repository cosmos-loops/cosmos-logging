using System;

namespace Cosmos.Conversions
{
    /// <summary>
    /// GUID Converter
    /// </summary>
    public static class GuidConversion
    {
        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="Guid"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Guid ToGuid(object obj)
        {
            if (obj == null)
            {
                return Guid.Empty;
            }

            return Guid.TryParse(obj.ToString(), out Guid ret) ? ret : Guid.Empty;
        }

        /// <summary>
        /// Convert from an <see cref="object"/> to nullable <see cref=" Guid"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Guid? ToNullableGuid(object obj)
        {
            if (obj == null)
            {
                return null;
            }

            if (Guid.TryParse(obj.ToString(), out Guid ret))
            {
                return ret;
            }

            return null;
        }
    }
}
