using Desktop_Client.Service.PlannedMeals;
using Desktop_Client.Service.Recipes;
using Desktop_Client.ViewModel.PlannedMeals;
using Moq;
using Shared_Resources.Model.PlannedMeals;

namespace DesktopClientTests.DesktopClient.ViewModel.PlannedMeals.PlannedMealsViewModelTests
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
