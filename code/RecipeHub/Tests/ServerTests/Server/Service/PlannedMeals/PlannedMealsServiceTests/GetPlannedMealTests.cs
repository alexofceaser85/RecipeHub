using Moq;
using Server.DAL.PlannedMeals;
using Server.DAL.Recipes;
using Server.DAL.Users;
using Server.ErrorMessages;
using Server.Service.PlannedMeals;
using Shared_Resources.Model.PlannedMeals;
using Shared_Resources.Model.Recipes;

namespace ServerTests.Server.Service.PlannedMeals.PlannedMealsServiceTests
{
    public class GetPlannedMealTests
    {
        [Test]
        public void ShouldNotGetPlannedMealsIfNullSessionKey()
        {
            var sessionKey = "key";
            var userId = 1;
            var mealDate = new DateTime(2023, 03, 03);
            var category = MealCategory.Lunch;

            var plannedMealsDal = new Mock<IPlannedMealsDal>();
            var usersDal = new Mock<IUsersDal>();
            var recipesDal = new Mock<IRecipesDal>();
            var service = new PlannedMealsService(plannedMealsDal.Object, usersDal.Object, recipesDal.Object);

            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(1);
            plannedMealsDal.Setup(mock => mock.GetPlannedMealRecipes(userId, mealDate, category));

            var message = Assert.Throws<ArgumentException>(() =>
            {
                service.GetPlannedMeals(null!, mealDate);
            })?.Message;

            Assert.That(message, Is.EqualTo(PlannedMealsServiceErrorMessages.SessionKeyCannotBeNull));
        }

        [Test]
        public void ShouldNotGetPlannedMealsIfEmptySessionKey()
        {
            var sessionKey = "key";
            var userId = 1;
            var mealDate = new DateTime(2023, 03, 03);
            var category = MealCategory.Lunch;

            var plannedMealsDal = new Mock<IPlannedMealsDal>();
            var usersDal = new Mock<IUsersDal>();
            var recipesDal = new Mock<IRecipesDal>();
            var service = new PlannedMealsService(plannedMealsDal.Object, usersDal.Object, recipesDal.Object);

            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(1);
            plannedMealsDal.Setup(mock => mock.GetPlannedMealRecipes(userId, mealDate, category));

            var message = Assert.Throws<ArgumentException>(() =>
            {
                service.GetPlannedMeals("   ", mealDate);
            })?.Message;

            Assert.That(message, Is.EqualTo(PlannedMealsServiceErrorMessages.SessionKeyCannotBeEmpty));
        }

        [Test]
        public void ShouldNotGetPlannedMealsIfInvalidSessionKey()
        {
            var sessionKey = "key";
            var userId = 1;
            var mealDate = new DateTime(2023, 03, 03);
            var category = MealCategory.Lunch;

            var plannedMealsDal = new Mock<IPlannedMealsDal>();
            var usersDal = new Mock<IUsersDal>();
            var recipesDal = new Mock<IRecipesDal>();
            var service = new PlannedMealsService(plannedMealsDal.Object, usersDal.Object, recipesDal.Object);

            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns((int?)null!);
            plannedMealsDal.Setup(mock => mock.GetPlannedMealRecipes(userId, mealDate, category));

            var message = Assert.Throws<UnauthorizedAccessException>(() =>
            {
                service.GetPlannedMeals(sessionKey, mealDate);
            })?.Message;

            Assert.That(message, Is.EqualTo(PlannedMealsServiceErrorMessages.InvalidSession));
        }

        [Test]
        public void ShouldGetEmptyPlannedMealsList()
        {

            var expected = new []
            {
                new PlannedMeal(new DateTime(2023, 02, 26), new []
                {
                    new MealsForCategory(MealCategory.Breakfast, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Lunch, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Dinner, Array.Empty < PlannedRecipe >())
                }),
                new PlannedMeal(new DateTime(2023, 02, 27), new []
                {
                    new MealsForCategory(MealCategory.Breakfast, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Lunch, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Dinner, Array.Empty < PlannedRecipe >())
                }),
                new PlannedMeal(new DateTime(2023, 02, 28), new []
                {
                    new MealsForCategory(MealCategory.Breakfast, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Lunch, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Dinner, Array.Empty < PlannedRecipe >())
                }),
                new PlannedMeal(new DateTime(2023, 03, 01), new []
                {
                    new MealsForCategory(MealCategory.Breakfast, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Lunch, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Dinner, Array.Empty < PlannedRecipe >())
                }),
                new PlannedMeal(new DateTime(2023, 03, 02), new []
                {
                    new MealsForCategory(MealCategory.Breakfast, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Lunch, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Dinner, Array.Empty < PlannedRecipe >())
                }),
                new PlannedMeal(new DateTime(2023, 03, 03), new []
                {
                    new MealsForCategory(MealCategory.Breakfast, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Lunch, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Dinner, Array.Empty < PlannedRecipe >())
                }),
                new PlannedMeal(new DateTime(2023, 03, 04), new []
                {
                    new MealsForCategory(MealCategory.Breakfast, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Lunch, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Dinner, Array.Empty < PlannedRecipe >())
                }),
                new PlannedMeal(new DateTime(2023, 03, 05), new []
                {
                    new MealsForCategory(MealCategory.Breakfast, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Lunch, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Dinner, Array.Empty < PlannedRecipe >())
                }),
                new PlannedMeal(new DateTime(2023, 03, 06), new []
                {
                    new MealsForCategory(MealCategory.Breakfast, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Lunch, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Dinner, Array.Empty < PlannedRecipe >())
                }),
                new PlannedMeal(new DateTime(2023, 03, 07), new []
                {
                    new MealsForCategory(MealCategory.Breakfast, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Lunch, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Dinner, Array.Empty < PlannedRecipe >())
                }),
                new PlannedMeal(new DateTime(2023, 03, 08), new []
                {
                    new MealsForCategory(MealCategory.Breakfast, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Lunch, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Dinner, Array.Empty < PlannedRecipe >())
                }),
                new PlannedMeal(new DateTime(2023, 03, 09), new []
                {
                    new MealsForCategory(MealCategory.Breakfast, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Lunch, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Dinner, Array.Empty < PlannedRecipe >())
                }),
                new PlannedMeal(new DateTime(2023, 03, 10), new []
                {
                    new MealsForCategory(MealCategory.Breakfast, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Lunch, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Dinner, Array.Empty < PlannedRecipe >())
                }),
                new PlannedMeal(new DateTime(2023, 03, 11), new []
                {
                    new MealsForCategory(MealCategory.Breakfast, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Lunch, Array.Empty < PlannedRecipe >()),
                    new MealsForCategory(MealCategory.Dinner, Array.Empty < PlannedRecipe >())
                })
            };

            var sessionKey = "key";
            var userId = 1;
            var mealDate = new DateTime(2023, 03, 03);
            var category = MealCategory.Lunch;

            var plannedMealsDal = new Mock<IPlannedMealsDal>();
            var usersDal = new Mock<IUsersDal>();
            var recipesDal = new Mock<IRecipesDal>();
            var service = new PlannedMealsService(plannedMealsDal.Object, usersDal.Object, recipesDal.Object);

            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(1);
            plannedMealsDal.Setup(mock => mock.GetPlannedMealIds(userId, mealDate, category)).Returns(new int[0]);

            var actual = service.GetPlannedMeals(sessionKey, mealDate);

            Assert.That(actual.Length, Is.EqualTo(expected.Length));

            for (var mealsIndex = 0; mealsIndex < 13; mealsIndex++)
            {
                Assert.That(expected[mealsIndex].MealDate, Is.EqualTo(actual[mealsIndex].MealDate));

                for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
                {
                    Assert.That(expected[mealsIndex].Meals[categoryIndex].Category, Is.EqualTo(actual[mealsIndex].Meals[categoryIndex].Category));
                    Assert.That(expected[mealsIndex].Meals[categoryIndex].Recipes.Length, Is.EqualTo(0));
                }
            }

            usersDal.Verify(mock => mock.GetIdForSessionKey(sessionKey), Times.Once);
            plannedMealsDal.Verify(mock => mock.GetPlannedMealIds(userId, It.IsAny<DateTime>(), It.IsAny<MealCategory>()), Times.Exactly(42));
            recipesDal.Verify(mock => mock.GetRecipe(It.IsAny<int>()), Times.Never());
        }

        [Test]
        public void ShouldGetPlannedMealsListWithMeals()
        {
            var recipes = new []
            {
                new PlannedRecipe{MealId = 1, Recipe = new Recipe(1, "1 author", "1 name", "1 desc", true)},
                new PlannedRecipe { MealId = 2, Recipe = new Recipe(2, "2 author", "2 name", "2 desc", true) },
                new PlannedRecipe { MealId = 3, Recipe = new Recipe(3, "3 author", "3 name", "3 desc", true) },
                new PlannedRecipe { MealId = 4, Recipe = new Recipe(4, "4 author", "4 name", "4 desc", true) },
                new PlannedRecipe { MealId = 5, Recipe = new Recipe(5, "5 author", "5 name", "5 desc", true) },
                new PlannedRecipe { MealId = 6, Recipe = new Recipe(6, "6 author", "6 name", "6 desc", true) },
                new PlannedRecipe { MealId = 7, Recipe = new Recipe(7, "7 author", "7 name", "7 desc", true) },
                new PlannedRecipe { MealId = 8, Recipe = new Recipe(8, "8 author", "8 name", "8 desc", true) },
                new PlannedRecipe { MealId = 9, Recipe = new Recipe(9, "9 author", "9 name", "9 desc", true) },
                new PlannedRecipe { MealId = 10, Recipe = new Recipe(10, "10 author", "10 name", "10 desc", true) }
            };

            var expected = new PlannedMeal[]
            {
                new (new DateTime(2023, 02, 26), new []
                {
                    new MealsForCategory(MealCategory.Breakfast, new [] { recipes[0], recipes[1] }),
                    new MealsForCategory(MealCategory.Lunch, Array.Empty<PlannedRecipe>()),
                    new MealsForCategory(MealCategory.Dinner, new [] { recipes[2] })
                }),
                new (new DateTime(2023, 02, 27), new []
                {
                    new MealsForCategory(MealCategory.Breakfast, new [] { recipes[3] }),
                    new MealsForCategory(MealCategory.Lunch, new [] { recipes[4] }),
                    new MealsForCategory(MealCategory.Dinner, new [] { recipes[3] })
                }),
                new (new DateTime(2023, 02, 28), new []
                {
                    new MealsForCategory(MealCategory.Breakfast, new [] { recipes[5] }),
                    new MealsForCategory(MealCategory.Lunch, new [] { recipes[6] }),
                    new MealsForCategory(MealCategory.Dinner, new [] { recipes[7] })
                }),
                new (new DateTime(2023, 03, 01), new []
                {
                    new MealsForCategory(MealCategory.Breakfast, new [] { recipes[8] }),
                    new MealsForCategory(MealCategory.Lunch, new [] { recipes[9] }),
                    new MealsForCategory(MealCategory.Dinner, new [] { recipes[7] })
                }),
                new (new DateTime(2023, 03, 02), new []
                {
                    new MealsForCategory(MealCategory.Breakfast, new [] { recipes[5] }),
                    new MealsForCategory(MealCategory.Lunch, new [] { recipes[6] }),
                    new MealsForCategory(MealCategory.Dinner, new [] { recipes[0] })
                }),
                new (new DateTime(2023, 03, 03), new []
                {
                    new MealsForCategory(MealCategory.Breakfast, new [] { recipes[1] }),
                    new MealsForCategory(MealCategory.Lunch, new [] { recipes[2] } ),
                    new MealsForCategory(MealCategory.Dinner, new [] { recipes[3] })
                }),
                new (new DateTime(2023, 03, 04), new []
                {
                    new MealsForCategory(MealCategory.Breakfast, new [] { recipes[4] }),
                    new MealsForCategory(MealCategory.Lunch, new [] { recipes[5] }),
                    new MealsForCategory(MealCategory.Dinner, new [] { recipes[6] })
                }),
                new (new DateTime(2023, 03, 05), new []
                {
                    new MealsForCategory(MealCategory.Breakfast, new [] { recipes[7] }),
                    new MealsForCategory(MealCategory.Lunch, new [] { recipes[8] }),
                    new MealsForCategory(MealCategory.Dinner, new [] { recipes[9] })
                }),
                new (new DateTime(2023, 03, 06), new []
                {
                    new MealsForCategory(MealCategory.Breakfast, new [] { recipes[0] }),
                    new MealsForCategory(MealCategory.Lunch, new [] { recipes[1] }),
                    new MealsForCategory(MealCategory.Dinner, new [] { recipes[2] })
                }),
                new (new DateTime(2023, 03, 07), new []
                {
                    new MealsForCategory(MealCategory.Breakfast, new [] { recipes[3] }),
                    new MealsForCategory(MealCategory.Lunch, new [] { recipes[4] }),
                    new MealsForCategory(MealCategory.Dinner, new [] { recipes[5] })
                }),
                new (new DateTime(2023, 03, 08), new []
                {
                    new MealsForCategory(MealCategory.Breakfast, new [] { recipes[6] }),
                    new MealsForCategory(MealCategory.Lunch, new [] { recipes[7] }),
                    new MealsForCategory(MealCategory.Dinner, new [] { recipes[8] })
                }),
                new (new DateTime(2023, 03, 09), new MealsForCategory[]
                {
                    new (MealCategory.Breakfast, new [] { recipes[9] }),
                    new (MealCategory.Lunch, new [] { recipes[0] }),
                    new (MealCategory.Dinner, new [] { recipes[1] })
                }),
                new (new DateTime(2023, 03, 10), new MealsForCategory[]
                {
                    new (MealCategory.Breakfast, new [] { recipes[2] }),
                    new (MealCategory.Lunch, new [] { recipes[3] }),
                    new (MealCategory.Dinner, new [] { recipes[4] })
                }),
                new (new DateTime(2023, 03, 11), new MealsForCategory[]
                {
                    new (MealCategory.Breakfast, new [] { recipes[5] }),
                    new (MealCategory.Lunch, new [] { recipes[6] }),
                    new (MealCategory.Dinner, new [] { recipes[7] })
                })
            };

            var sessionKey = "key";
            var userId = 1;
            var mealDate = new DateTime(2023, 03, 03);

            var plannedMealsDal = new Mock<IPlannedMealsDal>();
            var usersDal = new Mock<IUsersDal>();
            var recipesDal = new Mock<IRecipesDal>();
            var service = new PlannedMealsService(plannedMealsDal.Object, usersDal.Object, recipesDal.Object);

            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(1);

            foreach (var plannedMeal in expected)
            {
                foreach (var recipe in plannedMeal.Meals)
                {
                    var recipeIds = new List<int>();
                    foreach (var plannedMealRecipe in recipe.Recipes)
                    {
                        recipeIds.Add(plannedMealRecipe.Recipe.Id);
                        recipesDal.Setup(mock => mock.GetRecipe(plannedMealRecipe.Recipe.Id)).Returns(plannedMealRecipe.Recipe);
                        plannedMealsDal.Setup(mock => mock.GetRecipeIdForMealId(plannedMealRecipe.MealId))
                                       .Returns(plannedMealRecipe.Recipe.Id);
                    }

                    plannedMealsDal.Setup(mock => mock.GetPlannedMealIds(userId, plannedMeal.MealDate, recipe.Category)).Returns(recipeIds.ToArray());
                }
            }

            var actual = service.GetPlannedMeals(sessionKey, mealDate);

            Assert.That(actual.Length, Is.EqualTo(expected.Length));

            for (var mealsIndex = 0; mealsIndex < 13; mealsIndex++)
            {
                Assert.That(expected[mealsIndex].MealDate, Is.EqualTo(actual[mealsIndex].MealDate));

                for (var categoryIndex = 0; categoryIndex < 2; categoryIndex++)
                {
                    Assert.That(expected[mealsIndex].Meals[categoryIndex].Category, Is.EqualTo(actual[mealsIndex].Meals[categoryIndex].Category));
                    Assert.That(expected[mealsIndex].Meals[categoryIndex].Recipes.Length, Is.EqualTo(actual[mealsIndex].Meals[categoryIndex].Recipes.Length));

                    for (var recipeIndex = 0; recipeIndex < expected[mealsIndex].Meals[categoryIndex].Recipes.Length; recipeIndex++)
                    {
                        var expectedRecipe = expected[mealsIndex].Meals[categoryIndex].Recipes[recipeIndex].Recipe;
                        var actualRecipe = actual[mealsIndex].Meals[categoryIndex].Recipes[recipeIndex].Recipe;

                        Assert.That(expectedRecipe.Id, Is.EqualTo(actualRecipe.Id));
                        Assert.That(expectedRecipe.AuthorName, Is.EqualTo(actualRecipe.AuthorName));
                        Assert.That(expectedRecipe.Description, Is.EqualTo(actualRecipe.Description));
                        Assert.That(expectedRecipe.IsPublic, Is.EqualTo(actualRecipe.IsPublic));
                        Assert.That(expectedRecipe.Name, Is.EqualTo(actualRecipe.Name));
                        Assert.That(expectedRecipe.Rating, Is.EqualTo(actualRecipe.Rating));
                    }
                }
            }

            usersDal.Verify(mock => mock.GetIdForSessionKey(sessionKey), Times.Once);
            plannedMealsDal.Verify(mock => mock.GetPlannedMealIds(userId, It.IsAny<DateTime>(), It.IsAny<MealCategory>()), Times.Exactly(42));
            recipesDal.Verify(mock => mock.GetRecipe(It.IsAny<int>()), Times.Exactly(42));
        }
    }
}
