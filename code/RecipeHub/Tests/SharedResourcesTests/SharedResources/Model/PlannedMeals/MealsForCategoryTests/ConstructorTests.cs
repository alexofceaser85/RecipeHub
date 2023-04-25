

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
            var recipes = new PlannedRecipe[2];
            recipes[0] = new PlannedRecipe{MealId = 1, Recipe = new (1, "name1", "title1", "description1", false) };
            recipes[1] = new PlannedRecipe{MealId = 2, Recipe = new (2, "name2", "title2", "description2", false) };

            Assert.Multiple(() =>
            {
                var mealsForCategory = new MealsForCategory(category, recipes);
                Assert.That(mealsForCategory.Category, Is.EqualTo(category));
                Assert.That(mealsForCategory.Recipes.Length, Is.EqualTo(recipes.Length));
                Assert.That(mealsForCategory.Recipes[0].Recipe.Id, Is.EqualTo(recipes[0].Recipe.Id));
                Assert.That(mealsForCategory.Recipes[1].Recipe.Id, Is.EqualTo(recipes[1].Recipe.Id));
                Assert.That(mealsForCategory.Recipes[0].Recipe.Name, Is.EqualTo(recipes[0].Recipe.Name));
                Assert.That(mealsForCategory.Recipes[1].Recipe.Name, Is.EqualTo(recipes[1].Recipe.Name));
                Assert.That(mealsForCategory.Recipes[0].Recipe.AuthorName, Is.EqualTo(recipes[0].Recipe.AuthorName));
                Assert.That(mealsForCategory.Recipes[1].Recipe.AuthorName, Is.EqualTo(recipes[1].Recipe.AuthorName));
                Assert.That(mealsForCategory.Recipes[0].Recipe.Description, Is.EqualTo(recipes[0].Recipe.Description));
                Assert.That(mealsForCategory.Recipes[1].Recipe.Description, Is.EqualTo(recipes[1].Recipe.Description));
                Assert.That(mealsForCategory.Recipes[0].Recipe.IsPublic, Is.EqualTo(recipes[0].Recipe.IsPublic));
                Assert.That(mealsForCategory.Recipes[1].Recipe.IsPublic, Is.EqualTo(recipes[1].Recipe.IsPublic));
            });
        }

        [Test]
        public void RecipeIsNull()
        {
            const MealCategory category = MealCategory.Breakfast;
            PlannedRecipe[] recipes = null!;
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
