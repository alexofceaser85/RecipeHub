using Web_Client.Service.Ingredients;
using Web_Client.Service.Recipes;
using Web_Client.ViewModel.Recipes;

namespace WebClientTests.WebClient.ViewModel.Recipes.RecipesListViewModelTests
{
    public class ConstructorTests
    {
        [Test]
        public void DefaultConstructorDoesNotThrowException()
        {
            Assert.Multiple(() =>
            {
                var viewmodel = new RecipesListViewModel();
                Assert.That(viewmodel.Recipes, Has.Length.EqualTo(0));
            });
        }

        [Test]
        public void TwoParameterConstructorDoesNotThrowException()
        {
            Assert.Multiple(() =>
            {
                var viewmodel = new RecipesListViewModel(new RecipesService(), new IngredientsService());
                Assert.That(viewmodel.Recipes, Has.Length.EqualTo(0));
            });
        }

        [Test]
        public void NullRecipesServiceThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => _ = new RecipesListViewModel(null!, new IngredientsService()));
        }

        [Test]
        public void NullIngredientsServiceThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => _ = new RecipesListViewModel(new RecipesService(), null!));
        }
    }
}