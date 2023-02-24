using Shared_Resources.ErrorMessages;
using Web_Client.Service.RecipeTypes;
using Web_Client.ViewModel.RecipeTypes;

namespace WebClientTests.WebClient.ViewModel.RecipeTypes.RecipeTypesTests
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldCreateZeroParameterConstructor()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = new RecipeTypesViewModel();
            });
        }

        [Test]
        public void ShouldCreateOneParameterConstructor()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = new RecipeTypesViewModel(new RecipeTypesService());
            });
        }

        [Test]
        public void ShouldNotAllowNullService()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new RecipeTypesViewModel(null!);
            })?.Message;
            Assert.That(message, Is.EqualTo(RecipeTypesViewModelErrorMessages.ServiceCannotBeNull));
        }
    }
}
