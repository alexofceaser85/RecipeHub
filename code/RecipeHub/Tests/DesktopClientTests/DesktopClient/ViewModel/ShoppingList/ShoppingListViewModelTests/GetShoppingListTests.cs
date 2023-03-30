using Desktop_Client.Service.Ingredients;
using Desktop_Client.Service.ShoppingList;
using Desktop_Client.ViewModel.ShoppingList;
using Moq;
using Shared_Resources.Model.Ingredients;

namespace DesktopClientTests.DesktopClient.ViewModel.ShoppingList.ShoppingListViewModelTests
{
    internal class AddIngredientsToPantryTests
    {
        [Test]
        public void AddEmptyShoppingList()
        {
            var shoppingList = Array.Empty<Ingredient>();

            var service = new Mock<IIngredientsService>();
            service.Setup(x => x.AddIngredients(shoppingList)).Returns(true);

            var viewmodel = new ShoppingListViewModel(new ShoppingListService(), service.Object);

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => viewmodel.AddIngredientsToPantry(shoppingList));
                service.Verify(mock => mock.AddIngredients(shoppingList), Times.Once);
            });
        }

        [Test]
        public void AddSingleIngredientShoppingList()
        {
            var shoppingList = new Ingredient[] {new()};

            var service = new Mock<IIngredientsService>();
            service.Setup(x => x.AddIngredients(shoppingList)).Returns(true);

            var viewmodel = new ShoppingListViewModel(new ShoppingListService(), service.Object);
            

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => viewmodel.AddIngredientsToPantry(shoppingList));
                service.Verify(mock => mock.AddIngredients(shoppingList), Times.Once);
            });
        }

        [Test]
        public void AddManyIngredientShoppingList()
        {
            var shoppingList = new Ingredient[] {
                new(),
                new(),
                new()
            };

            var service = new Mock<IIngredientsService>();
            service.Setup(x => x.AddIngredients(shoppingList)).Returns(true);

            var viewmodel = new ShoppingListViewModel(new ShoppingListService(), service.Object);

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => viewmodel.AddIngredientsToPantry(shoppingList));
                service.Verify(mock => mock.AddIngredients(shoppingList), Times.Once);
            });
        }

        [Test]
        public void FailedToAddShoppingList()
        {
            const string errorMessage = "error message";
            var shoppingList = new Ingredient[] {
                new(),
                new(),
                new()
            };

            var service = new Mock<IIngredientsService>();
            service.Setup(x => x.AddIngredients(shoppingList)).Throws(new ArgumentException(errorMessage));

            var viewmodel = new ShoppingListViewModel(new ShoppingListService(), service.Object);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => viewmodel.AddIngredientsToPantry(shoppingList))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                service.Verify(mock => mock.AddIngredients(shoppingList), Times.Once);
            });
        }

        [Test]
        public void SessionKeyIsInvalid()
        {
            const string errorMessage = "error message";
            var shoppingList = new Ingredient[] {
                new(),
                new(),
                new()
            };

            var service = new Mock<IIngredientsService>();
            service.Setup(x => x.AddIngredients(shoppingList)).Throws(new UnauthorizedAccessException(errorMessage));

            var viewmodel = new ShoppingListViewModel(new ShoppingListService(), service.Object);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<UnauthorizedAccessException>(() => viewmodel.AddIngredientsToPantry(shoppingList))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                service.Verify(mock => mock.AddIngredients(shoppingList), Times.Once);
            });
        }
    }
}
