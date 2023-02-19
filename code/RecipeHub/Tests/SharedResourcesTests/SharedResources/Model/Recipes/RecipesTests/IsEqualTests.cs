using Shared_Resources.Model.Recipes;

namespace SharedResourcesTests.SharedResources.Model.Recipes.RecipesTests
{
    public class IsEqualTests
    {
        [Test]
        public void TwoObjectsAreEqual()
        {
            const int id = 0;
            const string authorName = "author name";
            const string name = "name";
            const string description = "description";
            const bool isPublic = false;

            var recipe1 = new Recipe(id, authorName, name, description, isPublic);
            var recipe2 = new Recipe(id, authorName, name, description, isPublic);

            Assert.That(recipe1, Is.EqualTo(recipe2));
        }

        [Test]
        public void TwoRecipesAreNotEqual()
        {
            const int id = 0;
            const string authorName = "author name";
            const string name = "name";
            const string description = "description";
            const bool isPublic = false;

            var recipe1 = new Recipe(id, authorName, name, description, isPublic);
            var recipe2 = new Recipe(id, authorName, name, description, !isPublic);

            Assert.That(recipe1, Is.Not.EqualTo(recipe2));
        }

        [Test]
        public void RecipeIsNotEqualToNonRecipe()
        {
            const int id = 0;
            const string authorName = "author name";
            const string name = "name";
            const string description = "description";
            const bool isPublic = false;

            var recipe = new Recipe(id, authorName, name, description, isPublic);
            var obj = new object();

            Assert.That(recipe, Is.Not.EqualTo(obj));
        }
    }
}