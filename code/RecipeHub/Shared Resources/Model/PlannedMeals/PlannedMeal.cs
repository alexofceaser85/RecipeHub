using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Shared_Resources.Model.PlannedMeals
{
    /// <summary>
    /// Represents a days worth of planned meals.
    /// </summary>
    public struct PlannedMeal
    {
        /// <summary>
        /// Gets or sets the meal date.
        /// </summary>
        /// <value>
        /// The meal date.
        /// </value>
        [JsonPropertyName("mealDate")]
        public DateTime MealDate { get; set; }

        /// <summary>
        /// Gets or sets the meals.
        /// </summary>
        /// <value>
        /// The meals.
        /// </value>
        [JsonPropertyName("meals")]
        public MealsForCategory[] Meals { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlannedMeal"/> class.<br />
        /// <br />
        /// Precondition: meals != null<br />
        /// Postcondition: MealDate == mealDate &amp;&amp; Meals == meals<br />
        /// </summary>
        /// <param name="mealDate">The meal date.</param>
        /// <param name="meals">The meals.</param>
        /// <exception cref="ArgumentNullException">meals</exception>
        public PlannedMeal(DateTime mealDate, MealsForCategory[] meals)
        {
            this.MealDate = mealDate;
            this.Meals = meals ?? throw new ArgumentNullException(nameof(meals));
        }
    }
}
