using Moq;
using Server.DAL.Recipes;
using Server.DAL.RecipeTypes;
using Server.DAL.Users;
using Server.Service.Recipes;

namespace ServerTests.Server.Service.Recipes.RecipesServiceTests
{
    public class AddRecipeTests
    {
        [Test]
        public void SuccessfullyAddRecipe()
        {
            const int authorId = 1;
            const string name = "name";
            const string description = "description";
            const bool isPublic = false;
            const string sessionKey = "Key";

            var recipesDal = new Mock<IRecipesDal>();
            var usersDal = new Mock<IUsersDal>();
            var recipeTypesDal = new Mock<IRecipeTypesDal>();

            recipesDal.Setup(mock => mock.AddRecipe(authorId, name, description, isPublic)).Returns(true);
            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(authorId);

            var service = new RecipesService(recipesDal.Object, usersDal.Object, recipeTypesDal.Object);
            var result = service.AddRecipe(sessionKey, name, description, isPublic);

            usersDal.Verify(mock => mock.GetIdForSessionKey(sessionKey), Times.Once());
            recipesDal.Verify(mock => mock.AddRecipe(authorId, name, description, isPublic), Times.Once);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void NullSessionKey()
        {
            const string sessionKey = null!;
            const string name = "name";
            const string description = "description";
            const bool isPublic = false;
            Assert.Throws<UnauthorizedAccessException>(() => new RecipesService().AddRecipe(sessionKey!, name, description, isPublic));
        }
        
        [Test]
        public void EmptySessionKey()
        {
            const string sessionKey = "";
            const string name = "name";
            const string description = "description";
            const bool isPublic = false;
            Assert.Throws<UnauthorizedAccessException>(() => new RecipesService().AddRecipe(sessionKey, name, description, isPublic));
        }

        [Test]
        public void NullRecipeName()
        {
            const string sessionKey = "Key";
            const string name = null!;
            const string description = "description";
            const bool isPublic = false;
            Assert.Throws<ArgumentNullException>(() => new RecipesService().AddRecipe(sessionKey, name!, description, isPublic));
        }

        [Test]
        public void EmptyRecipeName()
        {
            const string sessionKey = "Key";
            const string name = "";
            const string description = "description";
            const bool isPublic = false;
            Assert.Throws<ArgumentException>(() => new RecipesService().AddRecipe(sessionKey, name, description, isPublic));
        }

        [Test]
        public void NullRecipeDescription()
        {
            const string sessionKey = "Key";
            const string name = "name";
            const string description = null!;
            const bool isPublic = false;
            Assert.Throws<ArgumentNullException>(() => new RecipesService().AddRecipe(sessionKey, name, description!, isPublic));
        }

        [Test]
        public void EmptyRecipeDescription()
        {
            const string sessionKey = "Key";
            const string name = "name";
            const string description = "";
            const bool isPublic = false;
            Assert.Throws<ArgumentException>(() => new RecipesService().AddRecipe(sessionKey, name, description, isPublic));
        }

        [Test]
        public void SessionKeyIsUnused()
        {
            const string sessionKey = "Key"; 
            const string name = "name";
            const string description = "description";
            const bool isPublic = false;

            var recipesDal = new Mock<IRecipesDal>();
            var usersDal = new Mock<IUsersDal>();
            var recipeTypesDal = new Mock<RecipeTypesDal>();
            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns((int?)null);

            var service = new RecipesService(recipesDal.Object, usersDal.Object, recipeTypesDal.Object);
            Assert.Throws<UnauthorizedAccessException>(() => service.AddRecipe(sessionKey, name, description, isPublic));
            
        }
    }
}
