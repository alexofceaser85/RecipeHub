using Moq;
using System.Net;
using Server.Controllers.Recipes;
using Server.Data.Settings;
using Server.Service.Recipes;
using Shared_Resources.Model.Ingredients;
using Shared_Resources.Model.Recipes;

namespace ServerTests.Server.Controllers.Recipes.RecipesControllerTests
{
    public class GetRecipeTests
    {
        [Test]
        public void RecipeStepsSuccessfullyRetrieved()
        {
            const string sessionKey = "Key";
            const int recipeId = 0;
            var recipe = new Recipe();

            var recipesService = new Mock<IRecipesService>();

            recipesService.Setup(mock => mock.GetRecipe(sessionKey, recipeId)).Returns(recipe);
            var service = new RecipesController(recipesService.Object);

            var result = service.GetRecipe(sessionKey, recipeId);

            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(result.Message, Is.EqualTo(ServerSettings.DefaultSuccessfulConnectionMessage));
                Assert.That(result.Recipe, Is.EqualTo(recipe));
                recipesService.Verify(mock => mock.GetRecipe(sessionKey, recipeId), Times.Once());
            });
        }
        
        [Test]
        public void ServiceFailedToFetchIngredients()
        {
            const string sessionKey = "Key";
            const int recipeId = 0;
            const string errorMessage = "This is an exception";

            var recipesService = new Mock<IRecipesService>();

            recipesService.Setup(mock => mock.GetRecipe(sessionKey, recipeId)).Throws(new ArgumentException(errorMessage));
            var service = new RecipesController(recipesService.Object);

            var result = service.GetRecipe(sessionKey, recipeId);

            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.InternalServerError));
                Assert.That(result.Message, Is.EqualTo(errorMessage));
                recipesService.Verify(mock => mock.GetRecipe(sessionKey, recipeId), Times.Once());
            });
        }
    }
}
