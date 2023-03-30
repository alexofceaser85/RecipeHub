using Moq;
using Server.DAL.Ingredients;
using Server.DAL.Recipes;
using Server.DAL.Users;
using Server.Service.Ingredients;
using Shared_Resources.Model.Ingredients;

namespace ServerTests.Server.Service.Ingredients.IngredientsServiceTests
{
    public class GetMissingIngredientsForRecipeTests
    {
        [Test]
        public void ShouldNotGetMissingIngredientsForNullSessionKey()
        {
            var ingredientsService = new IngredientsService();
            var message = Assert.Throws<UnauthorizedAccessException>(() =>
            {
                ingredientsService.GetMissingIngredientsForRecipe(1, null!);
            })?.Message;
            Assert.That(message, Is.EqualTo("Session key cannot be null"));
        }

        [Test]
        public void ShouldNotGetMissingIngredientsForEmptySessionKey()
        {
            var ingredientsService = new IngredientsService();
            var message = Assert.Throws<UnauthorizedAccessException>(() =>
            {
                ingredientsService.GetMissingIngredientsForRecipe(1, "");
            })?.Message;
            Assert.That(message, Is.EqualTo("Session key cannot be empty"));
        }

        [Test]
        public void ShouldNotGetMissingIngredientsIfSessionKeyDoesNotExist()
        {
            var mockUsersDal = new Mock<IUsersDal>();
            var mockIngredientsDal = new Mock<IIngredientsDal>();
            var mockRecipesDal = new Mock<IRecipesDal>();
            var service = new IngredientsService(mockUsersDal.Object, mockIngredientsDal.Object, mockRecipesDal.Object);

            mockUsersDal.Setup(x => x.VerifySessionKeyDoesNotExist("key")).Returns(true);

            var message = Assert.Throws<UnauthorizedAccessException>(() =>
            {
                service.GetMissingIngredientsForRecipe(1, "key");
            })?.Message;

            Assert.That(message, Is.EqualTo("Session key must exist in the system."));
        }

        [Test]
        public void ShouldNotGetMissingIngredientsIfUserIdDoesNotExist()
        {
            var mockUsersDal = new Mock<IUsersDal>();
            var mockIngredientsDal = new Mock<IIngredientsDal>();
            var mockRecipesDal = new Mock<IRecipesDal>();
            var service = new IngredientsService(mockUsersDal.Object, mockIngredientsDal.Object, mockRecipesDal.Object);

            mockUsersDal.Setup(x => x.GetIdForSessionKey("key")).Returns(1);
            mockUsersDal.Setup(x => x.UserIdExists(1)).Returns(false);
            mockUsersDal.Setup(x => x.VerifySessionKeyDoesNotExist("key")).Returns(false);

            var message = Assert.Throws<UnauthorizedAccessException>(() =>
            {
                service.GetMissingIngredientsForRecipe(1, "key");
            })?.Message;

            Assert.That(message, Is.EqualTo("User must exist in the system."));
        }

        [Test]
        public void ShouldGetMissingIngredientsForEmptyPantryAndNoRecipeIngredients()
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

            var missingIngredients = service.GetMissingIngredientsForRecipe(1, "key");

            Assert.That(new Ingredient[0], Is.EqualTo(missingIngredients));
        }

        [Test]
        public void ShouldGetMissingIngredientsForEmptyPantry()
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

            var missingIngredients = service.GetMissingIngredientsForRecipe(1, "key");

            Assert.That(ingredients, Is.EqualTo(missingIngredients));
        }

        [Test]
        public void ShouldGetMissingIngredientsForPantryWithSomeItems()
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

            var expected = new[]
            {
                new Ingredient("name2", 15, MeasurementType.Quantity),
                new Ingredient("name4", 5, MeasurementType.Quantity),
                new Ingredient("name5", 3, MeasurementType.Quantity),
                new Ingredient("name6", 1, MeasurementType.Quantity),
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

            var missingIngredients = service.GetMissingIngredientsForRecipe(1, "key");

            Assert.That(expected, Is.EqualTo(missingIngredients));

        }

        [Test]
        public void ShouldGetMissingIngredientsForPantryWithAllItems()
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

            var expected = new[]
            {
                new Ingredient("name1", 4, MeasurementType.Quantity),
                new Ingredient("name2", 1, MeasurementType.Quantity),
                new Ingredient("name4", 1, MeasurementType.Quantity),
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

            var missingIngredients = service.GetMissingIngredientsForRecipe(1, "key");

            Assert.That(expected, Is.EqualTo(missingIngredients));
        }
    }
}
