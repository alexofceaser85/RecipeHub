using Web_Client.Endpoints.Ingredients;
using Web_Client.Service.Ingredients;
using Web_Client.Service.Users;

namespace WebClientTests.WebClient.Service.Ingredients.IngredientsServiceTests
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