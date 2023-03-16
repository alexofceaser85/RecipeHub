using Web_Client.Service.PlannedMeals;
using Web_Client.Service.Recipes;
using Web_Client.ViewModel.Recipes;

namespace WebClientTests.WebClient.ViewModel.Recipes.RecipesViewModelTests
{
    public class ConstructorTests
    {
        [Test]
        public void DefaultConstructorDoesNotThrowException()
        {
            var viewmodel = new RecipeViewModel();
            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.RecipeName, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.AuthorName, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.Description, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.Instructions, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.Ingredients, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.UserRatingText, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.YourRatingText, Is.EqualTo(string.Empty));
            });
        }

        [Test]
        public void TwoParameterConstructorDoesNotThrowException()
        {
            var viewmodel  = new RecipeViewModel(new RecipesService(), new PlannedMealsService());
            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.RecipeName, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.AuthorName, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.Description, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.Instructions, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.Ingredients, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.UserRatingText, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.YourRatingText, Is.EqualTo(string.Empty));
            });
        }

        [Test]
        public void NullRecipesServiceThrowsException()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(
                    () => _ = new RecipeViewModel(null!, new PlannedMealsService()))!.Message;
                Assert.That(message, Is.EqualTo("The recipes service cannot be null (Parameter 'recipeService')"));
            });
        }


        [Test]
        public void NullPlannedMealsServiceThrowsException()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(
                    () => _ = new RecipeViewModel(new RecipesService(), null!))!.Message;
                Assert.That(message, Is.EqualTo("Value cannot be null. (Parameter 'plannedMealService')"));
            });
        }
    }
}