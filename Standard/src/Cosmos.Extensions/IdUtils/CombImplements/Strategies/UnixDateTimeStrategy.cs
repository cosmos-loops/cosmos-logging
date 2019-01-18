using System;

/*
	Copyright 2015-2017 Richard S. Tallent, II
	
	Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files
	(the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge,
	publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to
	do so, subject to the following conditions:
	
	The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
	
	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
	MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
	LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
	CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

namespace Cosmos.IdUtils.CombImplements.Strategies
{
    /*
     * Reference To
     *     http://github.com/richardtallent/RT.Comb
     *     Richard Tallent (richardtallent)
     *         @ERM
     *     https://www.tallent.us
     */

    internal class UnixDateTimeStrategy : IDateStrategy
    {
        private const long TicksPerMillisecond = 10_000;
        public int NumDateBytes { get; } = 6;

        public DateTime MinDateTimeValue { get; } = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public DateTime MaxDateTimeValue => MinDateTimeValue.AddMilliseconds(2 ^ (8 * NumDateBytes));

        public byte[] DateTimeToBytes(DateTime timestamp)
        {
            var ms = ToUnixTmeMillseconds(timestamp);
            var msBytes = BitConverter.GetBytes(ms);

            BitConverter.IsLittleEndian.IfTrue(msBytes.Reverse);

            var ret = new byte[NumDateBytes];
            var index = msBytes.GetUpperBound(0) + 1 - NumDateBytes;

            msBytes.Copy(index, ret, 0, NumDateBytes);

            return ret;
        }

        public DateTime BytesToDateTime(byte[] value)
        {
            var msBytes = new byte[8];
            var index = 8 - NumDateBytes;

            value.Copy(0, msBytes, index, NumDateBytes);

            BitConverter.IsLittleEndian.IfTrue(msBytes.Reverse);

            var ms = BitConverter.ToInt64(msBytes, 0);

            return FromUnixTimeMillseconds(ms);
        }

        private long ToUnixTmeMillseconds(DateTime timestamp) => (timestamp.Ticks - MinDateTimeValue.Ticks) / TicksPerMillisecond;

        private DateTime FromUnixTimeMillseconds(long ms) => MinDateTimeValue.AddTicks(ms * TicksPerMillisecond);
    }
}