
using Desktop_Client.Service.Ingredients;
using Desktop_Client.ViewModel.Ingredients;
using Moq;

namespace DesktopClientTests.DesktopClient.ViewModel.Ingredients.IngredientsViewModelTests
{
    public class RemoveAllIngredients
    {
        [Test]
        public void SuccessfullyRemoveAllIngredients()
        {
            const bool expected = true;
            var service = new Mock<IIngredientsService>();
            service.Setup(mock => mock.DeleteAllIngredientsForUser()).Returns(expected);

            var viewmodel = new IngredientsViewModel(service.Object);
            var result = viewmodel.RemoveAllIngredients();
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(expected));
                service.Verify(mock => mock.DeleteAllIngredientsForUser(), Times.Once);
            });
        }

        [Test]
        public void UnauthorizedAccessExceptionThrown()
        {
            const string errorMessage = "error message";

            var service = new Mock<IIngredientsService>();
            service.Setup(mock => mock.DeleteAllIngredientsForUser())
                   .Throws(() => new UnauthorizedAccessException(errorMessage));

            var viewmodel = new IngredientsViewModel(service.Object);
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<UnauthorizedAccessException>(() =>
                    viewmodel.RemoveAllIngredients())!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                service.Verify(mock => mock.DeleteAllIngredientsForUser(), Times.Once);
            });
        }

        [Test]
        public void NonUnauthorizedAccessExceptionThrown()
        {
            var service = new Mock<IIngredientsService>();
            service.Setup(mock => mock.DeleteAllIngredientsForUser())
                   .Throws(() => new Exception());

            var viewmodel = new IngredientsViewModel(service.Object);
            var result = viewmodel.RemoveAllIngredients();
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(false));
                service.Verify(mock => mock.DeleteAllIngredientsForUser(), Times.Once);
            });
        }
    }
}
