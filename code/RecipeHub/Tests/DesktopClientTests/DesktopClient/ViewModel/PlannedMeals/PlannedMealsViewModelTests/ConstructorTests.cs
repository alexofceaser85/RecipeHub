using Desktop_Client.Service.PlannedMeals;
using Desktop_Client.Service.Recipes;
using Desktop_Client.ViewModel.PlannedMeals;

namespace DesktopClientTests.DesktopClient.ViewModel.PlannedMeals.PlannedMealsViewModelTests
{
    internal class ConstructorTests
    {
        [Test]
        public void ValidConstructor()
        {
            var viewmodel = new PlannedMealsViewModel();
            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.PlannedMeals, Has.Length.Zero);
                Assert.That(viewmodel.RecipeTags, Has.Count.Zero);
            });
        }

        [Test]
        public void TwoParameterConstructor()
        {
            var viewmodel = new PlannedMealsViewModel();
            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.PlannedMeals, Has.Length.Zero);
                Assert.That(viewmodel.RecipeTags, Has.Count.Zero);
            });
        }

        [Test]
        public void NullPlannedMealsServiceThrowsException()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(
                    () => _ = new PlannedMealsViewModel(null!, new RecipesService()))!.Message;
                Assert.That(message, Is.EqualTo("Value cannot be null. (Parameter 'plannedMealsService')"));
            });
        }

        [Test]
        public void NullRecipesServiceThrowsException()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(
                    () => _ = new PlannedMealsViewModel(new PlannedMealsService(), null!))!.Message;
                Assert.That(message, Is.EqualTo("Value cannot be null. (Parameter 'recipesService')"));
            });
        }
    }
}
