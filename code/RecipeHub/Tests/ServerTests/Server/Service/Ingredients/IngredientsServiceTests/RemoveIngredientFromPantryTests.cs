using Moq;
using Server.DAL.Ingredients;
using Server.DAL.Recipes;
using Server.DAL.Users;
using Server.Service.Ingredients;
using Shared_Resources.Model.Ingredients;

namespace ServerTests.Server.Service.Ingredients.IngredientsServiceTests
{
    public class RemoveIngredientFromPantryTests
    {
        [Test]
        public void SuccessfullyRemovedIngredient()
        {
            const int userId = 1;
            const string sessionKey = "Key";
            var ingredient = new Ingredient("name", 1, MeasurementType.Volume);

            var ingredientsDal = new Mock<IIngredientsDal>();
            var usersDal = new Mock<IUsersDal>();
            var mockRecipesDal = new Mock<IRecipesDal>();
            var service = new IngredientsService(usersDal.Object, ingredientsDal.Object, mockRecipesDal.Object);

            ingredientsDal.Setup(mock => mock.RemoveIngredientFromPantry(ingredient, userId)).Returns(true);
            ingredientsDal.Setup(mock => mock.IsIngredientInSystem(ingredient.Name)).Returns(true);
            ingredientsDal.Setup(mock => mock.IsIngredientInPantry(ingredient.Name, userId)).Returns(true);
            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(userId);
            usersDal.Setup(mock => mock.UserIdExists(userId)).Returns(true);

            var result = service.RemoveIngredientFromPantry(ingredient, sessionKey);

            usersDal.Verify(mock => mock.GetIdForSessionKey(sessionKey), Times.Once());
            ingredientsDal.Verify(mock => mock.RemoveIngredientFromPantry(ingredient, userId), Times.Once);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void NullSessionKey()
        {
            const string sessionKey = null!;
            var ingredient = new Ingredient("name", 1, MeasurementType.Volume);

            Assert.Throws<UnauthorizedAccessException>(() => 
                new IngredientsService().RemoveIngredientFromPantry(ingredient, sessionKey!));
        }

        [Test]
        public void EmptySessionKey()
        {
            const string sessionKey = "";
            var ingredient = new Ingredient("name", 1, MeasurementType.Volume);
            Assert.Throws<UnauthorizedAccessException>(() => new IngredientsService().RemoveIngredientFromPantry(ingredient, sessionKey));
        }

        [Test]
        public void NullIngredientName()
        {
            const string sessionKey = "Key";
            var ingredient = new Ingredient();
            Assert.Throws<ArgumentNullException>(() =>
                new IngredientsService().RemoveIngredientFromPantry(ingredient, sessionKey));
        }

        [Test]
        public void SessionKeyIsUnused()
        {
            const string sessionKey = "Key";
            var ingredient = new Ingredient("name", 1, MeasurementType.Volume);

            var ingredientsDal = new Mock<IIngredientsDal>();
            var usersDal = new Mock<IUsersDal>();
            var mockRecipesDal = new Mock<IRecipesDal>();
            var service = new IngredientsService(usersDal.Object, ingredientsDal.Object, mockRecipesDal.Object);

            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns((int?) null);

            Assert.Throws<ArgumentException>(() => service.RemoveIngredientFromPantry(ingredient, sessionKey));
        }

        [Test]
        public void UserDoesNotExist()
        {
            const int userId = 1;
            const string sessionKey = "Key";
            var ingredient = new Ingredient("name", 1, MeasurementType.Volume);

            var ingredientsDal = new Mock<IIngredientsDal>();
            var usersDal = new Mock<IUsersDal>();
            var mockRecipesDal = new Mock<IRecipesDal>();
            var service = new IngredientsService(usersDal.Object, ingredientsDal.Object, mockRecipesDal.Object);

            ingredientsDal.Setup(mock => mock.RemoveIngredientFromPantry(ingredient, userId)).Returns(true);
            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(userId);
            usersDal.Setup(mock => mock.UserIdExists(userId)).Returns(false);

            Assert.Throws<ArgumentException>(() => service.RemoveIngredientFromPantry(ingredient, sessionKey));
        }

        [Test]
        public void IngredientNotInPantry()
        {
            const int userId = 1;
            const string sessionKey = "Key";
            var ingredient = new Ingredient("name", 1, MeasurementType.Volume);

            var ingredientsDal = new Mock<IIngredientsDal>();
            var usersDal = new Mock<IUsersDal>();
            var mockRecipesDal = new Mock<IRecipesDal>();
            var service = new IngredientsService(usersDal.Object, ingredientsDal.Object, mockRecipesDal.Object);

            ingredientsDal.Setup(mock => mock.RemoveIngredientFromPantry(ingredient, userId)).Returns(true);
            ingredientsDal.Setup(mock => mock.IsIngredientInSystem(ingredient.Name)).Returns(true);
            ingredientsDal.Setup(mock => mock.IsIngredientInPantry(ingredient.Name, userId)).Returns(false);
            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(userId);
            usersDal.Setup(mock => mock.UserIdExists(userId)).Returns(true);

            Assert.Throws<ArgumentException>(() => service.RemoveIngredientFromPantry(ingredient, sessionKey));
        }

        [Test]
        public void IngredientNotInSystem()
        {
            const int userId = 1;
            const string sessionKey = "Key";
            var ingredient = new Ingredient("name", 1, MeasurementType.Volume);

            var ingredientsDal = new Mock<IIngredientsDal>();
            var usersDal = new Mock<IUsersDal>();
            var mockRecipesDal = new Mock<IRecipesDal>();
            var service = new IngredientsService(usersDal.Object, ingredientsDal.Object, mockRecipesDal.Object);

            ingredientsDal.Setup(mock => mock.RemoveIngredientFromPantry(ingredient, userId)).Returns(true);
            ingredientsDal.Setup(mock => mock.IsIngredientInPantry(ingredient.Name, userId)).Returns(true);
            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(userId);
            usersDal.Setup(mock => mock.UserIdExists(userId)).Returns(true);

            Assert.Throws<ArgumentException>(() => service.RemoveIngredientFromPantry(ingredient, sessionKey));
        }
    }
}