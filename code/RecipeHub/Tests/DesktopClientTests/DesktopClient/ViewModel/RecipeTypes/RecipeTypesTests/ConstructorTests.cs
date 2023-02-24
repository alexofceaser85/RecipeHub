using Desktop_Client.Service.RecipeTypes;
using Desktop_Client.ViewModel.RecipeTypes;
using Moq;
using Shared_Resources.ErrorMessages;

namespace DesktopClientTests.DesktopClient.ViewModel.RecipeTypes.RecipeTypesTests
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
