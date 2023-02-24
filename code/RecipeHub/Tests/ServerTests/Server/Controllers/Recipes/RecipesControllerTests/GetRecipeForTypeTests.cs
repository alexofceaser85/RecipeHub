using Moq;
using Server.Controllers.Recipes;
using System.Net;
using Server.Data.Settings;
using Server.Service.Recipes;
using Shared_Resources.Model.Recipes;

namespace ServerTests.Server.Controllers.Recipes.RecipesControllerTests
{
    public class GetRecipeForTypeTests
    {
        [Test]
        public void ShouldSuccessfullyGetRecipeForType()
        {
            const string sessionKey = "Key";
            var recipe = new Recipe();
            var recipes = new Recipe[1];
            recipes[0] = recipe;

            var recipesService = new Mock<IRecipesService>();

            recipesService.Setup(mock => mock.GetRecipesForType(sessionKey, "type")).Returns(recipes);
            var service = new RecipesController(recipesService.Object);

            var result = service.GetRecipesForType(sessionKey, "type");

            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(result.Message, Is.EqualTo(ServerSettings.DefaultSuccessfulConnectionMessage));
                Assert.That(result.Recipes, Is.EqualTo(recipes));
                recipesService.Verify(mock => mock.GetRecipesForType(sessionKey, "type"), Times.Once());
            });
        }

        [Test]
        public void ShouldNotGetRecipeIfUnauthorized()
        {
            const string sessionKey = "Key";
            var recipe = new Recipe();
            var recipes = new Recipe[1];
            recipes[0] = recipe;

            var recipesService = new Mock<IRecipesService>();

            recipesService.Setup(mock => mock.GetRecipesForType(sessionKey, "type"))
                .Throws(() => new UnauthorizedAccessException("unauthorized"));
            var service = new RecipesController(recipesService.Object);

            var result = service.GetRecipesForType(sessionKey, "type");

            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.Unauthorized));
                Assert.That(result.Message, Is.EqualTo("unauthorized"));
                Assert.That(result.Recipes, Is.EqualTo(new Recipe[0]));
                recipesService.Verify(mock => mock.GetRecipesForType(sessionKey, "type"), Times.Once());
            });
        }

        [Test]
        public void ShouldNotGetRecipeIfThrowsException()
        {
            const string sessionKey = "Key";
            var recipe = new Recipe();
            var recipes = new Recipe[1];
            recipes[0] = recipe;

            var recipesService = new Mock<IRecipesService>();

            recipesService.Setup(mock => mock.GetRecipesForType(sessionKey, "type"))
                .Throws(() => new ArgumentException("exception"));
            var service = new RecipesController(recipesService.Object);

            var result = service.GetRecipesForType(sessionKey, "type");

            Assert.Multiple(() =>
            {
                Assert.That(result.Code, Is.EqualTo(HttpStatusCode.InternalServerError));
                Assert.That(result.Message, Is.EqualTo("exception"));
                Assert.That(result.Recipes, Is.EqualTo(new Recipe[0]));
                recipesService.Verify(mock => mock.GetRecipesForType(sessionKey, "type"), Times.Once());
            });
        }
    }
}
