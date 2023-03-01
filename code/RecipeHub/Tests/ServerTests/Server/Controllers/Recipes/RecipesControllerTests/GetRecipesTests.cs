using Moq;
using System.Net;
using Server.Controllers.Recipes;
using Server.Data.Settings;
using Server.Service.Recipes;
using Shared_Resources.Model.Recipes;

namespace ServerTests.Server.Controllers.Recipes.RecipesControllerTests
{
    public class GetRecipesTests
    {
        [Test]
        public void RecipeSuccessfullyRetrieved()
        {
            const string sessionKey = "Key";
            const string searchTerm = "a";
            var recipes = new Recipe[] {
                new(1, "authorName1", "name1", "description1", false),
                new(2, "authorName2", "name2", "description2", false),
                new(3, "authorName3", "name3", "description3", false)
            };

            var recipesService = new Mock<IRecipesService>();

            recipesService.Setup(mock => mock.GetRecipes(sessionKey, searchTerm)).Returns(recipes);
            var service = new RecipesController(recipesService.Object);

            var result = service.GetRecipes(sessionKey, searchTerm);

            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(result.Message, Is.EqualTo(ServerSettings.DefaultSuccessfulConnectionMessage));
                Assert.That(result.Recipes, Is.EquivalentTo(recipes));
                recipesService.Verify(mock => mock.GetRecipes(sessionKey, searchTerm), Times.Once());
            });
        }

        [Test]
        public void ServiceFailedToAddRecipe()
        {
            const string sessionKey = "Key";
            const string searchTerm = "a";
            const string errorMessage = "This is an exception";

            var recipesService = new Mock<IRecipesService>();

            recipesService.Setup(mock => mock.GetRecipes(sessionKey, searchTerm))
                          .Throws(new ArgumentException(errorMessage));
            var service = new RecipesController(recipesService.Object);

            var result = service.GetRecipes(sessionKey, searchTerm);

            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.InternalServerError));
                Assert.That(result.Message, Is.EqualTo(errorMessage));
                recipesService.Verify(mock => mock.GetRecipes(sessionKey, searchTerm), Times.Once());
            });
        }

        [Test]
        public void ServiceWasUnauthorized()
        {
            const string sessionKey = "Key";
            const string searchTerm = "a";
            const string errorMessage = "This is an exception";

            var recipesService = new Mock<IRecipesService>();

            recipesService.Setup(mock => mock.GetRecipes(sessionKey, searchTerm))
                .Throws(new UnauthorizedAccessException(errorMessage));
            var service = new RecipesController(recipesService.Object);

            var result = service.GetRecipes(sessionKey, searchTerm);

            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.Unauthorized));
                Assert.That(result.Message, Is.EqualTo(errorMessage));
                recipesService.Verify(mock => mock.GetRecipes(sessionKey, searchTerm), Times.Once());
            });
        }
    }
}