using System;
using Xunit;

namespace Sometimes.Tests
{
    public class PartOfDayFluentApiTests
    {
        [Fact]
        public void FluentAPITimeStampIsDuring()
        {
            var morning = new PartOfDay(6, 10);
            var sevenOClock = new TimeSpan(7, 0, 0);

            Assert.True(sevenOClock.IsDuring(morning));
        }

        [Fact]
        public void FluentAPIIntIsDuring()
        {
            var afternoon = new PartOfDay(12, 17);
            var threeInTheAfternoon = 15;

            Assert.True(threeInTheAfternoon.IsDuring(afternoon));
        }

        [Fact]
        public void FluentAPIDateTimeIsDuring()
        {
            var lateAfternoon = new PartOfDay(15, 17);
            var dt = new DateTime(1974, 08, 26, 15, 30, 0);

            Assert.True(dt.IsDuring(lateAfternoon));
        }
    }
}
