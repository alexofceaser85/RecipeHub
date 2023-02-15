using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared_Resources.Model.Recipes;

namespace SharedResourcesTests.SharedResources.Model.Recipes.RecipesTests
{
    public class GetSetDescriptionTests
    {
        [Test]
        public void AssignNonNullName()
        {
            const string description = "description";

            var recipe = new Recipe();
            recipe.Description = description;

            Assert.That(recipe.Description, Is.EqualTo(description));
        }

        [Test]
        public void AssignNullName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Recipe recipe = new Recipe();
                recipe.Description = null!;
            });
        }
    }
}
