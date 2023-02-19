using Moq;
using Server.DAL.Ingredients;
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
            ingredientsDal.Setup(mock => mock.GetIngredientsFor(userId)).Returns(ingredients);
            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(userId);
            usersDal.Setup(mock => mock.UserIdExists(userId)).Returns(true);

            var service = new IngredientsService(usersDal.Object, ingredientsDal.Object);
            var result = service.GetIngredientsFor(sessionKey);

            usersDal.Verify(mock => mock.GetIdForSessionKey(sessionKey), Times.Once());
            ingredientsDal.Verify(mock => mock.GetIngredientsFor(userId), Times.Once);
            Assert.That(result, Is.EquivalentTo(ingredients));
        }

        [Test]
        public void NullSessionKey()
        {
            const string sessionKey = null!;

            Assert.Throws<ArgumentNullException>(() =>
                new IngredientsService().GetIngredientsFor(sessionKey!));
        }

        [Test]
        public void EmptySessionKey()
        {
            const string sessionKey = "";
            Assert.Throws<ArgumentException>(() => new IngredientsService().GetIngredientsFor(sessionKey));
        }

        [Test]
        public void SessionKeyIsUnused()
        {
            const string sessionKey = "Key";

            var ingredientsDal = new Mock<IIngredientsDal>();
            var usersDal = new Mock<IUsersDal>();
            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns((int?) null);

            var service = new IngredientsService(usersDal.Object, ingredientsDal.Object);
            Assert.Throws<ArgumentException>(() => service.GetIngredientsFor(sessionKey));
        }
    }
}