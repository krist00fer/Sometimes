using System;

namespace Sometimes
{
    public class PartOfDay
    {
        public TimeSpan From { get; private set; }
        public TimeSpan To { get; private set; }

        public PartOfDay(TimeSpan from, TimeSpan to)
        {
            From = from.Mod24hClock();
            To = to.Mod24hClock();
        }

        public PartOfDay(int fromHours, int toHours)
            : this(TimeSpan.FromHours(fromHours), TimeSpan.FromHours(toHours))
        { }

        public PartOfDay(int fromHours, int fromMinutes, int toHours, int toMinutes)
            : this(new TimeSpan(fromHours, fromMinutes, 0), new TimeSpan(toHours, toMinutes, 0))
        { }

        public PartOfDay(int fromHours, int fromMinutes, int fromSeconds, int toHours, int toMinutes, int toSeconds)
            : this(new TimeSpan(fromHours, fromMinutes, fromSeconds), new TimeSpan(toHours, toMinutes, toSeconds))
        { }

        public bool Includes(TimeSpan time)
        {
            var t = time.Mod24hClock();

            if (From < To)
                return From <= t && t < To;
            else
                return
                    (From <= t && t < TimeSpan.FromHours(24)) ||
                    (TimeSpan.Zero <= t && t < To);
        }

        public bool Includes(int hours)
        {
            return Includes(TimeSpan.FromHours(hours));
        }

        public bool Includes(int hours, int minutes)
        {
            return Includes(new TimeSpan(hours, minutes, 0));
        }

        public bool Includes(int hours, int minutes, int seconds)
        {
            return Includes(new TimeSpan(hours, minutes, seconds));
        }

        public bool Includes(DateTime dateTime)
        {
            return Includes(dateTime.TimeOfDay);
        }

        public bool Includes(PartOfDay earlyMorning)
        {
            if (earlyMorning.Equals(this))
                return true; // The same or equal PartOfDay is always included

            return Includes(earlyMorning.From) && Includes(earlyMorning.To);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is PartOfDay))
                return false;

            return (this.From == ((PartOfDay)obj).From) &&
                (this.To == ((PartOfDay)obj).To);
        }

        public override int GetHashCode()
        {
            return To.GetHashCode() ^ From.GetHashCode();
        }
    }
}
