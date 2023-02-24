using Moq;
using Server.DAL.RecipeTypes;
using Server.Service.RecipeTypes;

namespace ServerTests.Server.Service.RecipeTypes
{
    public class GetAllRecipeTypesTests
    {
        [Test]
        public void ShouldGetAllRecipeTypes()
        {
            var content = new[] { "type1", "type2", "type3" };
            var dal = new Mock<IRecipeTypesDal>();
            var service = new RecipeTypesService(dal.Object);

            dal.Setup(mock => mock.GetAllRecipeTypes()).Returns(content);
            var actual = service.GetAllRecipeTypes();

            Assert.That(actual, Is.EqualTo(content));
        }
    }
}
