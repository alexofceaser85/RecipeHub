using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared_Resources.Model.Recipes;

namespace SharedResourcesTests.SharedResources.Model.Recipes.RecipesTests
{
    public class GetSetAuthorNameTests
    {
        [Test]
        public void AssignNonNullAuthorName()
        {
            const string authorName = "author name";

            var recipe = new Recipe();
            recipe.AuthorName = authorName;

            Assert.That(recipe.AuthorName, Is.EqualTo(authorName));
        }

        [Test]
        public void AssignNullAuthorName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Recipe recipe = new Recipe();
                recipe.AuthorName = null!;
            });
        }
    }
}
