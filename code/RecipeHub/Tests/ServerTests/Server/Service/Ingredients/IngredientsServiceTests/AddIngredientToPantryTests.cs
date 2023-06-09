﻿using Moq;
using Server.DAL.Ingredients;
using Server.DAL.Recipes;
using Server.DAL.Users;
using Server.Service.Ingredients;
using Shared_Resources.Model.Ingredients;

namespace ServerTests.Server.Service.Ingredients.IngredientsServiceTests
{
    public class AddIngredientToPantryTests
    {
        [Test]
        public void SuccessfullyAddedIngredient()
        {
            const int userId = 1;
            const string sessionKey = "Key";
            var ingredient = new Ingredient("name", 1, MeasurementType.Volume);

            var ingredientsDal = new Mock<IIngredientsDal>();
            var usersDal = new Mock<IUsersDal>();
            var mockRecipesDal = new Mock<IRecipesDal>();
            var service = new IngredientsService(usersDal.Object, ingredientsDal.Object, mockRecipesDal.Object);

            ingredientsDal.Setup(mock => mock.AddIngredientToPantry(ingredient, userId)).Returns(true);
            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(userId);
            usersDal.Setup(mock => mock.UserIdExists(userId)).Returns(true);

            var result = service.AddIngredientToPantry(ingredient, sessionKey);

            usersDal.Verify(mock => mock.GetIdForSessionKey(sessionKey), Times.Once());
            ingredientsDal.Verify(mock => mock.AddIngredientToPantry(ingredient, userId), Times.Once);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void NullSessionKey()
        {
            const string sessionKey = null!;
            var ingredient = new Ingredient("name", 1, MeasurementType.Volume);

            Assert.Throws<UnauthorizedAccessException>(() => 
                new IngredientsService().AddIngredientToPantry(ingredient, sessionKey!));
        }

        [Test]
        public void EmptySessionKey()
        {
            const string sessionKey = "";
            var ingredient = new Ingredient("name", 1, MeasurementType.Volume);
            Assert.Throws<UnauthorizedAccessException>(() => new IngredientsService().AddIngredientToPantry(ingredient, sessionKey));
        }

        [Test]
        public void NullIngredientName()
        {
            const string sessionKey = "Key";
            var ingredient = new Ingredient();
            Assert.Throws<ArgumentNullException>(() =>
                new IngredientsService().AddIngredientToPantry(ingredient, sessionKey));
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

            Assert.Throws<InvalidOperationException>(() => service.AddIngredientToPantry(ingredient, sessionKey));
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

            ingredientsDal.Setup(mock => mock.AddIngredientToPantry(ingredient, userId)).Returns(true);
            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(userId);
            usersDal.Setup(mock => mock.UserIdExists(userId)).Returns(false);

            Assert.Throws<ArgumentException>(() => service.AddIngredientToPantry(ingredient, sessionKey));
        }

        [Test]
        public void IngredientAlreadyInPantry()
        {
            const int userId = 1;
            const string sessionKey = "Key";
            var ingredient = new Ingredient("name", 1, MeasurementType.Volume);

            var ingredientsDal = new Mock<IIngredientsDal>();
            var usersDal = new Mock<IUsersDal>();
            var mockRecipesDal = new Mock<IRecipesDal>();
            var service = new IngredientsService(usersDal.Object, ingredientsDal.Object, mockRecipesDal.Object);

            ingredientsDal.Setup(mock => mock.AddIngredientToPantry(ingredient, userId)).Returns(true);
            ingredientsDal.Setup(mock => mock.IsIngredientInPantry(ingredient.Name, userId)).Returns(true);
            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(userId);
            usersDal.Setup(mock => mock.UserIdExists(userId)).Returns(true);

            Assert.Throws<ArgumentException>(() => service.AddIngredientToPantry(ingredient, sessionKey));
        }
    }
}