using Shared_Resources.Data.Settings;

namespace Shared_Resources.Utils.Dates
{
    /// <summary>
    /// The utils class for the dates
    /// </summary>
    public static class DateUtils
    {
        /// <summary>
        /// Generates the date times.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="dateTimeToGenerateFrom">The date time to generate from.</param>
        /// <returns>The date times from the given date to the next week</returns>
        public static DateTime[] GenerateDateTimesFromDateToNextWeek(DateTime dateTimeToGenerateFrom)
        {
            var generatedDateTimes = new List<DateTime>();
            var daysUntilEndOfWeek = (int)DayOfWeek.Saturday - (int)dateTimeToGenerateFrom.DayOfWeek;

            daysUntilEndOfWeek += DateUtilsSettings.NumberOfDaysToGenerateForWeek;

            for (var i = 0; i <= daysUntilEndOfWeek; i++)
            {
                generatedDateTimes.Add(dateTimeToGenerateFrom.AddDays(i));
            }

            return generatedDateTimes.ToArray();
        }

        /// <summary>
        /// Generates the date times from week to next week.
        ///
        /// Precondition None
        /// Postcondition: None
        /// </summary>
        /// <param name="dateTimeToGenerateFrom">The date time to generate from.</param>
        /// <returns>The date times from the week of the given date to the next week</returns>
        public static DateTime[] GenerateDateTimesFromWeekToNextWeek(DateTime dateTimeToGenerateFrom)
        {
            var generatedDateTimes = new List<DateTime>();
            var daysUntilBeginningOfWeek = (int)DayOfWeek.Sunday - (int)dateTimeToGenerateFrom.DayOfWeek;

            dateTimeToGenerateFrom = dateTimeToGenerateFrom.AddDays(daysUntilBeginningOfWeek);

            for (var i = 0; i <= DateUtilsSettings.NumberOfDaysToGenerateToNextWeek; i++)
            {
                generatedDateTimes.Add(dateTimeToGenerateFrom.AddDays(i));
            }

            return generatedDateTimes.ToArray();
        }

        /// <summary>
        /// Generates the date time for end of previous week.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="dateTimeToGenerateFrom">The date time to generate from.</param>
        /// <returns>The date time of the end of the previous week</returns>
        public static DateTime GenerateDateTimeForEndOfPreviousWeek(DateTime dateTimeToGenerateFrom)
        {
            var daysUntilEndOfLastWeek = (int)DayOfWeek.Sunday - (int)dateTimeToGenerateFrom.DayOfWeek - 1;
            dateTimeToGenerateFrom = dateTimeToGenerateFrom.AddDays(daysUntilEndOfLastWeek);
            return dateTimeToGenerateFrom;
        }
    }
}
