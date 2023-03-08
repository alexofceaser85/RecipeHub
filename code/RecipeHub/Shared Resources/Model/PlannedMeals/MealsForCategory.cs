using System;
using System.Collections.Generic;
using System.Text;
using Shared_Resources.Model.Recipes;

namespace Shared_Resources.Model.PlannedMeals
{
    /// <summary>
    /// Recipes for a certain category of meals.
    /// </summary>
    public struct MealsForCategory
    {
        /// <summary>
        /// Gets or sets the category of the meal.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public MealCategory Category { get; set; }

        /// <summary>
        /// Gets or sets the recipes.
        /// </summary>
        /// <value>
        /// The recipes.
        /// </value>
        public Recipe[] Recipes { get; set;}

        /// <summary>
        /// Initializes a new instance of the <see cref="MealsForCategory"/> class.<br />
        /// <br />
        /// Precondition: recipes != null<br />
        /// Postcondition: Category == category &amp;&amp; Recipes == recipes<br />
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="recipes">The recipes.</param>
        /// <exception cref="ArgumentNullException">recipes</exception>
        public MealsForCategory(MealCategory category, Recipe[] recipes)
        {
            this.Recipes = recipes ?? throw new ArgumentNullException(nameof(recipes));
            this.Category = category;
        }
    }
}
