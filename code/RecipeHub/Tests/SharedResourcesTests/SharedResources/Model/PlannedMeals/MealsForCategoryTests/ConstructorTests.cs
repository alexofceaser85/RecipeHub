

using Shared_Resources.Model.Ingredients;
using Shared_Resources.Model.PlannedMeals;
using Shared_Resources.Model.Recipes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SharedResourcesTests.SharedResources.Model.PlannedMeals.MealsForCategoryTests
{
    public class ConstructorTests
    {
        [Test]
        public void ValidConstructor()
        {
            const MealCategory category = MealCategory.Breakfast;
            var recipes = new Recipe[2];
            recipes[0] = new Recipe(1, "name1", "title1", "description1", false);
            recipes[1] = new Recipe(2, "name2", "title2", "description2", false);

            Assert.Multiple(() =>
            {
                var mealsForCategory = new MealsForCategory(category, recipes);
                Assert.That(mealsForCategory.Category, Is.EqualTo(category));
                Assert.That(mealsForCategory.Recipes.Length, Is.EqualTo(recipes.Length));
                Assert.That(mealsForCategory.Recipes[0].Id, Is.EqualTo(recipes[0].Id));
                Assert.That(mealsForCategory.Recipes[1].Id, Is.EqualTo(recipes[1].Id));
                Assert.That(mealsForCategory.Recipes[0].Name, Is.EqualTo(recipes[0].Name));
                Assert.That(mealsForCategory.Recipes[1].Name, Is.EqualTo(recipes[1].Name));
                Assert.That(mealsForCategory.Recipes[0].AuthorName, Is.EqualTo(recipes[0].AuthorName));
                Assert.That(mealsForCategory.Recipes[1].AuthorName, Is.EqualTo(recipes[1].AuthorName));
                Assert.That(mealsForCategory.Recipes[0].Description, Is.EqualTo(recipes[0].Description));
                Assert.That(mealsForCategory.Recipes[1].Description, Is.EqualTo(recipes[1].Description));
                Assert.That(mealsForCategory.Recipes[0].IsPublic, Is.EqualTo(recipes[0].IsPublic));
                Assert.That(mealsForCategory.Recipes[1].IsPublic, Is.EqualTo(recipes[1].IsPublic));
            });
        }

        [Test]
        public void RecipeIsNull()
        {
            const MealCategory category = MealCategory.Breakfast;
            Recipe[] recipes = null!;
            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    var mealsForCategory = new MealsForCategory(category, recipes);
                });
            });
        }
    }
}
