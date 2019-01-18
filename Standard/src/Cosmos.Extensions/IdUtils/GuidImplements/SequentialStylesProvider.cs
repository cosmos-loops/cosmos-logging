using System;
using System.Security.Cryptography;

namespace Cosmos.IdUtils.GuidImplements
{
    /*
     * Reference to:
     *     https://github.com/jhtodd/SequentialGuid
     *     Jeremy Todd (jhtodd)
     *     jhtodd1@gmail.com
     *
     *     Copyright @ Jeremy H. Todd 2011
     */

    internal static class SequentialStylesProvider
    {
        private static readonly RNGCryptoServiceProvider RandomGenerator = new RNGCryptoServiceProvider();

        public static Guid Create(SequentialGuidTypes type)
            => Create(DateTime.UtcNow, type);

        public static Guid Create(SequentialGuidTypes type, NoRepeatMode mode)
            => Create(mode == NoRepeatMode.On ? NoRepeatTimeStampManager.GetFactory().GetUtcTimeStamp() : DateTime.UtcNow, type);

        public static Guid Create(DateTime secureTimestamp, SequentialGuidTypes type)
        {
            byte[] randomBytes = new byte[10];
            RandomGenerator.GetBytes(randomBytes);

            long timestamp = secureTimestamp.Ticks / 1_000L;

            byte[] timestampBytes = BitConverter.GetBytes(timestamp);

            BitConverter.IsLittleEndian.IfTrue(timestampBytes.Reverse);

            byte[] guidBytes = new byte[16];

            switch (type)
            {
                case SequentialGuidTypes.SequentialAsString:
                case SequentialGuidTypes.SequentialAsBinary:
                    timestampBytes.BlockCopy(2, guidBytes, 0, 0);
                    randomBytes.BlockCopy(0, guidBytes, 6, 10);

                    if (type == SequentialGuidTypes.SequentialAsString && BitConverter.IsLittleEndian)
                    {
                        guidBytes.Reverse(0, 4);
                        guidBytes.Reverse(4, 2);
                    }

                    break;

                case SequentialGuidTypes.SequentialAsEnd:
                    randomBytes.BlockCopy(0, guidBytes, 0, 10);
                    timestampBytes.BlockCopy(2, guidBytes, 10, 6);
                    break;
            }

            return new Guid(guidBytes);
        }
    }
}