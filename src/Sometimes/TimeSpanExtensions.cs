using System;

namespace Sometimes
{
    public static class TimeSpanExtensions
    {
        public static TimeSpan Mod(this TimeSpan span, TimeSpan ts)
        {
            int x = (int)(span / ts);

            return span - ts * x;
        }

        public static TimeSpan Mod24h(this TimeSpan span)
        {
            return span.Mod(TimeSpan.FromHours(24));
        }

        public static TimeSpan Mod24hClock(this TimeSpan span)
        {
            var result = span.Mod24h();

            if (result < TimeSpan.Zero)
                return result + TimeSpan.FromHours(24);
            else
                return result;
        }
    }
}
