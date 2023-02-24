using Moq;
using Web_Client.Endpoints.RecipeTypes;
using Web_Client.Service.RecipeTypes;

namespace WebClientTests.WebClient.Service.RecipeTypes.RecipeTypesTests
{
    public class GetAllRecipeTypesTests
    {
        [Test]
        public void ShouldGetAllRecipeTypes()
        {
            var types = new[]
            {
                "type1", "type2", "type3"
            };
            var endpoints = new Mock<IRecipeTypesEndpoints>();
            var service = new RecipeTypesService(endpoints.Object);

            endpoints.Setup(mock => mock.GetAllRecipeTypes()).Returns(types);

            var actual = service.GetAllRecipeTypes();

            Assert.That(actual, Is.EqualTo(types));
        }
    }
}
