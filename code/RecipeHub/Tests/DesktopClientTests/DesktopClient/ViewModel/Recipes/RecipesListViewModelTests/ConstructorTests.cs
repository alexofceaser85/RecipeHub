using Desktop_Client.Service.Ingredients;
using Desktop_Client.Service.Recipes;
using Desktop_Client.ViewModel.Recipes;
using Shared_Resources.Model.Filters;

namespace DesktopClientTests.DesktopClient.ViewModel.Recipes.RecipesListViewModelTests
{
    public class ConstructorTests
    {
        [Test]
        public void DefaultConstructorDoesNotThrowException()
        {
            Assert.Multiple(() =>
            {
                var viewmodel = new RecipesListViewModel();
                Assert.That(viewmodel.SearchTerm, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.Recipes, Has.Length.EqualTo(0));
                Assert.That(viewmodel.Filters, Is.EqualTo(new RecipeFilters()));
            });
        }

        [Test]
        public void TwoParameterConstructorDoesNotThrowException()
        {
            Assert.Multiple(() =>
            {
                var viewmodel = new RecipesListViewModel(new RecipesService(), new IngredientsService());
                Assert.That(viewmodel.SearchTerm, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.Recipes, Has.Length.EqualTo(0));
                Assert.That(viewmodel.Filters, Is.EqualTo(new RecipeFilters()));
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