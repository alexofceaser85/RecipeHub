namespace Server.Service.PlannedMeals
{
    /// <summary>
    /// The service for the planned meals
    /// </summary>
    public interface IPlannedMealsService
    {
        /// <summary>
        /// Generates the date times.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="dateTimeToGenerateFrom">The date time to generate from.</param>
        /// <returns></returns>
        public DateTime[] GenerateDateTimes(DateTime dateTimeToGenerateFrom);
    }
}
