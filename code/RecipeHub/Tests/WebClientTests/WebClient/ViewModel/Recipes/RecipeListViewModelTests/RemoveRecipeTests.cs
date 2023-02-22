using Moq;
using Web_Client.Service.Ingredients;
using Web_Client.Service.Recipes;
using Web_Client.ViewModel.Recipes;

namespace WebClientTests.WebClient.ViewModel.Recipes.RecipeListViewModelTests
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
