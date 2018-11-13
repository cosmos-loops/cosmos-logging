using System;

namespace Cosmos.Extensions
{
    /// <summary>
    /// Age helper
    /// </summary>
    public static class AgeHelper
    {
        /// <summary>
        /// 根据生日计算年纪
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        public static int Calculate(DateTime birthday) => Calculate(birthday, DateTime.Today);

        /// <summary>
        /// 根据生日和参照时间，计算当时年纪
        /// </summary>
        /// <param name="birthday">     </param>
        /// <param name="referenceDate"></param>
        /// <returns></returns>
        public static int Calculate(DateTime birthday, DateTime referenceDate)
        {
            var years = referenceDate.Year - birthday.Year;
            if (referenceDate.Month < birthday.Month || (referenceDate.Month == birthday.Month && referenceDate.Day < birthday.Day))
                --years;
            return years;
        }
    }
}