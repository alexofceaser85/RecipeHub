using Moq;
using Web_Client.Service.Ingredients;
using Web_Client.Service.Recipes;
using Web_Client.ViewModel.Recipes;

namespace WebClientTests.WebClient.ViewModel.Recipes.RecipeListViewModelTests
{
    public class EditRecipeTests
    {
        [Test]
        public void SuccessfullyEditRecipe()
        {
            const string sessionKey = "Key";
            const int recipeId = 1;
            const string name = "name";
            const string description = "description";
            const bool isPublic = true;

            var service = new Mock<IRecipesService>();
            service.Setup(mock => mock.EditRecipe(sessionKey, recipeId, name, description, isPublic));

            var viewmodel = new RecipesListViewModel(service.Object, new IngredientsService());

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => viewmodel.EditRecipe(sessionKey, recipeId, name, description, isPublic));
                service.Verify(mock => mock.EditRecipe(sessionKey, recipeId, name, description, isPublic), Times.Once);
            });
        }
    }
}
