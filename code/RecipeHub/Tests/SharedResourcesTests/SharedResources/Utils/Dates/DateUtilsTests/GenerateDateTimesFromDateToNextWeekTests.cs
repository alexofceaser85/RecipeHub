using Shared_Resources.Utils.Dates;

namespace SharedResourcesTests.SharedResources.Utils.Dates.DateUtilsTests
{
    public class GenerateDateTimesFromDateToNextWeekTests
    {
        [Test]
        public void ShouldGenerateDateTimesForBeginningOfWeek()
        {
            var currentDate = new DateTime(2023, 03, 05);
            var expectedDates = new DateTime[]
            {
                new DateTime(2023, 03, 05),
                new DateTime(2023, 03, 06),
                new DateTime(2023, 03, 07),
                new DateTime(2023, 03, 08),
                new DateTime(2023, 03, 09),
                new DateTime(2023, 03, 10),
                new DateTime(2023, 03, 11),
                new DateTime(2023, 03, 12),
                new DateTime(2023, 03, 13),
                new DateTime(2023, 03, 14),
                new DateTime(2023, 03, 15),
                new DateTime(2023, 03, 16),
                new DateTime(2023, 03, 17),
                new DateTime(2023, 03, 18)
            };

            var actualDates = DateUtils.GenerateDateTimesFromDateToNextWeek(currentDate);
            Assert.That(actualDates, Is.EqualTo(expectedDates));
        }

        [Test]
        public void ShouldGenerateDateTimesForEndOfWeek()
        {
            var currentDate = new DateTime(2023, 03, 04);
            var expectedDates = new DateTime[]
            {
                new DateTime(2023, 03, 04),
                new DateTime(2023, 03, 05),
                new DateTime(2023, 03, 06),
                new DateTime(2023, 03, 07),
                new DateTime(2023, 03, 08),
                new DateTime(2023, 03, 09),
                new DateTime(2023, 03, 10),
                new DateTime(2023, 03, 11)
            };

            var actualDates = DateUtils.GenerateDateTimesFromDateToNextWeek(currentDate);
            Assert.That(actualDates, Is.EqualTo(expectedDates));
        }

        [Test]
        public void ShouldGenerateDateTimesForMiddleOfWeek()
        {
            var currentDate = new DateTime(2023, 03, 01);
            var expectedDates = new DateTime[]
            {
                new DateTime(2023, 03, 01),
                new DateTime(2023, 03, 02),
                new DateTime(2023, 03, 03),
                new DateTime(2023, 03, 04),
                new DateTime(2023, 03, 05),
                new DateTime(2023, 03, 06),
                new DateTime(2023, 03, 07),
                new DateTime(2023, 03, 08),
                new DateTime(2023, 03, 09),
                new DateTime(2023, 03, 10),
                new DateTime(2023, 03, 11)
            };

            var actualDates = DateUtils.GenerateDateTimesFromDateToNextWeek(currentDate);
            Assert.That(actualDates, Is.EqualTo(expectedDates));
        }

        [Test]
        public void ShouldGenerateDateTimesForEndOfMonth()
        {
            var currentDate = new DateTime(2023, 02, 26);
            var expectedDates = new DateTime[]
            {
                new DateTime(2023, 02, 26),
                new DateTime(2023, 02, 27),
                new DateTime(2023, 02, 28),
                new DateTime(2023, 03, 01),
                new DateTime(2023, 03, 02),
                new DateTime(2023, 03, 03),
                new DateTime(2023, 03, 04),
                new DateTime(2023, 03, 05),
                new DateTime(2023, 03, 06),
                new DateTime(2023, 03, 07),
                new DateTime(2023, 03, 08),
                new DateTime(2023, 03, 09),
                new DateTime(2023, 03, 10),
                new DateTime(2023, 03, 11)
            };

            var actualDates = DateUtils.GenerateDateTimesFromDateToNextWeek(currentDate);
            Assert.That(actualDates, Is.EqualTo(expectedDates));
        }

        [Test]
        public void ShouldGenerateDateTimesForEndOfYear()
        {
            var currentDate = new DateTime(2022, 12, 26);
            var expectedDates = new DateTime[]
            {
                new DateTime(2022, 12, 26),
                new DateTime(2022, 12, 27),
                new DateTime(2022, 12, 28),
                new DateTime(2022, 12, 29),
                new DateTime(2022, 12, 30),
                new DateTime(2022, 12, 31),
                new DateTime(2023, 01, 01),
                new DateTime(2023, 01, 02),
                new DateTime(2023, 01, 03),
                new DateTime(2023, 01, 04),
                new DateTime(2023, 01, 05),
                new DateTime(2023, 01, 06),
                new DateTime(2023, 01, 07)
            };

            var actualDates = DateUtils.GenerateDateTimesFromDateToNextWeek(currentDate);
            Assert.That(actualDates, Is.EqualTo(expectedDates));
        }
    }
}
