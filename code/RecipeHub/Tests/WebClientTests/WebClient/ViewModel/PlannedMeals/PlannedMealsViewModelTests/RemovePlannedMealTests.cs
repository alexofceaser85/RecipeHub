using Moq;
using Shared_Resources.Model.PlannedMeals;
using Web_Client.Service.PlannedMeals;
using Web_Client.Service.Recipes;
using Web_Client.ViewModel.PlannedMeals;

namespace WebClientTests.WebClient.ViewModel.PlannedMeals.PlannedMealsViewModelTests
{
    internal class RemovePlannedMealTests
    {
        [Test]
        public void SuccessfullyRemovePlannedMeal()
        {
            var mealDate = new DateTime(2000, 1, 1);
            const MealCategory category = MealCategory.Breakfast;
            const int recipeId = 0;

            var service = new Mock<IPlannedMealsService>();
            service.Setup(mock => mock.RemovePlannedMeal(mealDate, category, recipeId));

            var viewmodel = new PlannedMealsViewModel(service.Object, new RecipesService());

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => viewmodel.RemovePlannedMeal(mealDate, category, recipeId));
                service.Verify(mock => mock.RemovePlannedMeal(mealDate, category, recipeId), Times.Once);
            });
        }
    }
}
