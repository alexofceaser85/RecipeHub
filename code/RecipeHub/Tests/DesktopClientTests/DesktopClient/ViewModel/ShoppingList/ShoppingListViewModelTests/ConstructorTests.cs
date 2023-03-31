using Desktop_Client.Service.Ingredients;
using Desktop_Client.Service.ShoppingList;
using Desktop_Client.ViewModel.ShoppingList;

namespace DesktopClientTests.DesktopClient.ViewModel.ShoppingList.ShoppingListViewModelTests
{
    public class ConstructorTests
    {
        [Test]
        public void DefaultConstructorDoesNotThrowException()
        {
            Assert.Multiple(() =>
            {
                var viewmodel = new ShoppingListViewModel();
                Assert.That(viewmodel.ShoppingList, Has.Length.Zero);
            });
        }

        [Test]
        public void TwoParameterConstructorDoesNotThrowException()
        {
            Assert.Multiple(() =>
            {
                var viewmodel = new ShoppingListViewModel(new ShoppingListService(), new IngredientsService());
                Assert.That(viewmodel.ShoppingList, Has.Length.Zero);
            });
        }

        [Test]
        public void NullShoppingListServiceThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => 
                _ = new ShoppingListViewModel(null!, new IngredientsService()));
        }

        [Test]
        public void NullIngredientsServiceThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => 
                _ = new ShoppingListViewModel(new ShoppingListService(), null!));
        }
    }
}