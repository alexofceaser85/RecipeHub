using System.Drawing;
using Desktop_Client.ViewModel.Ingredients;
using Shared_Resources.Data.Settings;

namespace DesktopClientTests.DesktopClient.ViewModel.Dialogs.AddIngredientsViewModelTests
{
    internal class NameGetterSetterTests
    {
        [Test]
        public void AssignValidIngredientName()
        {
            const string name = "name";
            var viewmodel = new AddIngredientsViewModel() {
                IngredientName = name
            };

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.IngredientName, Is.EqualTo(name));
                Assert.That(viewmodel.IngredientNameErrorMessage, Is.EqualTo(string.Empty));
                Assert.That(viewmodel.IngredientNameTextBoxColor, Is.EqualTo(Color.White));
            });
        }

        [Test]
        public void AssignEmptyIngredientName()
        {
            const string name = "";
            var viewmodel = new AddIngredientsViewModel()
            {
                IngredientName = name
            };

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.IngredientName, Is.EqualTo(name));
                Assert.That(viewmodel.IngredientNameErrorMessage, Is.EqualTo(AddIngredientsViewModel.EmptyIngredientNameErrorMessage));
                Assert.That(viewmodel.IngredientNameTextBoxColor, Is.EqualTo(ColorTranslator.FromHtml(UserInterfaceSettings.ErrorColor)));
            });
        }
    }
}
