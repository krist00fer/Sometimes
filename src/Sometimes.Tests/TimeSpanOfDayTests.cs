using System;
using Xunit;

namespace Sometimes.Tests
{
    public class TimeSpanOfDayTests
    {
        [Fact]
        public void DefineSimpleSpan()
        {
            var ts = new TimeSpanOfDay(TimeSpan.FromHours(8), TimeSpan.FromHours(10));

            Assert.Equal(ts.From, TimeSpan.FromHours(8));
            Assert.Equal(ts.To, TimeSpan.FromHours(10));
        }

        [Fact]
        public void DefineSimpleSpanUsingOverloadedConstructors()
        {
            var ts1 = new TimeSpanOfDay(fromHours: 3, toHours: 6);

            Assert.Equal(ts1.From, TimeSpan.FromHours(3));
            Assert.Equal(ts1.To, TimeSpan.FromHours(6));

            var ts2 = new TimeSpanOfDay(fromHours: 3, fromMinutes: 30, toHours: 6, toMinutes: 45);

            Assert.Equal(ts2.From, new TimeSpan(3, 30, 0));
            Assert.Equal(ts2.To, new TimeSpan(6, 45, 0));

            var ts3 = new TimeSpanOfDay(fromHours: 3, fromMinutes: 30, fromSeconds: 15, toHours: 6, toMinutes: 45, toSeconds: 30);

            Assert.Equal(ts3.From, new TimeSpan(3, 30, 15));
            Assert.Equal(ts3.To, new TimeSpan(6, 45, 30));
        }

        [Fact]
        public void HoursCanNeverBeLaterThan24()
        {
            var ts = new TimeSpanOfDay(TimeSpan.FromHours(22), TimeSpan.FromHours(25));

            Assert.Equal(ts.From, TimeSpan.FromHours(22));
            Assert.Equal(ts.To, TimeSpan.FromHours(1));
        }

        [Fact]
        public void IsWithinSpan()
        {
            var ts = new TimeSpanOfDay(fromHours: 7, toHours: 11);

            Assert.True(ts.IsWithin(TimeSpan.FromHours(8)));
        }

        [Fact]
        public void IsWithinSpanFromShouldBeWithin()
        {
            var ts = new TimeSpanOfDay(fromHours: 7, toHours: 11);

            Assert.True(ts.IsWithin(TimeSpan.FromHours(7)));
        }

        [Fact]
        public void IsWithinSpanToShouldBeOutside()
        {
            var ts = new TimeSpanOfDay(fromHours: 7, toHours: 11);

            Assert.False(ts.IsWithin(TimeSpan.FromHours(11)));
        }

        [Fact]
        public void IsWithinSpanUsingOverloadedMethods()
        {
            var ts = new TimeSpanOfDay(fromHours: 7, toHours: 11);

            Assert.True(ts.IsWithin(8));
            Assert.True(ts.IsWithin(8, 0));
            Assert.True(ts.IsWithin(8, 0, 0));

        }

        [Fact]
        public void IsWithinSpanUsingDateTime()
        {
            var ts = new TimeSpanOfDay(fromHours: 19, toHours: 23);

            Assert.True(ts.IsWithin(new DateTime(2021, 10, 27, 22, 51, 55)));
        }

        [Fact]
        public void IsWithinSpanThatSpansAcrossMidnight()
        {
            var ts = new TimeSpanOfDay(fromHours: 21, toHours: 3);

            Assert.True(ts.IsWithin(23));
            Assert.True(ts.IsWithin(24));
            Assert.True(ts.IsWithin(1));
        }

        [Fact]
        public void IsWithinUsingTimeOutsideOf24Hours()
        {
            var ts = new TimeSpanOfDay(18, 6);

            Assert.True(ts.IsWithin(25));
        }
    }
}
