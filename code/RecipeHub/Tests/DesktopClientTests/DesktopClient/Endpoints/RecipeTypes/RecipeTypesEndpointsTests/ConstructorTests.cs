using Desktop_Client.Endpoints.RecipeTypes;
using Shared_Resources.ErrorMessages;

namespace DesktopClientTests.DesktopClient.Endpoints.RecipeTypes.RecipeTypesEndpointsTests
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldCreateZeroParameterConstructor()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = new RecipeTypesEndpoints();
            });
        }

        [Test]
        public void ShouldCreateOneParameterConstructor()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = new RecipeTypesEndpoints(new HttpClient());
            });
        }

        [Test]
        public void ShouldNotCreateConstructorIfClientIsNull()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new RecipeTypesEndpoints(null!);
            })?.Message;
            Assert.That(message, Is.EqualTo(RecipeTypesErrorMessages.EndpointsCannotBeNull));
        }
    }
}
