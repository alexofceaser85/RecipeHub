using Desktop_Client.Endpoints.RecipeTypes;
using Desktop_Client.Endpoints.ShoppingList;
using Desktop_Client.Service.RecipeTypes;
using Desktop_Client.Service.ShoppingList;
using Shared_Resources.ErrorMessages;

namespace DesktopClientTests.DesktopClient.Service.ShoppingList.ShoppingListServiceTests
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
