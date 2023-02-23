
using Desktop_Client.Service.Ingredients;
using Desktop_Client.ViewModel.Ingredients;
using Moq;
using Shared_Resources.Model.Ingredients;

namespace DesktopClientTests.DesktopClient.ViewModel.Ingredients.IngredientsViewModelTests
{
    public class RemoveIngredientTests
    {
        [Test]
        public void SuccessfullyRemoveIngredient()
        {
            var ingredient = new Ingredient("name", 1, MeasurementType.Quantity);
            
            var service = new Mock<IIngredientsService>();
            service.Setup(mock => mock.DeleteIngredient(ingredient)).Returns(true);

            var viewmodel = new IngredientsViewModel(service.Object);
            var result = viewmodel.RemoveIngredient(ingredient);
            
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(true));
                service.Verify(mock => mock.DeleteIngredient(ingredient), Times.Once);
            });
        }

        [Test]
        public void UnauthorizedAccessExceptionThrown()
        {
            var ingredient = new Ingredient("name", 1, MeasurementType.Quantity);
            var errorMessage = "error message";

            var service = new Mock<IIngredientsService>();
            service.Setup(mock => mock.DeleteIngredient(ingredient)).Throws(() => new UnauthorizedAccessException(errorMessage));

            var viewmodel = new IngredientsViewModel(service.Object);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<UnauthorizedAccessException>(() => 
                                        viewmodel.RemoveIngredient(ingredient))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                service.Verify(mock => mock.DeleteIngredient(ingredient), Times.Once);
            });
        }

        [Test]
        public void NonUnauthorizedAccessExceptionThrown()
        {
            var ingredient = new Ingredient("name", 1, MeasurementType.Quantity);

            var service = new Mock<IIngredientsService>();
            service.Setup(mock => mock.DeleteIngredient(ingredient)).Throws(() => new Exception());

            var viewmodel = new IngredientsViewModel(service.Object);
            var result = viewmodel.RemoveIngredient(ingredient);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(false));
                service.Verify(mock => mock.DeleteIngredient(ingredient), Times.Once);
            });
        }
    }
}
