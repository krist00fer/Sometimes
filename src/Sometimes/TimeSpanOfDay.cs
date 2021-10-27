using System;

namespace Sometimes
{
    public class TimeSpanOfDay
    {
        public TimeSpan From { get; private set; }
        public TimeSpan To { get; private set; }

        public TimeSpanOfDay(TimeSpan from, TimeSpan to)
        {
            From = from.Mod24hClock();
            To = to.Mod24hClock();
        }

        public TimeSpanOfDay(int fromHours, int toHours)
            : this(TimeSpan.FromHours(fromHours), TimeSpan.FromHours(toHours))
        { }

        public TimeSpanOfDay(int fromHours, int fromMinutes, int toHours, int toMinutes)
            : this(new TimeSpan(fromHours, fromMinutes, 0), new TimeSpan(toHours, toMinutes, 0))
        { }

        public TimeSpanOfDay(int fromHours, int fromMinutes, int fromSeconds, int toHours, int toMinutes, int toSeconds)
            : this(new TimeSpan(fromHours, fromMinutes, fromSeconds), new TimeSpan(toHours, toMinutes, toSeconds))
        { }

        public bool IsWithin(TimeSpan time)
        {
            var t = time.Mod24hClock();

            if (From < To)
                return From <= t && t < To;
            else
                return
                    (From <= t && t < TimeSpan.FromHours(24)) ||
                    (TimeSpan.Zero <= t && t < To);
        }

        public bool IsWithin(int hours)
        {
            return IsWithin(TimeSpan.FromHours(hours));
        }

        public bool IsWithin(int hours, int minutes)
        {
            return IsWithin(new TimeSpan(hours, minutes, 0));
        }

        public bool IsWithin(int hours, int minutes, int seconds)
        {
            return IsWithin(new TimeSpan(hours, minutes, seconds));
        }

        public bool IsWithin(DateTime dateTime)
        {
            return IsWithin(dateTime.TimeOfDay);
        }
    }

}
