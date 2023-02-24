using Server.DAL.RecipeTypes;
using Server.Service.RecipeTypes;
using Shared_Resources.ErrorMessages;

namespace ServerTests.Server.Service.RecipeTypes
{
    public class RecipeTypesConstructorTests
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
                _ = new RecipeTypesService(new RecipeTypesDal());
            });
        }

        [Test]
        public void ShouldNotAllowNullRecipeTypesDal()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new RecipeTypesService(null!);
            })?.Message;
            Assert.That(message, Is.EqualTo(RecipeTypesServiceErrorMessages.DalCannotBeNull));
        }
    }
}
