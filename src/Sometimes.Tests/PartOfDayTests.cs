using System;
using Xunit;

namespace Sometimes.Tests
{
    public class PartOfDayTests
    {
        [Fact]
        public void DefineSimpleSpan()
        {
            var part = new PartOfDay(TimeSpan.FromHours(8), TimeSpan.FromHours(10));

            Assert.Equal(part.From, TimeSpan.FromHours(8));
            Assert.Equal(part.To, TimeSpan.FromHours(10));
        }

        [Fact]
        public void DefineSimpleSpanUsingOverloadedConstructors()
        {
            var earlyMorning = new PartOfDay(fromHours: 3, toHours: 6);

            Assert.Equal(earlyMorning.From, TimeSpan.FromHours(3));
            Assert.Equal(earlyMorning.To, TimeSpan.FromHours(6));

            var myWorkdayMorning = new PartOfDay(fromHours: 6, fromMinutes: 30, toHours: 9, toMinutes: 45);

            Assert.Equal(myWorkdayMorning.From, new TimeSpan(6, 30, 0));
            Assert.Equal(myWorkdayMorning.To, new TimeSpan(9, 45, 0));

            var lunch = new PartOfDay(fromHours: 11, fromMinutes: 30, fromSeconds: 1, toHours: 12, toMinutes: 45, toSeconds: 2);

            Assert.Equal(lunch.From, new TimeSpan(11, 30, 1));
            Assert.Equal(lunch.To, new TimeSpan(12, 45, 2));
        }

        [Fact]
        public void HoursCanNeverBeLaterThan24()
        {
            var midnightAndSome = new PartOfDay(TimeSpan.FromHours(22), TimeSpan.FromHours(25));

            Assert.Equal(midnightAndSome.From, TimeSpan.FromHours(22));
            Assert.Equal(midnightAndSome.To, TimeSpan.FromHours(1));
        }

        [Fact]
        public void IsWithinSpan()
        {
            var sevenToEleven = new PartOfDay(fromHours: 7, toHours: 11);

            Assert.True(sevenToEleven.IsWithin(TimeSpan.FromHours(8)));
        }

        [Fact]
        public void StartTimeShouldBeWithin()
        {
            var ninteToFive = new PartOfDay(fromHours: 9, toHours: 5);

            Assert.True(ninteToFive.IsWithin(TimeSpan.FromHours(9)));
        }

        [Fact]
        public void EndTimeShouldBeOutside()
        {
            var ninteToFive = new PartOfDay(fromHours: 9, toHours: 5);

            Assert.False(ninteToFive.IsWithin(TimeSpan.FromHours(5)));
        }

        [Fact]
        public void IsWithinSpanUsingOverloadedMethods()
        {
            var morning = new PartOfDay(fromHours: 7, toHours: 11);

            Assert.True(morning.IsWithin(8));
            Assert.True(morning.IsWithin(8, 0));
            Assert.True(morning.IsWithin(8, 0, 0));
        }

        [Fact]
        public void IsWithinSpanUsingDateTime()
        {
            var lateEvening = new PartOfDay(fromHours: 19, toHours: 23);

            Assert.True(lateEvening.IsWithin(new DateTime(2021, 10, 27, 22, 51, 55)));
        }

        [Fact]
        public void IsWithinSpanThatSpansAcrossMidnight()
        {
            var aroundMidnight = new PartOfDay(fromHours: 21, toHours: 3);

            Assert.True(aroundMidnight.IsWithin(23));
            Assert.True(aroundMidnight.IsWithin(24));
            Assert.True(aroundMidnight.IsWithin(1));
        }

        [Fact]
        public void IsWithinUsingTimeOutsideOf24Hours()
        {
            var sixPmToSixAm = new PartOfDay(18, 6);

            Assert.True(sixPmToSixAm.IsWithin(25));
        }
    }
}
