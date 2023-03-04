using Shared_Resources.Utils.Dates;

namespace SharedResourcesTests.SharedResources.Utils.Dates.DateUtilsTests
{
    public class GenerateDateTimeForEndOfPreviousWeekTests
    {
        [Test]
        public void ShouldGenerateDateTimeForEndOfPreviousWeekInStartOfWeek()
        {
            var expected = new DateTime(2023, 03, 11);
            var actual = DateUtils.GenerateDateTimeForEndOfPreviousWeek(new DateTime(2023, 03, 12));
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldGenerateDateTimeForEndOfPreviousWeekInMiddleOfWeek()
        {
            var expected = new DateTime(2023, 03, 11);
            var actual = DateUtils.GenerateDateTimeForEndOfPreviousWeek(new DateTime(2023, 03, 15));
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldGenerateDateTimeForEndOfPreviousWeekInEndOfWeek()
        {
            var expected = new DateTime(2023, 03, 11);
            var actual = DateUtils.GenerateDateTimeForEndOfPreviousWeek(new DateTime(2023, 03, 18));
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldGenerateDateTimeForEndOfPreviousWeekInStartOfMonth()
        {
            var expected = new DateTime(2023, 02, 25);
            var actual = DateUtils.GenerateDateTimeForEndOfPreviousWeek(new DateTime(2023, 03, 03));
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldGenerateDateTimeForEndOfPreviousWeekInMiddleOfMonth()
        {
            var expected = new DateTime(2023, 03, 11);
            var actual = DateUtils.GenerateDateTimeForEndOfPreviousWeek(new DateTime(2023, 03, 16));
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldGenerateDateTimeForEndOfPreviousWeekInEndOfMonth()
        {
            var expected = new DateTime(2023, 03, 25);
            var actual = DateUtils.GenerateDateTimeForEndOfPreviousWeek(new DateTime(2023, 03, 31));
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
