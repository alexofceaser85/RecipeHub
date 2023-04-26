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
            var service = new Mock<IPlannedMealsService>();
            service.Setup(mock => mock.RemovePlannedMeal(0));

            var viewmodel = new PlannedMealsViewModel(service.Object, new RecipesService());

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => viewmodel.RemovePlannedMeal(0));
                service.Verify(mock => mock.RemovePlannedMeal(0), Times.Once);
            });
        }
    }
}
