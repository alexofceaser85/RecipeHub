using System.Net;
using Moq;
using Server.Controllers.RecipeTypes;
using Server.Controllers.ResponseModels;
using Server.Data.Settings;
using Server.Service.RecipeTypes;

namespace ServerTests.Server.Controllers.RecipeTypes
{
    public class GetAllRecipeTypesTests
    {
        [Test]
        public void ShouldGetRecipeTypes()
        {
            var recipeTypes = new[] { "type1", "type2", "type3" };
            var service = new Mock<IRecipesTypesService>();
            var controller = new RecipeTypesController(service.Object);

            service.Setup(mock => mock.GetAllRecipeTypes()).Returns(recipeTypes);

            var response = controller.GetAllRecipeTypes();

            Assert.That(response.Code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Message, Is.EqualTo(ServerSettings.DefaultSuccessfulConnectionMessage));
            Assert.That(response.Types, Is.EqualTo(recipeTypes));
        }

        [Test]
        public void ShouldNotGetRecipeTypesIfUnauthorized()
        {
            var recipeTypes = new string[0];
            var service = new Mock<IRecipesTypesService>();
            var controller = new RecipeTypesController(service.Object);

            service.Setup(mock => mock.GetAllRecipeTypes()).Throws(() => new UnauthorizedAccessException("unauthorized"));

            var response = controller.GetAllRecipeTypes();

            Assert.That(response.Code, Is.EqualTo(HttpStatusCode.Unauthorized));
            Assert.That(response.Message, Is.EqualTo("unauthorized"));
            Assert.That(response.Types, Is.EqualTo(recipeTypes));
        }

        [Test]
        public void ShouldNotGetRecipeTypesIfException()
        {
            var recipeTypes = new string[0];
            var service = new Mock<IRecipesTypesService>();
            var controller = new RecipeTypesController(service.Object);

            service.Setup(mock => mock.GetAllRecipeTypes()).Throws(() => new ArgumentException("exception"));

            var response = controller.GetAllRecipeTypes();

            Assert.That(response.Code, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.That(response.Message, Is.EqualTo("exception"));
            Assert.That(response.Types, Is.EqualTo(recipeTypes));
        }
    }
}
