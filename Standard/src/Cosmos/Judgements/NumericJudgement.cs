namespace Cosmos.Judgements
{
    /// <summary>
    /// Numeric Judgement Utilities
    /// </summary>
    public static class NumericJudgement
    {
        /// <summary>
        /// To judge whether the string is integer or not
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInt32(string str)
        {
            return int.TryParse(str, out int i);
        }

        /// <summary>
        /// To judge whether the string is numeric or not
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumeric(string str)
        {
            return decimal.TryParse(str, out decimal d);
        }

        /// <summary>
        /// To judge whether the short value is between left and right
        /// </summary>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool IsBetween(short value, short left, short right)
        {
            return value >= left && value <= right;
        }

        /// <summary>
        /// To judge whether the int value is between left and right
        /// </summary>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool IsBetween(int value, int left, int right)
        {
            return value >= left && value <= right;
        }

        /// <summary>
        /// To judge whether the long value is between left and right
        /// </summary>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool IsBetween(long value, long left, long right)
        {
            return value >= left && value <= right;
        }

        /// <summary>
        /// To judge whether the float value is between left and right
        /// </summary>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool IsBetween(float value, float left, float right)
        {
            return value >= left && value <= right;
        }

        /// <summary>
        /// To judge whether the double value is between left and right
        /// </summary>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool IsBetween(double value, double left, double right)
        {
            return value >= left && value <= right;
        }

        /// <summary>
        /// To judge whether the decimal value is between left and right
        /// </summary>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool IsBetween(decimal value, decimal left, decimal right)
        {
            return value >= left && value <= right;
        }

    }
}
