using System;
using Cosmos.IdUtils.GuidImplements;

namespace Cosmos.IdUtils
{
    public static partial class GuidProvider
    {
        public static Guid Create(CombStyle style, NoRepeatMode mode = NoRepeatMode.Off)
        {
            switch (style)
            {
                case CombStyle.NormalStyle:
                    return TimeStampStyleProvider.Create(mode);

                case CombStyle.UnixStyle:
                    return UnixTimeStampStyleProvider.Create(mode);

                case CombStyle.SqlStyle:
                    return mode == NoRepeatMode.On
                        ? CombImplements.InternalCombImplementProxy.MsSqlWithNoRepeat.Create()
                        : CombImplements.InternalCombImplementProxy.MsSql.Create();

                case CombStyle.LrgacySqlStyle:
                    return mode == NoRepeatMode.On
                        ? CombImplements.InternalCombImplementProxy.LegacyWithNoRepeat.Create()
                        : CombImplements.InternalCombImplementProxy.Legacy.Create();

                case CombStyle.PostgreSqlStyle:
                    return mode == NoRepeatMode.On
                        ? CombImplements.InternalCombImplementProxy.PostgreSqlWithNoRepeat.Create()
                        : CombImplements.InternalCombImplementProxy.PostgreSql.Create();

                default:
                    return TimeStampStyleProvider.Create(mode);
            }
        }

        public static Guid Create(Guid value, CombStyle style, NoRepeatMode mode = NoRepeatMode.Off)
        {
            switch (style)
            {
                case CombStyle.NormalStyle:
                    return TimeStampStyleProvider.Create(value, mode);

                case CombStyle.UnixStyle:
                    return UnixTimeStampStyleProvider.Create(value, mode);

                case CombStyle.SqlStyle:
                    return mode == NoRepeatMode.On
                        ? CombImplements.InternalCombImplementProxy.MsSqlWithNoRepeat.Create(value)
                        : CombImplements.InternalCombImplementProxy.MsSql.Create(value);

                case CombStyle.LrgacySqlStyle:
                    return mode == NoRepeatMode.On
                        ? CombImplements.InternalCombImplementProxy.LegacyWithNoRepeat.Create(value)
                        : CombImplements.InternalCombImplementProxy.Legacy.Create(value);

                case CombStyle.PostgreSqlStyle:
                    return mode == NoRepeatMode.On
                        ? CombImplements.InternalCombImplementProxy.PostgreSqlWithNoRepeat.Create(value)
                        : CombImplements.InternalCombImplementProxy.PostgreSql.Create(value);

                default:
                    return TimeStampStyleProvider.Create(value, mode);
            }
        }

        public static Guid Create(DateTime secureTimestamp, CombStyle style)
        {
            switch (style)
            {
                case CombStyle.NormalStyle:
                    return TimeStampStyleProvider.Create(secureTimestamp);

                case CombStyle.UnixStyle:
                    return UnixTimeStampStyleProvider.Create(secureTimestamp);

                case CombStyle.SqlStyle:
                    return CombImplements.InternalCombImplementProxy.MsSql.Create(secureTimestamp);

                case CombStyle.LrgacySqlStyle:
                    return CombImplements.InternalCombImplementProxy.Legacy.Create(secureTimestamp);

                case CombStyle.PostgreSqlStyle:
                    return CombImplements.InternalCombImplementProxy.PostgreSql.Create(secureTimestamp);

                default:
                    return TimeStampStyleProvider.Create(secureTimestamp);
            }
        }

        public static Guid Create(Guid value, DateTime secureTimestamp, CombStyle style)
        {
            switch (style)
            {
                case CombStyle.NormalStyle:
                    return TimeStampStyleProvider.Create(value, secureTimestamp);

                case CombStyle.UnixStyle:
                    return UnixTimeStampStyleProvider.Create(value, secureTimestamp);

                case CombStyle.SqlStyle:
                    return CombImplements.InternalCombImplementProxy.MsSql.Create(value, secureTimestamp);

                case CombStyle.LrgacySqlStyle:
                    return CombImplements.InternalCombImplementProxy.Legacy.Create(value, secureTimestamp);

                case CombStyle.PostgreSqlStyle:
                    return CombImplements.InternalCombImplementProxy.PostgreSql.Create(value, secureTimestamp);

                default:
                    return TimeStampStyleProvider.Create(value, secureTimestamp);
            }
        }
    }
}