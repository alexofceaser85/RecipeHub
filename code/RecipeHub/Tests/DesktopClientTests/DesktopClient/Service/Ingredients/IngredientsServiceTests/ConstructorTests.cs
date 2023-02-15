using Desktop_Client.Endpoints.Ingredients;
using Desktop_Client.Service.Ingredients;
using Desktop_Client.Service.Recipes;
using Shared_Resources.ErrorMessages;

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
        public void ValidOneParameterConstructor()
        {
            Assert.DoesNotThrow(() => _ = new IngredientsService(new IngredientEndpoints()));
        }
    }
}
