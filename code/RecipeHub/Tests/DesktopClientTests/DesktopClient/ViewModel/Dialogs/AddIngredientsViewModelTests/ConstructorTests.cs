using System.Drawing;
using Desktop_Client.Service.Ingredients;
using Desktop_Client.ViewModel.Ingredients;
using Shared_Resources.Model.Ingredients;

namespace DesktopClientTests.DesktopClient.ViewModel.Dialogs.AddIngredientsViewModelTests
{
    public class ConstructorTests
    {
        [Test]
        public void DefaultConstructor()
        {
            var viewmodel = new AddIngredientsViewModel();
            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.IngredientName, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.IngredientAmount, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.SelectedMeasurementType, Is.EqualTo(MeasurementType.Quantity));
                Assert.That(viewmodel.SelectedMeasurementIndex, Is.EqualTo(0));
                Assert.That(viewmodel.IngredientNames, Has.Length.EqualTo(0));
                Assert.That(viewmodel.IngredientNameErrorMessage, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.IngredientAmountErrorMessage, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.IngredientNameTextBoxColor, Is.EqualTo(Color.White));
                Assert.That(viewmodel.IngredientAmountTextBoxColor, Is.EqualTo(Color.White));
            });
        }

        [Test]
        public void ValidSingleParameterConstructor()
        {
            var viewmodel = new AddIngredientsViewModel(new IngredientsService()); 
            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.IngredientName, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.IngredientAmount, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.SelectedMeasurementType, Is.EqualTo(MeasurementType.Quantity));
                Assert.That(viewmodel.SelectedMeasurementIndex, Is.EqualTo(0));
                Assert.That(viewmodel.IngredientNames, Has.Length.EqualTo(0));
                Assert.That(viewmodel.IngredientNameErrorMessage, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.IngredientAmountErrorMessage, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.IngredientNameTextBoxColor, Is.EqualTo(Color.White));
                Assert.That(viewmodel.IngredientAmountTextBoxColor, Is.EqualTo(Color.White));
            });
        }

        [Test]
        public void NullIngredientsService()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() => 
                    _ = new AddIngredientsViewModel(null!))!.Message;
                Assert.That(message, Is.EqualTo("Value cannot be null. (Parameter 'service')"));
            });
        }
    }
}
