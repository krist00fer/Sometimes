using System;

namespace Sometimes
{
    public static class PartOfDayFluentApi
    {
        public static bool IsWithin(this TimeSpan ts, PartOfDay part)
        {
            return part.IsWithin(ts);
        }

        public static bool IsWithin(this int hours, PartOfDay part)
        {
            return part.IsWithin(hours);
        }

        public static bool IsWithin(this DateTime dateTime, PartOfDay part)
        {
            return part.IsWithin(dateTime);
        }
    }
}
