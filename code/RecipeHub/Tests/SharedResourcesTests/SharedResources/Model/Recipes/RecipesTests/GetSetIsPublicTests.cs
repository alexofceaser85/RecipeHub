using Shared_Resources.Model.Recipes;

namespace SharedResourcesTests.SharedResources.Model.Recipes.RecipesTests
{
    public class GetSetIsPublicTests
    {
        [Test]
        public void AssignIsPublic()
        {
            var recipe = new Recipe {
                IsPublic = true
            };

            Assert.That(recipe.IsPublic, Is.EqualTo(true));
        }
    }
}