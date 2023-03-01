using Moq;
using Shared_Resources.Data.UserData;
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
            Session.Key = "Key";
            const int recipeId = 1;

            var service = new Mock<IRecipesService>();
            service.Setup(mock => mock.RemoveRecipe(recipeId));

            var viewmodel = new RecipesListViewModel(service.Object, new IngredientsService());

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => viewmodel.RemoveRecipe(recipeId));
                service.Verify(mock => mock.RemoveRecipe(recipeId), Times.Once);
            });
        }
    }
}
