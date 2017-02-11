namespace Cosmos.Helpers
{
    /// <summary>
    /// Object convert helper
    /// </summary>
    public static class ObjectConvertHelper
    {
        /// <summary>
        /// Convert from an object to string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToString(object obj)
        {
            return obj?.ToString() ?? string.Empty;
        }
    }
}
