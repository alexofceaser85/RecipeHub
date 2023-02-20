using Moq;
using Web_Client.Service.Ingredients;
using Web_Client.Service.Recipes;
using Web_Client.ViewModel.Recipes;

namespace WebClientTests.WebClient.ViewModel.Recipes.RecipeListViewModelTests
{
    public class AddRecipeTests
    {
        [Test]
        public void SuccessfullyAddRecipe()
        {
            const string sessionKey = "Key";
            const string name = "name";
            const string description = "description";
            const bool isPublic = true;

            var service = new Mock<IRecipesService>();
            service.Setup(mock => mock.AddRecipe(sessionKey, name, description, isPublic));

            var viewmodel = new RecipesListViewModel(service.Object, new IngredientsService());

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => viewmodel.AddRecipe(sessionKey, name, description, isPublic));
                service.Verify(mock => mock.AddRecipe(sessionKey, name, description, isPublic), Times.Once);
            });
        }
    }
}
