using System;
using Xunit;

namespace Sometimes.Tests
{
    public class TimeSpanExtensionsTests
    {
        [Fact]
        public void GenericModulusOperations()
        {
            var span1 = new TimeSpan(27, 10, 48);
            var result1 = span1.Mod(TimeSpan.FromHours(24));

            Assert.Equal(new TimeSpan(3, 10, 48), result1);

            var span2 = TimeSpan.FromMinutes(75);
            var result2 = span2.Mod(TimeSpan.FromMinutes(10));

            Assert.Equal(TimeSpan.FromMinutes(5), result2);

            var span3 = TimeSpan.FromMinutes(-75);
            var result3 = span3.Mod(TimeSpan.FromMinutes(10));

            Assert.Equal(TimeSpan.FromMinutes(-5), result3);
        }

        [Fact]
        public void Mod24h()
        {
            var span = new TimeSpan(47, 14, 17);
            var result = span.Mod24h();

            Assert.Equal(new TimeSpan(23, 14, 17), result);
        }

        [Fact]
        public void Mod24hClock()
        {
            var span = new TimeSpan(-3, 0, 0);
            var result = span.Mod24hClock();

            Assert.Equal(new TimeSpan(21, 0, 0), result);
        }


    }
}
