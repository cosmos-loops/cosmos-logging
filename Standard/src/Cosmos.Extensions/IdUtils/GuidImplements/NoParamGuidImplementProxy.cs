using System;

namespace Cosmos.IdUtils.GuidImplements
{
    internal static class NoParamGuidImplementProxy
    {
        public static Guid Basic() => GuidProvider.Create(GuidStyle.BasicStyle);

        public static Guid SequentialAsString() => GuidProvider.Create(GuidStyle.SequentialAsStringStyle);

        public static Guid SequentialAsBinary() => GuidProvider.Create(GuidStyle.SequentialAsBinaryStyle);

        public static Guid SequentialAsEnd() => GuidProvider.Create(GuidStyle.SequentialAsEndStyle);

        public static Guid Equifax() => GuidProvider.Create(GuidStyle.EquifaxStyle);
    }
}