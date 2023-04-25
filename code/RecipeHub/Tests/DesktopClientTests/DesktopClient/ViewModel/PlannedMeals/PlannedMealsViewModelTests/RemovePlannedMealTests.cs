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
            var service = new Mock<IPlannedMealsService>();
            service.Setup(mock => mock.RemovePlannedMeal(0));

            var viewmodel = new PlannedMealsViewModel(service.Object, new RecipesService());

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => viewmodel.RemovePlannedMeal(0));
                service.Verify(mock => mock.RemovePlannedMeal(0), Times.Once);
            });
        }

        [Test]
        public void UnsuccessfullyRemovePlannedMeal()
        {
            const string errorMessage = "error message";

            var service = new Mock<IPlannedMealsService>();
            service.Setup(mock => mock.RemovePlannedMeal(0))
                   .Throws(new Exception(errorMessage));

            var viewmodel = new PlannedMealsViewModel(service.Object, new RecipesService());

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<Exception>(() => viewmodel.RemovePlannedMeal(0))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                service.Verify(mock => mock.RemovePlannedMeal(0), Times.Once);
            });
        }

        [Test]
        public void InvalidSessionKey()
        {
            const string errorMessage = "error message";

            var service = new Mock<IPlannedMealsService>();
            service.Setup(mock => mock.RemovePlannedMeal(0))
                   .Throws(new UnauthorizedAccessException(errorMessage));

            var viewmodel = new PlannedMealsViewModel(service.Object, new RecipesService());

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<UnauthorizedAccessException>(() => viewmodel.RemovePlannedMeal(0))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                service.Verify(mock => mock.RemovePlannedMeal(0), Times.Once);
            });
        }
    }
}
