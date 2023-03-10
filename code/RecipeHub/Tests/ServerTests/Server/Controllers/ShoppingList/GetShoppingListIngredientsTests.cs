using System.Net;
using Moq;
using Server.Controllers.ResponseModels;
using Server.Controllers.ShoppingList;
using Server.Data.Settings;
using Server.Service.ShoppingList;
using Shared_Resources.Model.Ingredients;

namespace ServerTests.Server.Controllers.ShoppingList
{
    public class GetShoppingListIngredientsTests
    {
        [Test]
        public void ShouldGetShoppingListIngredients()
        {
            var returnedIngredients = new []
            {
                new Ingredient("Apple", 4, MeasurementType.Quantity),
                new Ingredient("Flour", 4, MeasurementType.Volume),
                new Ingredient("Milk", 4, MeasurementType.Volume)
            };
            var expected = new RecipeIngredientsResponseModel(HttpStatusCode.OK,
                ServerSettings.DefaultSuccessfulConnectionMessage, returnedIngredients);
            var sessionKey = "Key";
            var service = new Mock<IShoppingListService>();
            var controller = new ShoppingListController(service.Object);

            service.Setup(mock => mock.GetShoppingListIngredients(sessionKey)).Returns(returnedIngredients);

            var actual = controller.GetShoppingListIngredients(sessionKey);

            Assert.That(expected.Code, Is.EqualTo(actual.Code));
            Assert.That(expected.Message, Is.EqualTo(actual.Message));
            Assert.That(expected.Ingredients, Is.EquivalentTo(actual.Ingredients));
        }

        [Test]
        public void ShouldNotAllowInvalidSessionKey()
        {
            var returnedIngredients = new Ingredient[] { };
            var expected = new RecipeIngredientsResponseModel(HttpStatusCode.Unauthorized,
                "error message", returnedIngredients);
            var sessionKey = "Key";
            var service = new Mock<IShoppingListService>();
            var controller = new ShoppingListController(service.Object);

            service.Setup(mock => mock.GetShoppingListIngredients(sessionKey))
                .Throws(() => new UnauthorizedAccessException("error message"));

            var actual = controller.GetShoppingListIngredients(sessionKey);

            Assert.That(expected.Code, Is.EqualTo(actual.Code));
            Assert.That(expected.Message, Is.EqualTo(actual.Message));
            Assert.That(expected.Ingredients, Is.EquivalentTo(actual.Ingredients));
        }

        [Test]
        public void ShouldNotAllowInvalidData()
        {
            var returnedIngredients = new Ingredient[] { };
            var expected = new RecipeIngredientsResponseModel(HttpStatusCode.InternalServerError,
                "error message", returnedIngredients);
            var sessionKey = "Key";
            var service = new Mock<IShoppingListService>();
            var controller = new ShoppingListController(service.Object);

            service.Setup(mock => mock.GetShoppingListIngredients(sessionKey))
                .Throws(() => new ArgumentException("error message"));

            var actual = controller.GetShoppingListIngredients(sessionKey);

            Assert.That(expected.Code, Is.EqualTo(actual.Code));
            Assert.That(expected.Message, Is.EqualTo(actual.Message));
            Assert.That(expected.Ingredients, Is.EquivalentTo(actual.Ingredients));
        }
    }
}
