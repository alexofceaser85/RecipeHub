using Desktop_Client.Endpoints.ShoppingList;

namespace DesktopClientTests.DesktopClient.Endpoints.ShoppingList.ShoppingListEndpointsTests
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldCreateZeroParameterConstructor()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = new ShoppingListEndpoints();
            });
        }

        [Test]
        public void ShouldCreateOneParameterConstructor()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = new ShoppingListEndpoints(new HttpClient());
            });
        }

        [Test]
        public void ShouldNotCreateConstructorIfClientIsNull()
        {
            var message = Assert.Throws<ArgumentNullException>(() =>
            {
                _ = new ShoppingListEndpoints(null!);
            })?.Message;
            Assert.That(message, Is.EqualTo("Value cannot be null. (Parameter 'client')"));
        }
    }
}
