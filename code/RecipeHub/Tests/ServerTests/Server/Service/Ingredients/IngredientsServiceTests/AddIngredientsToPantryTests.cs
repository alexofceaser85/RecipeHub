using Moq;
using Server.DAL.Ingredients;
using Server.DAL.Users;
using Server.Service.Ingredients;
using Shared_Resources.Model.Ingredients;

namespace ServerTests.Server.Service.Ingredients.IngredientsServiceTests
{
    public class AddIngredientsToPantryTests
    {
        [Test]
        public void ShouldNotAddNullIngredients()
        {
            var ingredientsService = new IngredientsService();
            var message = Assert.Throws<ArgumentException>(() =>
            {
                ingredientsService.AddIngredientsToPantry(null!, "key");   
            })?.Message;
            Assert.That("Ingredients to add cannot be null", Is.EqualTo(message));
        }

        [Test]
        public void ShouldNotAddNullSessionKey()
        {
            var ingredientsService = new IngredientsService();
            var message = Assert.Throws<UnauthorizedAccessException>(() =>
            {
                ingredientsService.AddIngredientsToPantry(new Ingredient[0], null!);
            })?.Message;
            Assert.That("Session key cannot be null", Is.EqualTo(message));
        }

        [Test]
        public void ShouldNotAddEmptySessionKey()
        {
            var ingredientsService = new IngredientsService();
            var message = Assert.Throws<UnauthorizedAccessException>(() =>
            {
                ingredientsService.AddIngredientsToPantry(new Ingredient[0], "");
            })?.Message;
            Assert.That("Session key cannot be null", Is.EqualTo(message));
        }

        [Test]
        public void ShouldNotAllowNotExistingSessionKey()
        {
            var mockUsersDal = new Mock<IUsersDal>();
            var mockIngredientsDal = new Mock<IIngredientsDal>();
            var service = new IngredientsService(mockUsersDal.Object, mockIngredientsDal.Object);

            mockUsersDal.Setup(x => x.VerifySessionKeyDoesNotExist("key")).Returns(true);

            var message = Assert.Throws<UnauthorizedAccessException>(() =>
            {
                service.AddIngredientsToPantry(new Ingredient[0], "key");
            })?.Message;

            Assert.That("Session key must exist in the system.", Is.EqualTo(message));
        }

        [Test]
        public void ShouldNotAllowNotExistingUser()
        {
            var mockUsersDal = new Mock<IUsersDal>();
            var mockIngredientsDal = new Mock<IIngredientsDal>();
            var service = new IngredientsService(mockUsersDal.Object, mockIngredientsDal.Object);

            mockUsersDal.Setup(x => x.GetIdForSessionKey("key")).Returns(1);
            mockUsersDal.Setup(x => x.UserIdExists(1)).Returns(false);
            mockUsersDal.Setup(x => x.VerifySessionKeyDoesNotExist("key")).Returns(false);

            var message = Assert.Throws<UnauthorizedAccessException>(() =>
            {
                service.AddIngredientsToPantry(new Ingredient[0], "key");
            })?.Message;

            Assert.That("User must exist in the system.", Is.EqualTo(message));
        }

        [Test]
        public void ShouldAddEmptyIngredients()
        {
            var mockUsersDal = new Mock<IUsersDal>();
            var mockIngredientsDal = new Mock<IIngredientsDal>();
            var service = new IngredientsService(mockUsersDal.Object, mockIngredientsDal.Object);

            mockUsersDal.Setup(x => x.GetIdForSessionKey("key")).Returns(1);
            mockUsersDal.Setup(x => x.UserIdExists(1)).Returns(true);
            mockUsersDal.Setup(x => x.VerifySessionKeyDoesNotExist("key")).Returns(false);

            service.AddIngredientsToPantry(new Ingredient[0], "key");

            mockIngredientsDal.Verify(x => x.IsIngredientInPantry(It.IsAny<string>(), It.IsAny<int>()), Times.Never);
            mockIngredientsDal.Verify(x => x.UpdateIngredientInPantry(It.IsAny<Ingredient>(), It.IsAny<int>()), Times.Never);
            mockIngredientsDal.Verify(x => x.AddIngredientToPantry(It.IsAny<Ingredient>(), It.IsAny<int>()), Times.Never);
        }

        [Test]
        public void ShouldAddIngredientsToEmptyPantry()
        {
            var ingredients = new []
            {
                new Ingredient("name1", 5, MeasurementType.Quantity),
                new Ingredient("name2", 15, MeasurementType.Quantity),
                new Ingredient("name3", 1, MeasurementType.Quantity)
            };

            var mockUsersDal = new Mock<IUsersDal>();
            var mockIngredientsDal = new Mock<IIngredientsDal>();
            var service = new IngredientsService(mockUsersDal.Object, mockIngredientsDal.Object);

            mockUsersDal.Setup(x => x.GetIdForSessionKey("key")).Returns(1);
            mockUsersDal.Setup(x => x.UserIdExists(1)).Returns(true);
            mockUsersDal.Setup(x => x.VerifySessionKeyDoesNotExist("key")).Returns(false);

            mockIngredientsDal.Setup(x => x.IsIngredientInPantry("name1", 1)).Returns(false);
            mockIngredientsDal.Setup(x => x.IsIngredientInPantry("name2", 1)).Returns(false);
            mockIngredientsDal.Setup(x => x.IsIngredientInPantry("name3", 1)).Returns(false);

            service.AddIngredientsToPantry(ingredients, "key");

            mockIngredientsDal.Setup(x => x.GetIngredientsFor(1)).Returns(new Ingredient[0]);

            mockIngredientsDal.Verify(x => x.IsIngredientInPantry("name1", It.IsAny<int>()), Times.Once);
            mockIngredientsDal.Verify(x => x.IsIngredientInPantry("name2", It.IsAny<int>()), Times.Once);
            mockIngredientsDal.Verify(x => x.IsIngredientInPantry("name3", It.IsAny<int>()), Times.Once);

            mockIngredientsDal.Verify(x => x.UpdateIngredientInPantry(It.IsAny<Ingredient>(), It.IsAny<int>()), Times.Never);

            mockIngredientsDal.Verify(x => x.AddIngredientToPantry(ingredients[0], It.IsAny<int>()), Times.Once);
            mockIngredientsDal.Verify(x => x.AddIngredientToPantry(ingredients[1], It.IsAny<int>()), Times.Once);
            mockIngredientsDal.Verify(x => x.AddIngredientToPantry(ingredients[2], It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void ShouldAddIngredientsToPantryWithAllIngredients()
        {
            var pantry = new[]
            {
                new Ingredient("name1", 5, MeasurementType.Quantity),
                new Ingredient("name2", 15, MeasurementType.Quantity),
                new Ingredient("name3", 1, MeasurementType.Quantity)
            };

            var ingredients = new[]
            {
                new Ingredient("name1", 5, MeasurementType.Quantity),
                new Ingredient("name2", 15, MeasurementType.Quantity),
                new Ingredient("name3", 1, MeasurementType.Quantity)
            };

            var mockUsersDal = new Mock<IUsersDal>();
            var mockIngredientsDal = new Mock<IIngredientsDal>();
            var service = new IngredientsService(mockUsersDal.Object, mockIngredientsDal.Object);

            mockUsersDal.Setup(x => x.GetIdForSessionKey("key")).Returns(1);
            mockUsersDal.Setup(x => x.UserIdExists(1)).Returns(true);
            mockUsersDal.Setup(x => x.VerifySessionKeyDoesNotExist("key")).Returns(false);

            mockIngredientsDal.Setup(x => x.GetIngredientsFor(1)).Returns(pantry);

            mockIngredientsDal.Setup(x => x.IsIngredientInPantry("name1", 1)).Returns(true);
            mockIngredientsDal.Setup(x => x.IsIngredientInPantry("name2", 1)).Returns(true);
            mockIngredientsDal.Setup(x => x.IsIngredientInPantry("name3", 1)).Returns(true);

            service.AddIngredientsToPantry(ingredients, "key");

            mockIngredientsDal.Verify(x => x.IsIngredientInPantry("name1", It.IsAny<int>()), Times.Once);
            mockIngredientsDal.Verify(x => x.IsIngredientInPantry("name2", It.IsAny<int>()), Times.Once);
            mockIngredientsDal.Verify(x => x.IsIngredientInPantry("name3", It.IsAny<int>()), Times.Once);

            mockIngredientsDal.Verify(x => x.UpdateIngredientInPantry(It.IsAny<Ingredient>(), It.IsAny<int>()), Times.Exactly(3));
            mockIngredientsDal.Verify(x => x.AddIngredientToPantry(It.IsAny<Ingredient>(), It.IsAny<int>()), Times.Never);
        }

        [Test]
        public void ShouldAddIngredientsToPantryWithSomeIngredients()
        {
            var ingredients = new[]
            {
                new Ingredient("name1", 5, MeasurementType.Quantity),
                new Ingredient("name2", 15, MeasurementType.Quantity),
                new Ingredient("name3", 1, MeasurementType.Quantity),
                new Ingredient("name4", 5, MeasurementType.Quantity),
                new Ingredient("name5", 15, MeasurementType.Quantity),
                new Ingredient("name6", 1, MeasurementType.Quantity)
            };

            var pantry = new[]
            {
                new Ingredient("name1", 5, MeasurementType.Quantity),
                new Ingredient("name3", 5, MeasurementType.Quantity),
                new Ingredient("name5", 5, MeasurementType.Quantity)
            };

            var mockUsersDal = new Mock<IUsersDal>();
            var mockIngredientsDal = new Mock<IIngredientsDal>();
            var service = new IngredientsService(mockUsersDal.Object, mockIngredientsDal.Object);

            mockUsersDal.Setup(x => x.GetIdForSessionKey("key")).Returns(1);
            mockUsersDal.Setup(x => x.UserIdExists(1)).Returns(true);
            mockUsersDal.Setup(x => x.VerifySessionKeyDoesNotExist("key")).Returns(false);

            mockIngredientsDal.Setup(x => x.IsIngredientInPantry("name1", 1)).Returns(true);
            mockIngredientsDal.Setup(x => x.IsIngredientInPantry("name2", 1)).Returns(false);
            mockIngredientsDal.Setup(x => x.IsIngredientInPantry("name3", 1)).Returns(true);
            mockIngredientsDal.Setup(x => x.IsIngredientInPantry("name4", 1)).Returns(false);
            mockIngredientsDal.Setup(x => x.IsIngredientInPantry("name5", 1)).Returns(true);
            mockIngredientsDal.Setup(x => x.IsIngredientInPantry("name6", 1)).Returns(false);

            mockIngredientsDal.Setup(x => x.GetIngredientsFor(1)).Returns(pantry);

            service.AddIngredientsToPantry(ingredients, "key");

            mockIngredientsDal.Verify(x => x.IsIngredientInPantry("name1", It.IsAny<int>()), Times.Once);
            mockIngredientsDal.Verify(x => x.IsIngredientInPantry("name2", It.IsAny<int>()), Times.Once);
            mockIngredientsDal.Verify(x => x.IsIngredientInPantry("name3", It.IsAny<int>()), Times.Once);

            mockIngredientsDal.Verify(x => x.UpdateIngredientInPantry(It.IsAny<Ingredient>(), It.IsAny<int>()), Times.Exactly(3));

            mockIngredientsDal.Verify(x => x.AddIngredientToPantry(ingredients[1], It.IsAny<int>()), Times.Once);
            mockIngredientsDal.Verify(x => x.AddIngredientToPantry(ingredients[3], It.IsAny<int>()), Times.Once);
            mockIngredientsDal.Verify(x => x.AddIngredientToPantry(ingredients[5], It.IsAny<int>()), Times.Once);
        }
    }
}
