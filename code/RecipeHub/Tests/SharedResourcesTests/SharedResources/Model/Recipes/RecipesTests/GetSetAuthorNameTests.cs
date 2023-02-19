using Shared_Resources.Model.Recipes;

namespace SharedResourcesTests.SharedResources.Model.Recipes.RecipesTests
{
    public class GetSetAuthorNameTests
    {
        [Test]
        public void AssignNonNullAuthorName()
        {
            const string authorName = "author name";

            var recipe = new Recipe {
                AuthorName = authorName
            };

            Assert.That(recipe.AuthorName, Is.EqualTo(authorName));
        }

        [Test]
        public void AssignNullAuthorName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _ = new Recipe {
                    AuthorName = null!
                };
            });
        }
    }
}