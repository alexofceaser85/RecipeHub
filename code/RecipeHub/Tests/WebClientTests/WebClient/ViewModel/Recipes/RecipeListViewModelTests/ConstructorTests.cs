using Web_Client.Service.Ingredients;
using Web_Client.Service.Recipes;
using Web_Client.ViewModel.Recipes;

namespace WebClientTests.WebClient.ViewModel.Recipes.RecipeListViewModelTests
{
    public class ConstructorTests
    {
        [Test]
        public void DefaultConstructorDoesNotThrowException()
        {
            Assert.DoesNotThrow(() => _ = new RecipesListViewModel());
        }

        [Test]
        public void TwoParameterConstructorDoesNotThrowException()
        {
            Assert.DoesNotThrow(() => _ = new RecipesListViewModel(new RecipesService(), new IngredientsService()));
        }

        [Test]
        public void NullServiceThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => _ = new RecipesListViewModel(null!, new IngredientsService()));
        }
    }
}