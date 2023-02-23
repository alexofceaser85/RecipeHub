using Desktop_Client.Service.Ingredients;
using Desktop_Client.ViewModel.Ingredients;
using Moq;
using Shared_Resources.Model.Ingredients;

namespace DesktopClientTests.DesktopClient.ViewModel.Dialogs.AddIngredientsViewModelTests
{
    public class AddIngredientTests
    {
        [Test]
        public void SuccessfullyAddIngredient()
        {
            var ingredient = new Ingredient("name", 2, MeasurementType.Quantity);
            const string ingredientName = "name";
            const string amount = "2";
            const MeasurementType measurementType = MeasurementType.Quantity;
            const bool expected = true;

            var service = new Mock<IIngredientsService>();
            service.Setup(mock => mock.AddIngredient(ingredient)).Returns(expected);

            var viewmodel = new AddIngredientsViewModel(service.Object) {
                IngredientAmount = amount,
                IngredientName = ingredientName,
                SelectedMeasurementType = measurementType
            };

            var result = viewmodel.AddIngredient();
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(expected));
                service.Verify(mock => mock.AddIngredient(ingredient), Times.Once);
            });
        }

        [Test]
        public void UnauthorizedAccessExceptionRaised()
        {
            var ingredient = new Ingredient("name", 2, MeasurementType.Quantity);
            const string ingredientName = "name";
            const string amount = "2";
            const MeasurementType measurementType = MeasurementType.Quantity;
            const string errorMessage = "error message";

            var service = new Mock<IIngredientsService>();
            service.Setup(mock => mock.AddIngredient(ingredient))
                   .Throws(() => new UnauthorizedAccessException(errorMessage));

            var viewmodel = new AddIngredientsViewModel(service.Object) {
                IngredientAmount = amount,
                IngredientName = ingredientName,
                SelectedMeasurementType = measurementType
            };

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<UnauthorizedAccessException>(() => viewmodel.AddIngredient())!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                service.Verify(mock => mock.AddIngredient(ingredient), Times.Once);
            });
        }

        [Test]
        public void HandleNonUnauthorizedAccessExceptions()
        {
            var ingredient = new Ingredient("name", 2, MeasurementType.Quantity);
            const string ingredientName = "name";
            const string amount = "2";
            const MeasurementType measurementType = MeasurementType.Quantity;
            const bool expected = false;

            var service = new Mock<IIngredientsService>();
            service.Setup(mock => mock.AddIngredient(ingredient))
                   .Throws(() => new Exception());

            var viewmodel = new AddIngredientsViewModel(service.Object)
            {
                IngredientAmount = amount,
                IngredientName = ingredientName,
                SelectedMeasurementType = measurementType
            };

            var result = viewmodel.AddIngredient();
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(expected));
                service.Verify(mock => mock.AddIngredient(ingredient), Times.Once);
            });
        }
        
        [Test]
        public void IngredientAmountNotAnInteger()
        {
            var ingredient = new Ingredient("name", 2, MeasurementType.Quantity);
            const string ingredientName = "name";
            const string amount = "a";
            const MeasurementType measurementType = MeasurementType.Quantity;
            const bool expected = false;
            
            var viewmodel = new AddIngredientsViewModel()
            {
                IngredientAmount = amount,
                IngredientName = ingredientName,
                SelectedMeasurementType = measurementType
            };
            
            Assert.That(viewmodel.AddIngredient(), Is.EqualTo(expected));
        }
    }
}
