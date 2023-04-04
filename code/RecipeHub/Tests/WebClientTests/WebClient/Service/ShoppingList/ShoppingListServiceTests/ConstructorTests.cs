using Web_Client.Endpoints.ShoppingList;
using Web_Client.Service.ShoppingList;

namespace WebClientTests.WebClient.Service.ShoppingList.ShoppingListServiceTests
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldCreateZeroParameterConstructor()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = new ShoppingListService();
            });
        }

        [Test]
        public void ShouldCreateOneParameterConstructor()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = new ShoppingListService(new ShoppingListEndpoints());
            });
        }

        [Test]
        public void ShouldNotCreateOneParameterConstructorWithNullEndpoints()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() =>
                {
                    _ = new ShoppingListService(null!);
                })?.Message;

                Assert.That(message, Is.EqualTo("Value cannot be null. (Parameter 'endpoints')"));
            });
        }
    }
}
