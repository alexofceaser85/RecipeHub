using Desktop_Client.Service.Ingredients;
using Desktop_Client.Service.Recipes;
using Desktop_Client.ViewModel.Recipes;

namespace DesktopClientTests.DesktopClient.ViewModel.Recipes.RecipesViewModelTests
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
        public void OneParameterConstructorDoesNotThrowException()
        {
            var viewmodel  = new RecipeViewModel(new RecipesService());
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
        public void NullServiceThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => _ = new RecipeViewModel(null!));
        }
    }
}