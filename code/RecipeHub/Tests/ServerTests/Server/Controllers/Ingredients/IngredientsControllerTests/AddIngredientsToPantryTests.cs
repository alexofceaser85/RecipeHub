using System.Net;
using Moq;
using Server.Controllers.Ingredients;
using Server.Service.Ingredients;
using Shared_Resources.Model.Ingredients;

namespace ServerTests.Server.Controllers.Ingredients.IngredientsControllerTests
{
    public class AddIngredientsToPantryTests
    {
        [Test]
        public void ShouldAddIngredientsToPantry()
        {
            var ingredients = new[]
            {
                new Ingredient("name1", 15, MeasurementType.Quantity),
                new Ingredient("name2", 5, MeasurementType.Quantity),
                new Ingredient("name3", 10, MeasurementType.Quantity),
            };
            var service = new Mock<IIngredientsService>();
            var controller = new IngredientsController(service.Object);

            service.Setup(x => x.AddIngredientsToPantry(ingredients, "key"));
            controller.AddIngredientsToPantry(ingredients, "key");

            service.Verify(x => x.AddIngredientsToPantry(ingredients, "key"), Times.Once);
        }

        [Test]
        public void ShouldNotAddIngredientsToPantryWhenUnauthorized()
        {
            var ingredients = new[]
            {
                new Ingredient("name1", 15, MeasurementType.Quantity),
                new Ingredient("name2", 5, MeasurementType.Quantity),
                new Ingredient("name3", 10, MeasurementType.Quantity),
            };
            var service = new Mock<IIngredientsService>();
            var controller = new IngredientsController(service.Object);

            service.Setup(x => x.AddIngredientsToPantry(ingredients, "key")).Throws(() => new UnauthorizedAccessException("exception"));

            var message = controller.AddIngredientsToPantry(ingredients, "key");

            service.Verify(x => x.AddIngredientsToPantry(ingredients, "key"), Times.Once);
            Assert.That(message.Message, Is.EqualTo("exception"));
            Assert.That(message.Code, Is.EqualTo(HttpStatusCode.Unauthorized));
        }

        [Test]
        public void ShouldNotAddIngredientsToPantryWhenException()
        {
            var ingredients = new[]
            {
                new Ingredient("name1", 15, MeasurementType.Quantity),
                new Ingredient("name2", 5, MeasurementType.Quantity),
                new Ingredient("name3", 10, MeasurementType.Quantity),
            };
            var service = new Mock<IIngredientsService>();
            var controller = new IngredientsController(service.Object);

            service.Setup(x => x.AddIngredientsToPantry(ingredients, "key")).Throws(() => new Exception("exception"));

            var message = controller.AddIngredientsToPantry(ingredients, "key");

            service.Verify(x => x.AddIngredientsToPantry(ingredients, "key"), Times.Once);
            Assert.That(message.Message, Is.EqualTo("exception"));
            Assert.That(message.Code, Is.EqualTo(HttpStatusCode.InternalServerError));
        }
    } 
}
