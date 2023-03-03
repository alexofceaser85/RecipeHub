using Shared_Resources.Data.Settings;

namespace Server.Service.PlannedMeals
{
    /// <summary>
    /// The service for the planned meals
    /// </summary>
    public class PlannedMealsService : IPlannedMealsService
    {
        /// <summary>
        /// Generates the date times.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="dateTimeToGenerateFrom">The date time to generate from.</param>
        /// <returns></returns>
        public DateTime[] GenerateDateTimes(DateTime dateTimeToGenerateFrom)
        {
            var generatedDateTimes = new List<DateTime>();
            int daysUntilEndOfWeek = (int)DayOfWeek.Saturday - (int)dateTimeToGenerateFrom.DayOfWeek;

            daysUntilEndOfWeek += PlannedMealSettings.NumberOfDaysToGenerate;

            for (var i = 0; i <= daysUntilEndOfWeek; i++)
            {
                generatedDateTimes.Add(dateTimeToGenerateFrom.AddDays(i));
            }

            return generatedDateTimes.ToArray();
        }
    }
}
