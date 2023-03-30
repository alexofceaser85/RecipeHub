using Desktop_Client.Endpoints.ShoppingList;
using Desktop_Client.Service.ShoppingList;
using Moq;
using Shared_Resources.Model.Ingredients;

namespace DesktopClientTests.DesktopClient.Service.ShoppingList.ShoppingListServiceTests
{
    internal class GetShoppingListTests
    {
        [Test]
        public void SuccessfullyGetShoppingList()
        {
            var shoppingList = new Ingredient[] {
                new ("Apple", 5, MeasurementType.Mass),
                new ("Banana", 5, MeasurementType.Mass)
            };

            var endpoints = new Mock<IShoppingListEndpoints>();
            endpoints.Setup(mock => mock.GetShoppingList()).Returns(shoppingList);
            var service = new ShoppingListService(endpoints.Object);

            var result = service.GetShoppingList();
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(shoppingList));
                endpoints.Verify(mock => mock.GetShoppingList(), Times.Once);
            });
        }

        [Test]
        public void UserTimedOut()
        {
            const string errorMessage = "error message";
            var endpoints = new Mock<IShoppingListEndpoints>();
            endpoints.Setup(mock => mock.GetShoppingList()).Throws(new UnauthorizedAccessException(errorMessage));
            var service = new ShoppingListService(endpoints.Object);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<UnauthorizedAccessException>(() => service.GetShoppingList())!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                endpoints.Verify(mock => mock.GetShoppingList(), Times.Once);
            });
        }

        [Test]
        public void FailedToGetShoppingList()
        {
            const string errorMessage = "error message";
            var endpoints = new Mock<IShoppingListEndpoints>();
            endpoints.Setup(mock => mock.GetShoppingList()).Throws(new ArgumentException(errorMessage));
            var service = new ShoppingListService(endpoints.Object);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => service.GetShoppingList())!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                endpoints.Verify(mock => mock.GetShoppingList(), Times.Once);
            });
        }
    }
}
