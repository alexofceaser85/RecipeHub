using System.Drawing;
using Desktop_Client.ViewModel.Ingredients;
using Shared_Resources.Data.Settings;

namespace DesktopClientTests.DesktopClient.ViewModel.Dialogs.EditIngredientViewModelTests
{
    internal class AmountGetterSetterTests
    {
        [Test]
        public void AssignValidIngredientAmount()
        {
            const string amount = "123";
            var viewmodel = new EditIngredientViewModel() {
                Amount = amount
            };

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.Amount, Is.EqualTo(amount));
                Assert.That(viewmodel.AmountErrorMessage, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.AmountTextBoxColor, Is.EqualTo(Color.White));
            });
        }

        [Test]
        public void AssignEmptyIngredientAmount()
        {
            const string amount = "";
            var viewmodel = new EditIngredientViewModel()
            {
                Amount = amount
            };

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.Amount, Is.EqualTo(amount));
                Assert.That(viewmodel.AmountErrorMessage, Is.EqualTo(EditIngredientViewModel.EmptyIngredientAmountErrorMessage));
                Assert.That(viewmodel.AmountTextBoxColor, Is.EqualTo(ColorTranslator.FromHtml(UserInterfaceSettings.ErrorColor)));
            });
        }
    }
}
