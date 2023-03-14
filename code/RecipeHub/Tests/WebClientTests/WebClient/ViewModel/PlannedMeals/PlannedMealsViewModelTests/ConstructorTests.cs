using Web_Client.Service.PlannedMeals;
using Web_Client.Service.Recipes;
using Web_Client.ViewModel.PlannedMeals;

namespace WebClientTests.WebClient.ViewModel.PlannedMeals.PlannedMealsViewModelTests
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
