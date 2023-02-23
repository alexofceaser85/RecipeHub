using Desktop_Client.Service.Ingredients;
using Desktop_Client.ViewModel.Ingredients;
using Moq;
using Shared_Resources.Model.Ingredients;

namespace DesktopClientTests.DesktopClient.ViewModel.Dialogs.EditIngredientViewModelTests
{
    public class EditIngredientTests
    {
        [Test]
        public void SuccessfullyEditIngredient()
        {
            var ingredient = new Ingredient("name", 2, MeasurementType.Quantity);
            const string ingredientName = "name";
            const string amount = "2";
            const bool expected = true;

            var service = new Mock<IIngredientsService>();
            service.Setup(mock => mock.UpdateIngredient(ingredient)).Returns(expected);

            var viewmodel = new EditIngredientViewModel(service.Object) {
                Amount = amount,
                IngredientName = ingredientName
            };

            var result = viewmodel.EditIngredient();
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(expected));
                service.Verify(mock => mock.UpdateIngredient(ingredient), Times.Once);
            });
        }

        [Test]
        public void UnauthorizedAccessExceptionRaised()
        {
            var ingredient = new Ingredient("name", 2, MeasurementType.Quantity);
            const string ingredientName = "name";
            const string amount = "2";
            const string errorMessage = "error message";

            var service = new Mock<IIngredientsService>();
            service.Setup(mock => mock.UpdateIngredient(ingredient))
                   .Throws(() => new UnauthorizedAccessException(errorMessage));

            var viewmodel = new EditIngredientViewModel(service.Object)
            {
                Amount = amount,
                IngredientName = ingredientName
            };

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<UnauthorizedAccessException>(() => viewmodel.EditIngredient())!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                service.Verify(mock => mock.UpdateIngredient(ingredient), Times.Once);
            });
        }

        [Test]
        public void HandleNonUnauthorizedAccessExceptions()
        {
            var ingredient = new Ingredient("name", 2, MeasurementType.Quantity);
            const string ingredientName = "name";
            const string amount = "2";
            const bool expected = false;

            var service = new Mock<IIngredientsService>();
            service.Setup(mock => mock.UpdateIngredient(ingredient))
                   .Throws(() => new Exception());

            var viewmodel = new EditIngredientViewModel(service.Object)
            {
                Amount = amount,
                IngredientName = ingredientName
            };

            var result = viewmodel.EditIngredient();
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(expected));
                service.Verify(mock => mock.UpdateIngredient(ingredient), Times.Once);
            });
        }
        
        [Test]
        public void IngredientAmountNotAnInteger()
        {
            const string ingredientName = "name";
            const string amount = "a";
            const bool expected = false;
            
            var viewmodel = new EditIngredientViewModel()
            {
                Amount = amount,
                IngredientName = ingredientName
            };
            
            Assert.That(viewmodel.EditIngredient(), Is.EqualTo(expected));
        }
    }
}
