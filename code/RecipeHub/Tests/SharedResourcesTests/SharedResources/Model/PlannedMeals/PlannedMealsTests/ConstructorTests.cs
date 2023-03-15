using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared_Resources.Model.PlannedMeals;
using Shared_Resources.Model.Recipes;

namespace SharedResourcesTests.SharedResources.Model.PlannedMeals.PlannedMealsTests
{
    public class ConstructorTests
    {
        [Test]
        public void ValidConstructor()
        {
            DateTime date = DateTime.Now;

            const MealCategory category = MealCategory.Breakfast;
            var recipes = new Recipe[2];
            recipes[0] = new Recipe(1, "name1", "title1", "description1", false);
            recipes[1] = new Recipe(2, "name2", "title2", "description2", false);
            var mealsForCategory = new MealsForCategory(category, recipes);

            const MealCategory category2 = MealCategory.Lunch;
            var recipes2 = new Recipe[2];
            recipes2[0] = new Recipe(3, "name3", "title3", "description3", false);
            recipes2[1] = new Recipe(4, "name4", "title4", "description4", false);
            var mealsForCategory2 = new MealsForCategory(category, recipes);
            MealsForCategory[] mealsForCategoryArray = { mealsForCategory, mealsForCategory2 };

            Assert.Multiple(() =>
            {
                var plannedMeals = new Shared_Resources.Model.PlannedMeals.PlannedMeal(date, mealsForCategoryArray);
                Assert.That(plannedMeals.MealDate, Is.EqualTo(date));
                Assert.That(plannedMeals.Meals.Length, Is.EqualTo(mealsForCategoryArray.Length));
                Assert.That(plannedMeals.Meals[0].Category, Is.EqualTo(mealsForCategoryArray[0].Category));
                Assert.That(plannedMeals.Meals[0].Recipes.Length, Is.EqualTo(mealsForCategoryArray[0].Recipes.Length));
                Assert.That(plannedMeals.Meals[0].Recipes[0].Id, Is.EqualTo(mealsForCategoryArray[0].Recipes[0].Id));
                Assert.That(plannedMeals.Meals[0].Recipes[1].Id, Is.EqualTo(mealsForCategoryArray[0].Recipes[1].Id));
                Assert.That(plannedMeals.Meals[0].Recipes[0].Name, Is.EqualTo(mealsForCategoryArray[0].Recipes[0].Name));
                Assert.That(plannedMeals.Meals[0].Recipes[1].Name, Is.EqualTo(mealsForCategoryArray[0].Recipes[1].Name));
                Assert.That(plannedMeals.Meals[0].Recipes[0].AuthorName, Is.EqualTo(mealsForCategoryArray[0].Recipes[0].AuthorName));
                Assert.That(plannedMeals.Meals[0].Recipes[1].AuthorName, Is.EqualTo(mealsForCategoryArray[0].Recipes[1].AuthorName));
                Assert.That(plannedMeals.Meals[0].Recipes[0].Description, Is.EqualTo(mealsForCategoryArray[0].Recipes[0].Description));
                Assert.That(plannedMeals.Meals[0].Recipes[1].Description, Is.EqualTo(mealsForCategoryArray[0].Recipes[1].Description));
                Assert.That(plannedMeals.Meals[0].Recipes[0].IsPublic, Is.EqualTo(mealsForCategoryArray[0].Recipes[0].IsPublic));
                Assert.That(plannedMeals.Meals[0].Recipes[1].IsPublic, Is.EqualTo(mealsForCategoryArray[0].Recipes[1].IsPublic));

                Assert.That(plannedMeals.Meals[1].Category, Is.EqualTo(mealsForCategoryArray[1].Category));
                Assert.That(plannedMeals.Meals[1].Recipes.Length, Is.EqualTo(mealsForCategoryArray[1].Recipes.Length));
                Assert.That(plannedMeals.Meals[1].Recipes[0].Id, Is.EqualTo(mealsForCategoryArray[1].Recipes[0].Id));
                Assert.That(plannedMeals.Meals[1].Recipes[1].Id, Is.EqualTo(mealsForCategoryArray[1].Recipes[1].Id));
                Assert.That(plannedMeals.Meals[1].Recipes[0].Name, Is.EqualTo(mealsForCategoryArray[1].Recipes[0].Name));
                Assert.That(plannedMeals.Meals[1].Recipes[1].Name, Is.EqualTo(mealsForCategoryArray[1].Recipes[1].Name));
                Assert.That(plannedMeals.Meals[1].Recipes[0].AuthorName, Is.EqualTo(mealsForCategoryArray[1].Recipes[0].AuthorName));
                Assert.That(plannedMeals.Meals[1].Recipes[1].AuthorName, Is.EqualTo(mealsForCategoryArray[1].Recipes[1].AuthorName));
                Assert.That(plannedMeals.Meals[1].Recipes[0].Description, Is.EqualTo(mealsForCategoryArray[1].Recipes[0].Description));
                Assert.That(plannedMeals.Meals[1].Recipes[1].Description, Is.EqualTo(mealsForCategoryArray[1].Recipes[1].Description));
                Assert.That(plannedMeals.Meals[1].Recipes[0].IsPublic, Is.EqualTo(mealsForCategoryArray[1].Recipes[0].IsPublic));
                Assert.That(plannedMeals.Meals[1].Recipes[1].IsPublic, Is.EqualTo(mealsForCategoryArray[1].Recipes[1].IsPublic));
            });
        }

        [Test]
        public void RecipesIsNull()
        {
            DateTime date = DateTime.Now;
            MealsForCategory[] mealsForCategoryArray = null;

            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    var plannedMeals = new Shared_Resources.Model.PlannedMeals.PlannedMeal(date, mealsForCategoryArray!);
                });
            });
        }
    }
}
