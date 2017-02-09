using System;
using System.Collections.Generic;

namespace Cosmos.Helpers
{
    /// <summary>
    /// Singleton Helper
    /// </summary>
    public static class SingletonHelper
    {
        /// <summary>
        /// Get singleton object.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object GetSingleton(Type type)
        {
            return Singleton.AllSingletons[type];
        }

        /// <summary>
        /// Get singleton object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetSingleton<T>()
        {
            return Singleton<T>.Instance;
        }

        /// <summary>
        /// Set singleton object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public static void SetSingleton<T>(T t)
        {
            Singleton<T>.Instance = t;
        }

        /// <summary>
        /// Get singleton object list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IList<T> GetSingletonList<T>()
        {
            return Singleton<IList<T>>.Instance;
        }

        /// <summary>
        /// Set singleton object list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tlist"></param>
        public static void SetSingletonList<T>(IList<T> tlist)
        {
            Singleton<IList<T>>.Instance = tlist;
        }

        /// <summary>
        /// Get singleton object dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static IDictionary<TKey, TValue> GetSingletonDictionary<TKey, TValue>()
        {
            return Singleton<IDictionary<TKey, TValue>>.Instance;
        }

        /// <summary>
        /// Set singleton object dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="tdict"></param>
        public static void SetSingletonDictionary<TKey, TValue>(IDictionary<TKey, TValue> tdict)
        {
            Singleton<IDictionary<TKey, TValue>>.Instance = tdict;
        }

        static class Singleton
        {
            static Singleton()
            {
                AllSingletons = new Dictionary<Type, object>();
            }

            public static IDictionary<Type, object> AllSingletons { get; }
        }

        static class Singleton<T>
        {
            private static T _instance;

            public static T Instance
            {
                get { return _instance; }
                set
                {
                    _instance = value;
                    Singleton.AllSingletons[typeof(T)] = value;
                }
            }
        }
    }
}
