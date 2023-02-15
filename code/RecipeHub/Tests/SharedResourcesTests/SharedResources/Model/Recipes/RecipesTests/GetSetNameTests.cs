using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared_Resources.Model.Recipes;

namespace SharedResourcesTests.SharedResources.Model.Recipes.RecipesTests
{
    public class GetSetNameTests
    {
        [Test]
        public void AssignNonNullName()
        {
            const string name = "name";

            var recipe = new Recipe();
            recipe.Name = name;

            Assert.That(recipe.Name, Is.EqualTo(name));
        }

        [Test]
        public void AssignNullName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Recipe recipe = new Recipe();
                recipe.Name = null!;
            });
        }
    }
}
