using Shared_Resources.Model.PlannedMeals;

namespace Desktop_Client.Endpoints.PlannedMeals
{
    public interface IPlannedMealsEndpoints
    {
        public void AddPlannedMeal(DateTime mealDate, MealCategory category, int recipeId);

        public void RemovePlannedMeal(DateTime mealDate, MealCategory category, int recipeId);

        public PlannedMeal[] GetPlannedMeals();
    }
}
