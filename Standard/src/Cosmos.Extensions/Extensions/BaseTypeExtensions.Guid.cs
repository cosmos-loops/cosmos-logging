using System;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class BaseTypeExtensions
    {
        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="guid"> 值 </param>
        public static bool IsNullOrEmpty(this Guid? guid) => Judgements.GuidJudgement.IsNullOrEmpty(guid);

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="guid"> 值 </param>
        public static bool IsNullOrEmpty(this Guid guid) => Judgements.GuidJudgement.IsNullOrEmpty(guid);

    }
}