using Web_Client.Service.Ingredients;
using Web_Client.ViewModel.Ingredient;

namespace WebClientTests.WebClient.ViewModel.Ingredients.IngredientsViewModelTests
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldCreateZeroParameterUsersViewModel()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = new IngredientsViewModel();
            });
        }

        [Test]
        public void ShouldCreateOneParameterUsersViewModel()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = new IngredientsViewModel(new IngredientsService());
            });
        }
    }
}
