using Shared_Resources.Model.Recipes;

namespace SharedResourcesTests.SharedResources.Model.Recipes.RecipesTests
{
    public class GetSetDescriptionTests
    {
        [Test]
        public void AssignNonNullName()
        {
            const string description = "description";

            var recipe = new Recipe {
                Description = description
            };

            Assert.That(recipe.Description, Is.EqualTo(description));
        }

        [Test]
        public void AssignNullName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _ = new Recipe {
                    Description = null!
                };
            });
        }
    }
}