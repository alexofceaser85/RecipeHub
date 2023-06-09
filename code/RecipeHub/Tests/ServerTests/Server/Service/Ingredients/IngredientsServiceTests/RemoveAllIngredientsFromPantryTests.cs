﻿using Moq;
using Server.DAL.Ingredients;
using Server.DAL.Recipes;
using Server.DAL.Users;
using Server.Service.Ingredients;

namespace ServerTests.Server.Service.Ingredients.IngredientsServiceTests
{
    public class RemoveAllIngredientsFromPantryTests
    {
        [Test]
        public void SuccessfullyGetIngredients()
        {
            const int userId = 1;
            const string sessionKey = "Key";

            var ingredientsDal = new Mock<IIngredientsDal>();
            var usersDal = new Mock<IUsersDal>();
            var mockRecipesDal = new Mock<IRecipesDal>();
            var service = new IngredientsService(usersDal.Object, ingredientsDal.Object, mockRecipesDal.Object);

            ingredientsDal.Setup(mock => mock.RemoveAllIngredientsFromPantry(userId)).Returns(true);
            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(userId);
            usersDal.Setup(mock => mock.UserIdExists(userId)).Returns(true);

            var result = service.RemoveAllIngredientsFromPantry(sessionKey);

            usersDal.Verify(mock => mock.GetIdForSessionKey(sessionKey), Times.Once());
            ingredientsDal.Verify(mock => mock.RemoveAllIngredientsFromPantry(userId), Times.Once);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void NullSessionKey()
        {
            const string sessionKey = null!;

            Assert.Throws<UnauthorizedAccessException>(() => 
                new IngredientsService().RemoveAllIngredientsFromPantry(sessionKey!));
        }

        [Test]
        public void EmptySessionKey()
        {
            const string sessionKey = "";
            Assert.Throws<UnauthorizedAccessException>(() => new IngredientsService().RemoveAllIngredientsFromPantry(sessionKey));
        }

        [Test]
        public void SessionKeyIsUnused()
        {
            const string sessionKey = "Key";

            var ingredientsDal = new Mock<IIngredientsDal>();
            var usersDal = new Mock<IUsersDal>();
            var mockRecipesDal = new Mock<IRecipesDal>();
            var service = new IngredientsService(usersDal.Object, ingredientsDal.Object, mockRecipesDal.Object);

            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns((int?) null);

            Assert.Throws<ArgumentException>(() => service.RemoveAllIngredientsFromPantry(sessionKey));
        }
    }
}