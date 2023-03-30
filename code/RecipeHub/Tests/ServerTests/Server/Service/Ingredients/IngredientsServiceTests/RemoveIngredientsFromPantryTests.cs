using Moq;
using Server.DAL.Ingredients;
using Server.DAL.Recipes;
using Server.DAL.Users;
using Server.Service.Ingredients;
using Shared_Resources.Model.Ingredients;

namespace ServerTests.Server.Service.Ingredients.IngredientsServiceTests
{
    public class RemoveIngredientsFromPantryTests
    {
        [Test]
        public void ShouldNotRemoveIngredientsForNullSessionKey()
        {
            var ingredientsService = new IngredientsService();
            var message = Assert.Throws<UnauthorizedAccessException>(() =>
            {
                ingredientsService.RemoveIngredientsForRecipe(1, null!);
            })?.Message;
            Assert.That(message, Is.EqualTo("Session key cannot be null"));
        }

        [Test]
        public void ShouldNotRemoveIngredientsForEmptySessionKey()
        {
            var ingredientsService = new IngredientsService();
            var message = Assert.Throws<UnauthorizedAccessException>(() =>
            {
                ingredientsService.RemoveIngredientsForRecipe(1, "");
            })?.Message;
            Assert.That(message, Is.EqualTo("Session key cannot be empty"));
        }

        [Test]
        public void ShouldNotRemoveIngredientsIfSessionKeyDoesNotExist()
        {
            var mockUsersDal = new Mock<IUsersDal>();
            var mockIngredientsDal = new Mock<IIngredientsDal>();
            var mockRecipesDal = new Mock<IRecipesDal>();
            var service = new IngredientsService(mockUsersDal.Object, mockIngredientsDal.Object, mockRecipesDal.Object);

            mockUsersDal.Setup(x => x.VerifySessionKeyDoesNotExist("key")).Returns(true);

            var message = Assert.Throws<UnauthorizedAccessException>(() =>
            {
                service.RemoveIngredientsForRecipe(1, "key");
            })?.Message;

            Assert.That(message, Is.EqualTo("Session key must exist in the system."));
        }

        [Test]
        public void ShouldNotRemoveIngredientsIfUserIdDoesNotExist()
        {
            var mockUsersDal = new Mock<IUsersDal>();
            var mockIngredientsDal = new Mock<IIngredientsDal>();
            var mockRecipesDal = new Mock<IRecipesDal>();
            var service = new IngredientsService(mockUsersDal.Object, mockIngredientsDal.Object, mockRecipesDal.Object);

            mockUsersDal.Setup(x => x.GetIdForSessionKey("key")).Returns(1);
            mockUsersDal.Setup(x => x.UserIdExists(1)).Returns(false);
            mockUsersDal.Setup(x => x.VerifySessionKeyDoesNotExist("key")).Returns(false);

            mockIngredientsDal.Setup(x => x.RemoveIngredientFromPantry(It.IsAny<Ingredient>(), 1));
            mockIngredientsDal.Setup(x => x.UpdateIngredientInPantry(It.IsAny<Ingredient>(), 1));

            var message = Assert.Throws<UnauthorizedAccessException>(() =>
            {
                service.RemoveIngredientsForRecipe(1, "key");
            })?.Message;

            Assert.That(message, Is.EqualTo("User must exist in the system."));
        }

        [Test]
        public void ShouldRemoveIngredientsForEmptyPantryAndNoRecipeIngredients()
        {
            var mockUsersDal = new Mock<IUsersDal>();
            var mockIngredientsDal = new Mock<IIngredientsDal>();
            var mockRecipesDal = new Mock<IRecipesDal>();
            var service = new IngredientsService(mockUsersDal.Object, mockIngredientsDal.Object, mockRecipesDal.Object);

            mockUsersDal.Setup(x => x.GetIdForSessionKey("key")).Returns(1);
            mockUsersDal.Setup(x => x.UserIdExists(1)).Returns(true);
            mockUsersDal.Setup(x => x.VerifySessionKeyDoesNotExist("key")).Returns(false);

            mockRecipesDal.Setup(x => x.GetIngredientsForRecipe(1)).Returns(new Ingredient[0]);
            mockIngredientsDal.Setup(x => x.GetIngredientsFor(1)).Returns(new Ingredient[0]);

            mockIngredientsDal.Setup(x => x.RemoveIngredientFromPantry(It.IsAny<Ingredient>(), 1));
            mockIngredientsDal.Setup(x => x.UpdateIngredientInPantry(It.IsAny<Ingredient>(), 1));

            service.RemoveIngredientsForRecipe(1, "key");

            mockIngredientsDal.Verify(x => x.RemoveIngredientFromPantry(It.IsAny<Ingredient>(), 1), Times.Never);
            mockIngredientsDal.Verify(x => x.UpdateIngredientInPantry(It.IsAny<Ingredient>(), 1), Times.Never);
        }

        [Test]
        public void ShouldRemoveIngredientsForEmptyPantry()
        {
            var ingredients = new[]
            {
                new Ingredient("name1", 5, MeasurementType.Quantity),
                new Ingredient("name2", 15, MeasurementType.Quantity),
                new Ingredient("name3", 1, MeasurementType.Quantity)
            };

            var mockUsersDal = new Mock<IUsersDal>();
            var mockIngredientsDal = new Mock<IIngredientsDal>();
            var mockRecipesDal = new Mock<IRecipesDal>();
            var service = new IngredientsService(mockUsersDal.Object, mockIngredientsDal.Object, mockRecipesDal.Object);

            mockUsersDal.Setup(x => x.GetIdForSessionKey("key")).Returns(1);
            mockUsersDal.Setup(x => x.UserIdExists(1)).Returns(true);
            mockUsersDal.Setup(x => x.VerifySessionKeyDoesNotExist("key")).Returns(false);

            mockRecipesDal.Setup(x => x.GetIngredientsForRecipe(1)).Returns(ingredients);
            mockIngredientsDal.Setup(x => x.GetIngredientsFor(1)).Returns(new Ingredient[0]);

            mockIngredientsDal.Setup(x => x.RemoveIngredientFromPantry(It.IsAny<Ingredient>(), 1));
            mockIngredientsDal.Setup(x => x.UpdateIngredientInPantry(It.IsAny<Ingredient>(), 1));

            service.RemoveIngredientsForRecipe(1, "key");

            mockIngredientsDal.Verify(x => x.RemoveIngredientFromPantry(It.IsAny<Ingredient>(), 1), Times.Never);
            mockIngredientsDal.Verify(x => x.UpdateIngredientInPantry(It.IsAny<Ingredient>(), 1), Times.Never);
        }

        [Test]
        public void ShouldRemoveIngredientsForPantryWithSomeItems()
        {
            var ingredients = new[]
            {
                new Ingredient("name1", 5, MeasurementType.Quantity),
                new Ingredient("name2", 15, MeasurementType.Quantity),
                new Ingredient("name3", 1, MeasurementType.Quantity),
                new Ingredient("name4", 5, MeasurementType.Quantity),
                new Ingredient("name5", 5, MeasurementType.Quantity),
                new Ingredient("name6", 1, MeasurementType.Quantity)
            };

            var pantry = new[]
            {
                new Ingredient("name1", 5, MeasurementType.Quantity),
                new Ingredient("name3", 5, MeasurementType.Quantity),
                new Ingredient("name5", 2, MeasurementType.Quantity)
            };

            var mockUsersDal = new Mock<IUsersDal>();
            var mockIngredientsDal = new Mock<IIngredientsDal>();
            var mockRecipesDal = new Mock<IRecipesDal>();
            var service = new IngredientsService(mockUsersDal.Object, mockIngredientsDal.Object, mockRecipesDal.Object);

            mockUsersDal.Setup(x => x.GetIdForSessionKey("key")).Returns(1);
            mockUsersDal.Setup(x => x.UserIdExists(1)).Returns(true);
            mockUsersDal.Setup(x => x.VerifySessionKeyDoesNotExist("key")).Returns(false);

            mockRecipesDal.Setup(x => x.GetIngredientsForRecipe(1)).Returns(ingredients);
            mockIngredientsDal.Setup(x => x.GetIngredientsFor(1)).Returns(pantry);

            mockIngredientsDal.Setup(x => x.RemoveIngredientFromPantry(It.IsAny<Ingredient>(), 1));
            mockIngredientsDal.Setup(x => x.UpdateIngredientInPantry(It.IsAny<Ingredient>(), 1));

            service.RemoveIngredientsForRecipe(1, "key");

            mockIngredientsDal.Verify(x => x.RemoveIngredientFromPantry(ingredients[0], 1), Times.Once);
            mockIngredientsDal.Verify(x => x.RemoveIngredientFromPantry(ingredients[1], 1), Times.Never);
            mockIngredientsDal.Verify(x => x.UpdateIngredientInPantry(It.IsAny<Ingredient>(), 1), Times.Once);
            mockIngredientsDal.Verify(x => x.RemoveIngredientFromPantry(ingredients[3], 1), Times.Never);
            mockIngredientsDal.Verify(x => x.RemoveIngredientFromPantry(ingredients[4], 1), Times.Once);
            mockIngredientsDal.Verify(x => x.RemoveIngredientFromPantry(ingredients[5], 1), Times.Never);

        }

        [Test]
        public void ShouldRemoveIngredientsForPantryWithAllItems()
        {
            var ingredients = new[]
            {
                new Ingredient("name1", 5, MeasurementType.Quantity),
                new Ingredient("name2", 15, MeasurementType.Quantity),
                new Ingredient("name3", 1, MeasurementType.Quantity),
                new Ingredient("name4", 5, MeasurementType.Quantity),
                new Ingredient("name5", 5, MeasurementType.Quantity),
                new Ingredient("name6", 1, MeasurementType.Quantity)
            };

            var pantry = new[]
            {
                new Ingredient("name1", 1, MeasurementType.Quantity),
                new Ingredient("name2", 14, MeasurementType.Quantity),
                new Ingredient("name3", 1, MeasurementType.Quantity),
                new Ingredient("name4", 4, MeasurementType.Quantity),
                new Ingredient("name5", 3, MeasurementType.Quantity),
                new Ingredient("name6", 1, MeasurementType.Quantity)
            };

            var mockUsersDal = new Mock<IUsersDal>();
            var mockIngredientsDal = new Mock<IIngredientsDal>();
            var mockRecipesDal = new Mock<IRecipesDal>();
            var service = new IngredientsService(mockUsersDal.Object, mockIngredientsDal.Object, mockRecipesDal.Object);

            mockUsersDal.Setup(x => x.GetIdForSessionKey("key")).Returns(1);
            mockUsersDal.Setup(x => x.UserIdExists(1)).Returns(true);
            mockUsersDal.Setup(x => x.VerifySessionKeyDoesNotExist("key")).Returns(false);

            mockRecipesDal.Setup(x => x.GetIngredientsForRecipe(1)).Returns(ingredients);
            mockIngredientsDal.Setup(x => x.GetIngredientsFor(1)).Returns(pantry);

            mockIngredientsDal.Setup(x => x.RemoveIngredientFromPantry(It.IsAny<Ingredient>(), 1));
            mockIngredientsDal.Setup(x => x.UpdateIngredientInPantry(It.IsAny<Ingredient>(), 1));

            service.RemoveIngredientsForRecipe(1, "key");

            mockIngredientsDal.Verify(x => x.RemoveIngredientFromPantry(ingredients[0], 1), Times.Once);
            mockIngredientsDal.Verify(x => x.RemoveIngredientFromPantry(ingredients[1], 1), Times.Once);
            mockIngredientsDal.Verify(x => x.RemoveIngredientFromPantry(ingredients[2], 1), Times.Once);
            mockIngredientsDal.Verify(x => x.RemoveIngredientFromPantry(ingredients[3], 1), Times.Once);
            mockIngredientsDal.Verify(x => x.RemoveIngredientFromPantry(ingredients[4], 1), Times.Once);
            mockIngredientsDal.Verify(x => x.RemoveIngredientFromPantry(ingredients[5], 1), Times.Once);
        }
    }
}
