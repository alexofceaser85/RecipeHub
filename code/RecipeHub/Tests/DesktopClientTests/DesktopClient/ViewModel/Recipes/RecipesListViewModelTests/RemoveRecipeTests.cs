using Desktop_Client.Service.Ingredients;
using Desktop_Client.Service.Recipes;
using Desktop_Client.ViewModel.Recipes;
using Moq;

namespace DesktopClientTests.DesktopClient.ViewModel.Recipes.RecipesListViewModelTests
{
    public class RemoveRecipeTests
    {
        [Test]
        public void SuccessfullyRemoveRecipe()
        {
            const string sessionKey = "Key";
            const int recipeId = 1;

            var service = new Mock<IRecipesService>();
            service.Setup(mock => mock.RemoveRecipe(sessionKey, recipeId));

            var viewmodel = new RecipesListViewModel(service.Object, new IngredientsService());

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => viewmodel.RemoveRecipe(sessionKey, recipeId));
                service.Verify(mock => mock.RemoveRecipe(sessionKey, recipeId), Times.Once);
            });
        }
    }
}
