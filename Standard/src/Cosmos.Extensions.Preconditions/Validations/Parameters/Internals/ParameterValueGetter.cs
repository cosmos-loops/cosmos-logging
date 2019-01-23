namespace Cosmos.Validations.Parameters.Internals
{
    internal static class ParameterValueGetter
    {
        public static TValue TryTo<TValue>(this object obj)
        {
            return obj.TryTo(TypeDefault.Of<TValue>());
        }

        public static TValue TryTo<TValue>(this object obj, TValue defaultValue)
        {
            try
            {
                return (TValue) obj;
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}