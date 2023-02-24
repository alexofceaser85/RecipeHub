using Moq;
using Server.DAL.Recipes;
using Server.DAL.RecipeTypes;
using Server.DAL.Users;
using Server.ErrorMessages;
using Server.Service.Recipes;
using Shared_Resources.Model.Recipes;

namespace ServerTests.Server.Service.Recipes.RecipesServiceTests
{
    public class GetsRecipesForTypeTests
    {
        [Test]
        public void ShouldNotGetRecipesForNullSessionKey()
        {
            var service = new RecipesService();
            var message = Assert.Throws<UnauthorizedAccessException>(() =>
            {
                service.GetRecipesForType(null!, "tag1,tag2,tag3");
            })?.Message;
            Assert.That(message, Is.EqualTo(ServerRecipesServiceErrorMessages.SessionKeyCannotBeNull));
        }

        [Test]
        public void ShouldNotGetRecipesForEmptySessionKey()
        {
            var service = new RecipesService();
            var message = Assert.Throws<UnauthorizedAccessException>(() =>
            {
                service.GetRecipesForType("   ", "tag1,tag2,tag3");
            })?.Message;
            Assert.That(message, Is.EqualTo(ServerRecipesServiceErrorMessages.SessionKeyCannotBeEmpty));
        }

        [Test]
        public void ShouldNotGetRecipesForNullTags()
        {
            var service = new RecipesService();
            var message = Assert.Throws<ArgumentException>(() =>
            {
                service.GetRecipesForType("Key", null!);
            })?.Message;
            Assert.That(message, Is.EqualTo(ServerRecipesServiceErrorMessages.TagsCannotBeNull));
        }

        [Test]
        public void ShouldNotGetRecipesForEmptyTags()
        {
            var service = new RecipesService();
            var message = Assert.Throws<ArgumentException>(() =>
            {
                service.GetRecipesForType("Key", "   ");
            })?.Message;
            Assert.That(message, Is.EqualTo(ServerRecipesServiceErrorMessages.TagsCannotBeEmpty));
        }

        [Test]
        public void ShouldReturnRecipesMatchingTags()
        {
            var recipesDal = new Mock<IRecipesDal>();
            var usersDal = new Mock<IUsersDal>();
            var recipeTypesDal = new Mock<IRecipeTypesDal>();

            var recipes = new[]
            {
                new Recipe(4, "me", "recipe4", "desc4", true),
                new Recipe(5, "me", "recipe5", "desc5", true),
                new Recipe(6, "me", "recipe6", "desc6", true)
            };

            var service = new RecipesService(recipesDal.Object, usersDal.Object, recipeTypesDal.Object);
            var tags = "tag1,tag2,tag3";

            recipeTypesDal.Setup(mock => mock.GetTypeIdForTypeName("tag1")).Returns(1);
            recipeTypesDal.Setup(mock => mock.GetTypeIdForTypeName("tag2")).Returns(2);
            recipeTypesDal.Setup(mock => mock.GetTypeIdForTypeName("tag3")).Returns(3);

            recipeTypesDal.Setup(mock => mock.GetRecipeIdsForTypeIds(new[] { 1, 2, 3 })).Returns(new[] { 4, 5, 6 });

            usersDal.Setup(mock => mock.GetIdForSessionKey("Key")).Returns(100);

            recipesDal.Setup(mock => mock.UserCanSeeRecipe(100, 4)).Returns(true);
            recipesDal.Setup(mock => mock.UserCanSeeRecipe(100, 5)).Returns(true);
            recipesDal.Setup(mock => mock.UserCanSeeRecipe(100, 6)).Returns(true);

            recipesDal.Setup(mock => mock.GetRecipe(4)).Returns(recipes[0]);
            recipesDal.Setup(mock => mock.GetRecipe(5)).Returns(recipes[1]);
            recipesDal.Setup(mock => mock.GetRecipe(6)).Returns(recipes[2]);

            var returnedRecipes = service.GetRecipesForType("Key", tags);
            Assert.That(returnedRecipes, Is.EqualTo(recipes));
        }

        [Test]
        public void ShouldHandleNullTypes()
        {
            var recipesDal = new Mock<IRecipesDal>();
            var usersDal = new Mock<IUsersDal>();
            var recipeTypesDal = new Mock<IRecipeTypesDal>();

            var recipes = new[]
            {
                new Recipe(4, "me", "recipe4", "desc4", true),
                new Recipe(5, "me", "recipe5", "desc5", true),
                new Recipe(6, "me", "recipe6", "desc6", true)
            };

            var recipesActual = new[]
            {
                new Recipe(4, "me", "recipe4", "desc4", true),
                new Recipe(6, "me", "recipe6", "desc6", true)
            };

            var service = new RecipesService(recipesDal.Object, usersDal.Object, recipeTypesDal.Object);
            var tags = "tag1,tag2,tag3";

            recipeTypesDal.Setup(mock => mock.GetTypeIdForTypeName("tag1")).Returns(1);
            recipeTypesDal.Setup(mock => mock.GetTypeIdForTypeName("tag2")).Returns((int?)null);
            recipeTypesDal.Setup(mock => mock.GetTypeIdForTypeName("tag3")).Returns(3);

            recipeTypesDal.Setup(mock => mock.GetRecipeIdsForTypeIds(new[] { 1, 3 })).Returns(new[] { 4, 6 });

            usersDal.Setup(mock => mock.GetIdForSessionKey("Key")).Returns(100);

            recipesDal.Setup(mock => mock.UserCanSeeRecipe(100, 4)).Returns(true);
            recipesDal.Setup(mock => mock.UserCanSeeRecipe(100, 5)).Returns(true);
            recipesDal.Setup(mock => mock.UserCanSeeRecipe(100, 6)).Returns(true);

            recipesDal.Setup(mock => mock.GetRecipe(4)).Returns(recipes[0]);
            recipesDal.Setup(mock => mock.GetRecipe(5)).Returns(recipes[1]);
            recipesDal.Setup(mock => mock.GetRecipe(6)).Returns(recipes[2]);

            recipesDal.Verify(mock => mock.UserCanSeeRecipe(100, 5), Times.Never);
            recipesDal.Verify(mock => mock.GetRecipe(5), Times.Never);

            var returnedRecipes = service.GetRecipesForType("Key", tags);
            Assert.That(returnedRecipes, Is.EqualTo(recipesActual));
        }

        [Test]
        public void ShouldHandleErrorInGettingRecipeId()
        {
            var recipesDal = new Mock<IRecipesDal>();
            var usersDal = new Mock<IUsersDal>();
            var recipeTypesDal = new Mock<IRecipeTypesDal>();

            var recipes = new[]
            {
                new Recipe(4, "me", "recipe4", "desc4", true),
                new Recipe(5, "me", "recipe5", "desc5", true),
                new Recipe(6, "me", "recipe6", "desc6", true)
            };

            var recipesActual = new[]
            {
                new Recipe(4, "me", "recipe4", "desc4", true),
                new Recipe(6, "me", "recipe6", "desc6", true)
            };

            var service = new RecipesService(recipesDal.Object, usersDal.Object, recipeTypesDal.Object);
            var tags = "tag1,tag2,tag3";

            recipeTypesDal.Setup(mock => mock.GetTypeIdForTypeName("tag1")).Returns(1);
            recipeTypesDal.Setup(mock => mock.GetTypeIdForTypeName("tag2")).Returns(2);
            recipeTypesDal.Setup(mock => mock.GetTypeIdForTypeName("tag3")).Returns(3);

            recipeTypesDal.Setup(mock => mock.GetRecipeIdsForTypeIds(new[] { 1, 2, 3 })).Returns(new[] { 4, 5, 6 });

            usersDal.Setup(mock => mock.GetIdForSessionKey("Key")).Returns(100);

            recipesDal.Setup(mock => mock.UserCanSeeRecipe(100, 4)).Returns(true);
            recipesDal.Setup(mock => mock.UserCanSeeRecipe(100, 5)).Returns(false);
            recipesDal.Setup(mock => mock.UserCanSeeRecipe(100, 6)).Returns(true);

            recipesDal.Setup(mock => mock.GetRecipe(4)).Returns(recipes[0]);
            recipesDal.Setup(mock => mock.GetRecipe(5)).Returns(recipes[1]);
            recipesDal.Setup(mock => mock.GetRecipe(6)).Returns(recipes[2]);

            recipesDal.Verify(mock => mock.UserCanSeeRecipe(100, 5), Times.Never);
            recipesDal.Verify(mock => mock.GetRecipe(5), Times.Never);

            var returnedRecipes = service.GetRecipesForType("Key", tags);
            Assert.That(returnedRecipes, Is.EqualTo(recipesActual));
        }
    }
}
