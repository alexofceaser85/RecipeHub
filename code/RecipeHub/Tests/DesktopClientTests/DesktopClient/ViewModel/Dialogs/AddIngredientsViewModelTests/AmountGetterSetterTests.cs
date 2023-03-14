using System.Drawing;
using Desktop_Client.ViewModel.Ingredients;
using Shared_Resources.Data.Settings;

namespace DesktopClientTests.DesktopClient.ViewModel.Dialogs.AddIngredientsViewModelTests
{
    internal class AmountGetterSetterTests
    {
        [Test]
        public void AssignValidIngredientAmount()
        {
            const string amount = "amount";
            var viewmodel = new AddIngredientsViewModel() {
                IngredientAmount = amount
            };

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.IngredientAmount, Is.EqualTo(amount));
                Assert.That(viewmodel.IngredientAmountErrorMessage, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.IngredientAmountTextBoxColor, Is.EqualTo(Color.White));
            });
        }

        [Test]
        public void AssignEmptyIngredientAmount()
        {
            const string amount = "";
            var viewmodel = new AddIngredientsViewModel()
            {
                IngredientAmount = amount
            };

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.IngredientAmount, Is.EqualTo(amount));
                Assert.That(viewmodel.IngredientAmountErrorMessage, Is.EqualTo(AddIngredientsViewModel.EmptyIngredientAmountErrorMessage));
                Assert.That(viewmodel.IngredientAmountTextBoxColor, Is.EqualTo(ColorTranslator.FromHtml(UserInterfaceSettings.ErrorColor)));
            });
        }
    }
}
