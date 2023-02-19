using Desktop_Client.Service.Ingredients;
using Desktop_Client.Service.Recipes;
using Desktop_Client.ViewModel.Recipes;

namespace DesktopClientTests.DesktopClient.ViewModel.Recipes.RecipesListViewModelTests
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