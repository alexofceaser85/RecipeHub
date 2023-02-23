using Desktop_Client.ViewModel.Ingredients;

namespace DesktopClientTests.DesktopClient.ViewModel.Dialogs.EditIngredientViewModelTests
{
    public class GetSetIngredientNameTests
    {
        [Test]
        public void SetIngredientNameChangesTitle()
        {
            var viewmodel = new EditIngredientViewModel() {
                IngredientName = "name"
            };
            Assert.That(viewmodel.Title, Is.EqualTo("Edit name"));
        }
    }
}
