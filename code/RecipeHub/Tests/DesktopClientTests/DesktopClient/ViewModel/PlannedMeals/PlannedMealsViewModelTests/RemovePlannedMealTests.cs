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

        [Test]
        public void UnsuccessfullyRemovePlannedMeal()
        {
            const string errorMessage = "error message";
            var mealDate = new DateTime(2000, 1, 1);
            const MealCategory category = MealCategory.Breakfast;
            const int recipeId = 0;

            var service = new Mock<IPlannedMealsService>();
            service.Setup(mock => mock.RemovePlannedMeal(mealDate, category, recipeId))
                   .Throws(new Exception(errorMessage));

            var viewmodel = new PlannedMealsViewModel(service.Object, new RecipesService());

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<Exception>(() => viewmodel.RemovePlannedMeal(mealDate, category, recipeId))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                service.Verify(mock => mock.RemovePlannedMeal(mealDate, category, recipeId), Times.Once);
            });
        }

        [Test]
        public void InvalidSessionKey()
        {
            const string errorMessage = "error message";
            var mealDate = new DateTime(2000, 1, 1);
            const MealCategory category = MealCategory.Breakfast;
            const int recipeId = 0;

            var service = new Mock<IPlannedMealsService>();
            service.Setup(mock => mock.RemovePlannedMeal(mealDate, category, recipeId))
                   .Throws(new UnauthorizedAccessException(errorMessage));

            var viewmodel = new PlannedMealsViewModel(service.Object, new RecipesService());

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<UnauthorizedAccessException>(() => viewmodel.RemovePlannedMeal(mealDate, category, recipeId))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                service.Verify(mock => mock.RemovePlannedMeal(mealDate, category, recipeId), Times.Once);
            });
        }
    }
}
