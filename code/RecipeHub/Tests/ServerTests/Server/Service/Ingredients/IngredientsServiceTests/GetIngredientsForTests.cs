using Moq;
using Server.DAL.Ingredients;
using Server.DAL.Recipes;
using Server.DAL.Users;
using Server.Service.Ingredients;
using Shared_Resources.Model.Ingredients;

namespace ServerTests.Server.Service.Ingredients.IngredientsServiceTests
{
    public class GetIngredientsForTests
    {
        [Test]
        public void SuccessfullyGetIngredients()
        {
            const int userId = 1;
            const string sessionKey = "Key";
            var ingredients = new List<Ingredient> {
                new()
            };

            var ingredientsDal = new Mock<IIngredientsDal>();
            var usersDal = new Mock<IUsersDal>();
            var mockRecipesDal = new Mock<IRecipesDal>();
            var service = new IngredientsService(usersDal.Object, ingredientsDal.Object, mockRecipesDal.Object);

            ingredientsDal.Setup(mock => mock.GetIngredientsFor(userId)).Returns(ingredients);
            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(userId);
            usersDal.Setup(mock => mock.UserIdExists(userId)).Returns(true);

            var result = service.GetIngredientsFor(sessionKey);

            usersDal.Verify(mock => mock.GetIdForSessionKey(sessionKey), Times.Once());
            ingredientsDal.Verify(mock => mock.GetIngredientsFor(userId), Times.Once);
            Assert.That(result, Is.EquivalentTo(ingredients));
        }

        [Test]
        public void NullSessionKey()
        {
            const string sessionKey = null!;

            Assert.Throws<UnauthorizedAccessException>(() => 
                new IngredientsService().GetIngredientsFor(sessionKey!));
        }

        [Test]
        public void EmptySessionKey()
        {
            const string sessionKey = "";
            Assert.Throws<UnauthorizedAccessException>(() => new IngredientsService().GetIngredientsFor(sessionKey));
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

            Assert.Throws<ArgumentException>(() => service.GetIngredientsFor(sessionKey));
        }
    }
}