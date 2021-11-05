using System;
using Xunit;

namespace Sometimes.Tests
{
    public class PartOfDayTests
    {
        [Fact]
        public void DefineSimpleSpan()
        {
            var eight = TimeSpan.FromHours(8);
            var ten = TimeSpan.FromHours(10);

            var part = new PartOfDay(eight, ten);

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
        public void IncludesSpan()
        {
            var sevenToEleven = new PartOfDay(fromHours: 7, toHours: 11);

            TimeSpan eight = TimeSpan.FromHours(8);
            Assert.True(sevenToEleven.Includes(eight));
        }

        [Fact]
        public void StartTimeShouldBeIncluded()
        {
            var ninteToFive = new PartOfDay(fromHours: 9, toHours: 5);

            Assert.True(ninteToFive.Includes(TimeSpan.FromHours(9)));
        }

        [Fact]
        public void EndTimeShouldNotBeIncluded()
        {
            var ninteToFive = new PartOfDay(fromHours: 9, toHours: 5);

            Assert.False(ninteToFive.Includes(TimeSpan.FromHours(5)));
        }

        [Fact]
        public void IncludesUsingOverloadedMethods()
        {
            var morning = new PartOfDay(fromHours: 7, toHours: 11);

            Assert.True(morning.Includes(8));
            Assert.True(morning.Includes(8, 0));
            Assert.True(morning.Includes(8, 0, 0));
        }

        [Fact]
        public void IncludesUsingDateTime()
        {
            var lateEvening = new PartOfDay(fromHours: 19, toHours: 23);

            Assert.True(lateEvening.Includes(new DateTime(2021, 10, 27, 22, 51, 55)));
            Assert.False(lateEvening.Includes(new DateTime(2021, 12, 5, 1, 2, 3)));
        }

        [Fact]
        public void IncludesUsingPartOfDay()
        {
            var morning = new PartOfDay(6, 10);
            var earlyMorning = new PartOfDay(6, 8);
            var afternoon = new PartOfDay(12, 17);

            Assert.True(morning.Includes(earlyMorning));
            Assert.False(morning.Includes(afternoon));
        }

        [Fact]
        public void IncludesSelf()
        {
            var goldenHour = new PartOfDay(17, 19);

            Assert.True(goldenHour.Includes(goldenHour));
        }

        [Fact]
        public void ShouldNotIncludePartsThatOnlySomewhatAreIncluded()
        {
            var firstHalfOfDay = new PartOfDay(0, 12);
            var hoursAroundNoon = new PartOfDay(11, 13);

            Assert.False(firstHalfOfDay.Includes(hoursAroundNoon));
        }

        [Fact]
        public void IncludesWithPartsAcrossMidnight()
        {
            var aroundMidnight = new PartOfDay(fromHours: 21, toHours: 3);

            Assert.True(aroundMidnight.Includes(23));
            Assert.True(aroundMidnight.Includes(24));
            Assert.True(aroundMidnight.Includes(1));
        }

        [Fact]
        public void IncludesUsingTimeOutsideOf24Hours()
        {
            var sixPmToSixAm = new PartOfDay(18, 6);

            Assert.True(sixPmToSixAm.Includes(25));
        }
    }
}
