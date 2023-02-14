using Desktop_Client.Service.Recipes;
using Desktop_Client.ViewModel.Recipes;
using Moq;

namespace DesktopClientTests.DesktopClient.ViewModel.Recipes.RecipesListViewModelTests
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

            var viewmodel = new RecipesListViewModel(service.Object);

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => viewmodel.EditRecipe(sessionKey, recipeId, name, description, isPublic));
                service.Verify(mock => mock.EditRecipe(sessionKey, recipeId, name, description, isPublic), Times.Once);
            });
        }
    }
}
