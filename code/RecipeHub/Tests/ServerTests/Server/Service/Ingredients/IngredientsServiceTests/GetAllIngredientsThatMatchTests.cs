using Moq;
using Server.DAL.Ingredients;
using Server.DAL.Users;
using Server.Service.Ingredients;

namespace ServerTests.Server.Service.Ingredients.IngredientsServiceTests
{
    public class GetAllIngredientsThatMatchTests
    {
        [Test]
        public void SuccessfullyGetMatchingIngredients()
        {
            const string name = "name";

            var ingredientsDal = new Mock<IIngredientsDal>();
            var usersDal = new Mock<IUsersDal>();
            ingredientsDal.Setup(mock => mock.GetIngredientNamesThatMatchText(name)).Returns(new List<string>());

            var service = new IngredientsService(usersDal.Object, ingredientsDal.Object);
            var result = service.GetAllIngredientsThatMatch(name);

            ingredientsDal.Verify(mock => mock.GetIngredientNamesThatMatchText(name), Times.Once);
            Assert.That(result, Is.EquivalentTo(new List<string>()));
        }

        [Test]
        public void NullSessionKey()
        {
            const string name = null!;

            Assert.Throws<ArgumentNullException>(() =>
                new IngredientsService().GetIngredientsFor(name!));
        }
    }
}