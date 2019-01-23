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

    internal class SqlDateTimeStrategy : IDateStrategy
    {
        private const double TicksPerDay = 86_400d * 300d;
        private const double TicksPerMillisecond = 3d / 10d;

        public int NumDateBytes { get; } = 6;

        public DateTime MinDateTimeValue { get; } = new DateTime(1900, 1, 1);

        public DateTime MaxDateTimeValue => MinDateTimeValue.AddDays(NumberConstants.UshortMax);

        public byte[] DateTimeToBytes(DateTime timestamp)
        {
            var ticks = (int) (timestamp.TimeOfDay.TotalMilliseconds * TicksPerMillisecond);
            var days = (ushort) (timestamp - MinDateTimeValue).TotalDays;
            var tickBytes = BitConverter.GetBytes(ticks);
            var dayBytes = BitConverter.GetBytes(days);

            if (BitConverter.IsLittleEndian)
            {
                dayBytes.Reverse();
                tickBytes.Reverse();
            }

            var ret = new byte[NumDateBytes];
            dayBytes.Copy(0, ret, 0, 2);
            tickBytes.Copy(0, ret, 2, 4);

            return ret;
        }

        public DateTime BytesToDateTime(byte[] value)
        {
            var dayBytes = new byte[2];
            var tickBytes = new byte[4];
            value.Copy(0, dayBytes, 0, 2);
            value.Copy(2, tickBytes, 0, 4);

            if (BitConverter.IsLittleEndian)
            {
                dayBytes.Reverse();
                tickBytes.Reverse();
            }

            var days = BitConverter.ToUInt16(dayBytes, 0);
            var ticks = BitConverter.ToInt32(tickBytes, 0);

            if (ticks < 0f)
            {
                throw new ArgumentException("Not a COMB, time component is negative.");
            }
            else if (ticks > TicksPerDay)
            {
                throw new ArgumentException("Not a COMB, time component exceeds 24 hours.");
            }

            return MinDateTimeValue.AddDays(days).AddMilliseconds((double) ticks / TicksPerMillisecond);
        }
    }
}