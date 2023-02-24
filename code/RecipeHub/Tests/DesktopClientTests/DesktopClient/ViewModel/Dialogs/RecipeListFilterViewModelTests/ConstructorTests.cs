using Desktop_Client.Service.RecipeTypes;
using Desktop_Client.ViewModel.Recipes;

namespace DesktopClientTests.DesktopClient.ViewModel.Dialogs.RecipeListFilterViewModelTests
{
    public class ConstructorTests
    {
        [Test]
        public void DefaultConstructor()
        {
            var viewmodel = new RecipeListFilterViewModel();
            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.SearchTerm, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.SelectedTags, Has.Count.EqualTo(0));
                Assert.That(viewmodel.FilterForAvailableIngredients, Is.EqualTo(true));
                Assert.That(viewmodel.FilteredTags, Has.Count.EqualTo(0));
            });
        }

        [Test]
        public void ValidOneParameterConstructor()
        {
            var viewmodel = new RecipeListFilterViewModel(new RecipeTypesService());
            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.SearchTerm, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.SelectedTags, Has.Count.EqualTo(0));
                Assert.That(viewmodel.FilterForAvailableIngredients, Is.EqualTo(true));
                Assert.That(viewmodel.FilteredTags, Has.Count.EqualTo(0));
            });
        }

        [Test]
        public void NullRecipeTypesService()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() => 
                    _ = new RecipeListFilterViewModel(null!))!.Message;
                Assert.That(message, Is.EqualTo("The service cannot be null (Parameter 'service')"));
            });
        }
    }
}
