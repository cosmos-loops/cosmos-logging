using System;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class BaseTypeExtensions
    {
        public static T As<T>(this object @this)
        {
            return (T) @this;
        }

        public static T AsOrDefault<T>(this object @this)
        {
            try
            {
                return (T) @this;
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public static T AsOrDefault<T>(this object @this, T defaultValue)
        {
            try
            {
                return (T) @this;
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        public static T AsOrDefault<T>(this object @this, Func<T> defaultValueFactory)
        {
            try
            {
                return (T) @this;
            }
            catch (Exception)
            {
                return defaultValueFactory();
            }
        }

        public static T AsOrDefault<T>(this object @this, Func<object, T> defaultValueFactory)
        {
            try
            {
                return (T) @this;
            }
            catch (Exception)
            {
                return defaultValueFactory(@this);
            }
        }
    }
}