using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared_Resources.Model.Recipes;

namespace SharedResourcesTests.SharedResources.Model.Recipes.RecipesTests
{
    public class GetSetIsPublicTests
    {
        [Test]
        public void AssignIsPublic()
        {
            var recipe = new Recipe();
            recipe.IsPublic = true;

            Assert.That(recipe.IsPublic, Is.EqualTo(true));
        }
    }
}
