using System;
using Xunit;

namespace Sometimes.Tests
{
    public class PartOfDayFluentApiTests
    {
        [Fact]
        public void FluentAPITimeStampWithin()
        {
            var morning = new PartOfDay(6, 10);
            var sevenOClock = new TimeSpan(7, 0, 0);

            Assert.True(sevenOClock.IsWithin(morning));
        }

        [Fact]
        public void FluentAPIIntWithin()
        {
            var morning = new PartOfDay(6, 10);
            var sevenOClock = 7;

            Assert.True(sevenOClock.IsWithin(morning));
        }

        [Fact]
        public void FluentAPIDateTimeWithin()
        {
            var morning = new PartOfDay(6, 10);
            var dt = new DateTime(1974, 08, 26, 7, 0, 0);

            Assert.True(dt.IsWithin(morning));
        }
    }
}
