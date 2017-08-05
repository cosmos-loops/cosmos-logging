using System;
using System.Collections.Generic;

namespace Cosmos
{
    /// <summary>
    /// 提供一个统一的单例管理入口
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class Singleton
    {
        static Singleton()
        {
            AllSingletons = new Dictionary<Type, object>();
        }

        /// <summary>
        /// 所有单例对象
        /// </summary>
        public static IDictionary<Type, object> AllSingletons { get; }
    }

    /// <summary>
    /// 提供一个统一的单例管理入口，同时自身亦是一份副本
    /// </summary>
    /// <typeparam name="T"></typeparam>
    // ReSharper disable once InconsistentNaming
    public class Singleton<T> : Singleton
    {
        private static T _instance;

        /// <summary>
        /// 单例实例
        /// </summary>
        public static T Instance
        {
            get => _instance;
            set
            {
                _instance = value;
                AllSingletons[typeof(T)] = value;
            }
        }
    }

    /// <summary>
    /// 提供一个统一的单例管理入口，同时自身亦是一份副本
    /// </summary>
    /// <typeparam name="T"></typeparam>
    // ReSharper disable once InconsistentNaming
    public class SingletonList<T> : Singleton<IList<T>>
    {
        static SingletonList()
        {
            Singleton<IList<T>>.Instance = new List<T>();
        }

        /// <summary>
        /// 获得一个指定类型 T 的单例
        /// </summary>
        public new static IList<T> Instance => Singleton<IList<T>>.Instance;
    }

    /// <summary>
    /// 提供一个统一的单例管理入口，同时自身亦是一份副本
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    // ReSharper disable once InconsistentNaming
    public class SingletonDictionary<TKey, TValue> : Singleton<IDictionary<TKey, TValue>>
    {
        static SingletonDictionary()
        {
            Singleton<Dictionary<TKey, TValue>>.Instance = new Dictionary<TKey, TValue>();
        }

        /// <summary>
        /// 获得一个指定类型 T 的单例
        /// </summary>
        public new static IDictionary<TKey, TValue> Instance => Singleton<Dictionary<TKey, TValue>>.Instance;
    }
}
