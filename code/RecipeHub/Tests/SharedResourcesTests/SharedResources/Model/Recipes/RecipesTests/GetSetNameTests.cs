using Shared_Resources.Model.Recipes;

namespace SharedResourcesTests.SharedResources.Model.Recipes.RecipesTests
{
    public class GetSetNameTests
    {
        [Test]
        public void AssignNonNullName()
        {
            const string name = "name";

            var recipe = new Recipe {
                Name = name
            };

            Assert.That(recipe.Name, Is.EqualTo(name));
        }

        [Test]
        public void AssignNullName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _ = new Recipe { Name = null! };
            });
        }
    }
}