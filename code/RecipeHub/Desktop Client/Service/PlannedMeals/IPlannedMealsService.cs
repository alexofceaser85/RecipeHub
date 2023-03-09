using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared_Resources.Model.PlannedMeals;

namespace Desktop_Client.Service.PlannedMeals
{
    public interface IPlannedMealsService
    {
        public void AddPlannedMeal(DateTime mealDate, MealCategory category, int recipeId);

        public void RemovePlannedMeal(DateTime mealDate, MealCategory category, int recipeId);

        public PlannedMeal[] GetPlannedMeals();
    }
}
