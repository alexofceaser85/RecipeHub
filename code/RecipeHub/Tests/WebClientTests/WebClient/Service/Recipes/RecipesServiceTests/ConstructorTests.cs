using Web_Client.Endpoints.Recipes;
using Web_Client.Service.Recipes;
using Shared_Resources.ErrorMessages;

namespace WebClientTests.WebClient.Service.Recipes.RecipesServiceTests
{
    public class ConstructorTests
    {
        [Test]
        public void ValidDefaultConstructor()
        {
            Assert.DoesNotThrow(() => _ = new RecipesService());
        }

        [Test]
        public void ValidOneParameterConstructor()
        {
            Assert.DoesNotThrow(() => _ = new RecipesService(new RecipesEndpoints()));
        }

        [Test]
        public void NullRecipesEndpoint()
        {
            var errorMessage = RecipesServiceErrorMessages.RecipesEndpointsCannotBeNull + " (Parameter 'endpoints')";
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() => { _ = new RecipesService(null!); })?.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }
    }
}