using System.Drawing;
using Desktop_Client.Service.Ingredients;
using Desktop_Client.ViewModel.Ingredients;

namespace DesktopClientTests.DesktopClient.ViewModel.Dialogs.EditIngredientViewModelTests
{
    public class ConstructorTests
    {
        [Test]
        public void DefaultConstructor()
        {
            var viewmodel = new EditIngredientViewModel();
            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.IngredientName, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.Title, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.Amount, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.AmountErrorMessage, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.AmountTextBoxColor, Is.EqualTo(Color.White));
            });
        }

        [Test]
        public void ValidSingleParameterConstructor()
        {
            var viewmodel = new EditIngredientViewModel(new IngredientsService());
            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.IngredientName, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.Title, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.Amount, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.AmountErrorMessage, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.AmountTextBoxColor, Is.EqualTo(Color.White));
            });
        }

        [Test]
        public void NullIngredientsService()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() => 
                    _ = new EditIngredientViewModel(null!))!.Message;
                Assert.That(message, Is.EqualTo("Value cannot be null. (Parameter 'service')"));
            });
        }
    }
}
