using System;
using Cosmos.IdUtils.GuidImplements;

namespace Cosmos.IdUtils
{
    public static partial class GuidProvider
    {
        public static Guid Create(GuidStyle style = GuidStyle.BasicStyle, NoRepeatMode mode = NoRepeatMode.Off)
        {
            switch (style)
            {
                case GuidStyle.BasicStyle:
                    return Guid.NewGuid();

                case GuidStyle.CombStyle:
                    return TimeStampStyleProvider.Create(mode);

                case GuidStyle.TimeStampStyle:
                    return TimeStampStyleProvider.Create(mode);

                case GuidStyle.UnixTimeStampStyle:
                    return UnixTimeStampStyleProvider.Create(mode);

                case GuidStyle.LrgacySqlTimeStampStyle:
                    return mode == NoRepeatMode.On
                        ? CombImplements.InternalCombImplementProxy.LegacyWithNoRepeat.Create()
                        : CombImplements.InternalCombImplementProxy.Legacy.Create();

                case GuidStyle.SqlTimeStampStyle:
                    return mode == NoRepeatMode.On
                        ? CombImplements.InternalCombImplementProxy.MsSqlWithNoRepeat.Create()
                        : CombImplements.InternalCombImplementProxy.MsSql.Create();

                case GuidStyle.PostgreSqlTimeStampStyle:
                    return mode == NoRepeatMode.On
                        ? CombImplements.InternalCombImplementProxy.PostgreSqlWithNoRepeat.Create()
                        : CombImplements.InternalCombImplementProxy.PostgreSql.Create();

                case GuidStyle.SequentialAsStringStyle:
                    return SequentialStylesProvider.Create(SequentialGuidTypes.SequentialAsString, mode);

                case GuidStyle.SequentialAsBinaryStyle:
                    return SequentialStylesProvider.Create(SequentialGuidTypes.SequentialAsBinary, mode);

                case GuidStyle.SequentialAsEndStyle:
                    return SequentialStylesProvider.Create(SequentialGuidTypes.SequentialAsEnd, mode);

                case GuidStyle.EquifaxStyle:
                    return EquifaxStyleProvider.Create(mode);

                default:
                    return Guid.NewGuid();
            }
        }

        public static Guid Create(DateTime secureTimestamp, GuidStyle style = GuidStyle.TimeStampStyle)
        {
            switch (style)
            {
                case GuidStyle.BasicStyle:
                    return Guid.NewGuid();

                case GuidStyle.CombStyle:
                    return TimeStampStyleProvider.Create(secureTimestamp);

                case GuidStyle.TimeStampStyle:
                    return TimeStampStyleProvider.Create(secureTimestamp);

                case GuidStyle.UnixTimeStampStyle:
                    return UnixTimeStampStyleProvider.Create(secureTimestamp);

                case GuidStyle.LrgacySqlTimeStampStyle:
                    return CombImplements.InternalCombImplementProxy.Legacy.Create(secureTimestamp);

                case GuidStyle.SqlTimeStampStyle:
                    return CombImplements.InternalCombImplementProxy.MsSql.Create(secureTimestamp);

                case GuidStyle.PostgreSqlTimeStampStyle:
                    return CombImplements.InternalCombImplementProxy.PostgreSql.Create(secureTimestamp);

                case GuidStyle.SequentialAsStringStyle:
                    return SequentialStylesProvider.Create(secureTimestamp, SequentialGuidTypes.SequentialAsString);

                case GuidStyle.SequentialAsBinaryStyle:
                    return SequentialStylesProvider.Create(secureTimestamp, SequentialGuidTypes.SequentialAsBinary);

                case GuidStyle.SequentialAsEndStyle:
                    return SequentialStylesProvider.Create(secureTimestamp, SequentialGuidTypes.SequentialAsEnd);

                case GuidStyle.EquifaxStyle:
                    return EquifaxStyleProvider.Create(secureTimestamp);

                default:
                    return TimeStampStyleProvider.Create(secureTimestamp);
            }
        }
    }
}