using Desktop_Client.Service.Ingredients;
using Desktop_Client.ViewModel.Ingredients;
using Moq;

namespace DesktopClientTests.DesktopClient.ViewModel.Dialogs.AddIngredientsViewModelTests
{
    public class InitializeTests
    {
        [Test]
        public void ValidInitialization()
        {
            var ingredients = new[] {
                "Apple",
                "Banana"
            };
            const string ingredientName = "";

            var service = new Mock<IIngredientsService>();
            service.Setup(mock => mock.GetSuggestions(ingredientName)).Returns(ingredients);

            var viewmodel = new AddIngredientsViewModel(service.Object);
            viewmodel.Initialize();

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.IngredientNames, Is.EquivalentTo(ingredients));
                service.Verify(mock => mock.GetSuggestions(ingredientName), Times.Once);
            });
        }
    }
}
