using System;
using System.Linq;
using AspectCore.Extensions.Reflection;

namespace Cosmos
{
    public static class Types
    {
        /// <summary>
        /// 获取类型，对可空类型进行处理
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        public static Type Of<T>() => Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
        
          public static Type[] Of(object[] objs)
        {
            if (objs == null)
                return null;
            if (!objs.Contains(null))
                return Type.GetTypeArray(objs);
            var types = new Type[objs.Length];
            for (var i = 0; i < objs.Length; i++)
                types[i] = objs[i].GetType();
            return types;
        }

        public static T DefaultValue<T>() => TypeDefault.Of<T>();

        public static TInstance CreateInstance<TInstance>(params object[] args)
        {
            if (args == null || args.Length == 0)
                return CreateInstanceCore<TInstance>();
            return CreateInstanceCore<TInstance>(args);
        }

        public static TInstance CreateInstance<TInstance>(Type type, params object[] args)
        {
            var instance = CreateInstance(type, args);
            return instance is TInstance ret ? ret : default(TInstance);
        }

        public static object CreateInstance(Type type, params object[] args)
        {
            if (args == null || args.Length == 0)
                return CreateInstanceCore(type);
            return CreateInstanceCore(type, args);
        }

        private static TInstance CreateInstanceCore<TInstance>()
        {
            var instance = CreateInstanceCore(typeof(TInstance));
            return instance is TInstance ret ? ret : default(TInstance);
        }

        private static TInstance CreateInstanceCore<TInstance>(object[] args)
        {
            var instance = CreateInstanceCore(typeof(TInstance), args);
            return instance is TInstance ret ? ret : default(TInstance);
        }

        private static object CreateInstanceCore(Type type)
        {
            var constructorInfo = type.GetConstructors().FirstOrDefault(x => !x.GetParameters().Any());
            return constructorInfo?.GetReflector().Invoke();
        }

        private static object CreateInstanceCore(Type type, object[] args)
        {
            var constructorInfo = type.GetConstructor(Of(args));
            return constructorInfo?.GetReflector().Invoke(args);
        }
    }
}