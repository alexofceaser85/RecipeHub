using Shared_Resources.Model.Recipes;

namespace SharedResourcesTests.SharedResources.Model.Recipes.RecipesTests
{
    public class GetSetRatingsTests
    {
        [Test]
        public void AssignDescription()
        {
            var recipe = new Recipe {
                Rating = 5
            };

            Assert.That(recipe.Rating, Is.EqualTo(5));
        }
    }
}