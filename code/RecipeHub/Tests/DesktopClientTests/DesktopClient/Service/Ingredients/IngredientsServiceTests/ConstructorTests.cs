using Desktop_Client.Endpoints.Ingredients;
using Desktop_Client.Service.Ingredients;
using Desktop_Client.Service.Users;

namespace DesktopClientTests.DesktopClient.Service.Ingredients.IngredientsServiceTests
{
    public class ConstructorTests
    {
        [Test]
        public void ValidDefaultConstructor()
        {
            Assert.DoesNotThrow(() => _ = new IngredientsService());
        }

        [Test]
        public void ValidTwoParameterConstructor()
        {
            Assert.DoesNotThrow(() => _ = new IngredientsService(new IngredientEndpoints(), new UsersService()));
        }
    }
}