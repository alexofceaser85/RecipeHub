using Desktop_Client.Service.Ingredients;
using Desktop_Client.Service.ShoppingList;
using Desktop_Client.ViewModel.ShoppingList;
using Moq;
using Shared_Resources.Model.Ingredients;

namespace DesktopClientTests.DesktopClient.ViewModel.ShoppingList.ShoppingListViewModelTests
{
    internal class GetShoppingListTests
    {
        [Test]
        public void GetEmptyShoppingList()
        {
            var shoppingList = Array.Empty<Ingredient>();

            var service = new Mock<IShoppingListService>();
            service.Setup(x => x.GetShoppingList()).Returns(shoppingList);

            var viewmodel = new ShoppingListViewModel(service.Object, new IngredientsService());
            viewmodel.GetShoppingList();

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.ShoppingList, Is.EqualTo(shoppingList));
                service.Verify(mock => mock.GetShoppingList(), Times.Once);
            });
        }

        [Test]
        public void GetSingleIngredientShoppingList()
        {
            var shoppingList = new Ingredient[] {new()};

            var service = new Mock<IShoppingListService>();
            service.Setup(x => x.GetShoppingList()).Returns(shoppingList);

            var viewmodel = new ShoppingListViewModel(service.Object, new IngredientsService());
            viewmodel.GetShoppingList();

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.ShoppingList, Is.EqualTo(shoppingList));
                service.Verify(mock => mock.GetShoppingList(), Times.Once);
            });
        }

        [Test]
        public void GetManyIngredientShoppingList()
        {
            var shoppingList = new Ingredient[] {
                new(),
                new(),
                new()
            };

            var service = new Mock<IShoppingListService>();
            service.Setup(x => x.GetShoppingList()).Returns(shoppingList);

            var viewmodel = new ShoppingListViewModel(service.Object, new IngredientsService());
            viewmodel.GetShoppingList();

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.ShoppingList, Is.EqualTo(shoppingList));
                service.Verify(mock => mock.GetShoppingList(), Times.Once);
            });
        }

        [Test]
        public void FailedToGetShoppingList()
        {
            const string errorMessage = "error message";
            var service = new Mock<IShoppingListService>();
            service.Setup(x => x.GetShoppingList()).Throws(new ArgumentException(errorMessage));

            var viewmodel = new ShoppingListViewModel(service.Object, new IngredientsService());

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => viewmodel.GetShoppingList())!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                service.Verify(mock => mock.GetShoppingList(), Times.Once);
            });
        }

        [Test]
        public void SessionKeyIsInvalid()
        {
            const string errorMessage = "error message";
            var service = new Mock<IShoppingListService>();
            service.Setup(x => x.GetShoppingList()).Throws(new UnauthorizedAccessException(errorMessage));

            var viewmodel = new ShoppingListViewModel(service.Object, new IngredientsService());

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<UnauthorizedAccessException>(() => viewmodel.GetShoppingList())!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                service.Verify(mock => mock.GetShoppingList(), Times.Once);
            });
        }
    }
}
