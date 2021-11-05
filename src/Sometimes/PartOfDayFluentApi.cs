using System;

namespace Sometimes
{
    public static class PartOfDayFluentApi
    {
        public static bool IsDuring(this TimeSpan ts, PartOfDay part)
        {
            return part.Includes(ts);
        }

        public static bool IsDuring(this int hours, PartOfDay part)
        {
            return part.Includes(hours);
        }

        public static bool IsDuring(this DateTime dateTime, PartOfDay part)
        {
            return part.Includes(dateTime);
        }
    }
}
