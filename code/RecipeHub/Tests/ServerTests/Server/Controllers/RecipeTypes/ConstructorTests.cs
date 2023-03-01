using Server.Controllers.RecipeTypes;
using Server.Service.RecipeTypes;
using Shared_Resources.ErrorMessages;

namespace ServerTests.Server.Controllers.RecipeTypes
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldCreateZeroParameterConstructor()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = new RecipeTypesController();
            });
        }

        [Test]
        public void ShouldCreateOneParameterConstructor()
        {
            var service = new RecipeTypesService();
            Assert.DoesNotThrow(() =>
            {
                _ = new RecipeTypesController(service);
            });
        }

        [Test]
        public void ShouldNotCreateConstructorWithNullService()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new RecipeTypesController(null!);
            })?.Message;
            Assert.That(message, Is.EqualTo(RecipeTypesControllerErrorMessages.ServiceCannotBeNull));
        }
    }
}
