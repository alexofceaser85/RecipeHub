using Desktop_Client.Endpoints.RecipeTypes;
using Desktop_Client.Service.RecipeTypes;
using Shared_Resources.ErrorMessages;

namespace DesktopClientTests.DesktopClient.Service.RecipeTypes.RecipeTypesTests
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldCreateZeroParameterConstructor()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = new RecipeTypesService();
            });
        }

        [Test]
        public void ShouldCreateOneParameterConstructor()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = new RecipeTypesService(new RecipeTypesEndpoints());
            });
        }

        [Test]
        public void ShouldNotCreateOneParameterConstructorWithNullEndpoints()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new RecipeTypesService(null!);
            })?.Message;

            Assert.That(message, Is.EqualTo(RecipeTypesErrorMessages.EndpointsCannotBeNull));
        }
    }
}
