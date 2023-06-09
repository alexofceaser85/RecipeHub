﻿using System.Net;
using Moq;
using Server.Controllers.PlannedMeals;
using Server.Controllers.ResponseModels;
using Server.Data.Settings;
using Server.Service.PlannedMeals;
using Shared_Resources.Model.PlannedMeals;
using Shared_Resources.Model.Recipes;

namespace ServerTests.Server.Controllers.PlannedMeals.PlannedMealsTests
{
    public class GetPlannedMealsTests
    {
        [Test]
        public void ShouldGetPlannedMeals()
        {
            var recipeOne = new PlannedRecipe{Recipe = new Recipe(0, "author one", "recipe one", "desc one", true)};
            var recipeTwo = new PlannedRecipe{Recipe = new Recipe(1, "author two", "recipe two", "desc two", true)};
            var recipeThree = new PlannedRecipe { Recipe = new Recipe(2, "author three", "recipe three", "desc three", true) };
            var recipeFour = new PlannedRecipe { Recipe = new Recipe(3, "author four", "recipe four", "desc four", true) };
            var recipeFive = new PlannedRecipe { Recipe = new Recipe(4, "author five", "recipe five", "desc five", true) };
            var recipeSix = new PlannedRecipe { Recipe = new Recipe(5, "author six", "recipe six", "desc six", true) };
            var recipeSeven = new PlannedRecipe { Recipe = new Recipe(6, "author seven", "recipe seven", "desc seven", true) };
            var recipeEight = new PlannedRecipe { Recipe = new Recipe(6, "author eight", "recipe eight", "desc eight", true) };

            var firstMealForCategory = new MealsForCategory(MealCategory.Breakfast, new [] { recipeOne, recipeTwo });
            var secondMealForCategory = new MealsForCategory(MealCategory.Lunch, new [] { recipeTwo });
            var thirdMealForCategory = new MealsForCategory(MealCategory.Dinner, Array.Empty<PlannedRecipe>());

            var fourthMealForCategory = new MealsForCategory(MealCategory.Breakfast, new [] { recipeThree });
            var fifthMealForCategory = new MealsForCategory(MealCategory.Lunch, new [] { recipeFour });
            var sixthMealForCategory = new MealsForCategory(MealCategory.Dinner, new [] { recipeFive });

            var seventhMealForCategory = new MealsForCategory(MealCategory.Breakfast, new [] { recipeSix });
            var eightMealForCategory = new MealsForCategory(MealCategory.Lunch, new [] { recipeSeven });
            var ninthMealForCategory = new MealsForCategory(MealCategory.Dinner, new [] { recipeEight });

            var firstPlannedMeal = new PlannedMeal(new DateTime(2023, 03, 01), new [] 
                {firstMealForCategory, secondMealForCategory, thirdMealForCategory} 
            );
            var secondPlannedMeal = new PlannedMeal(new DateTime(2023, 03, 02), new []
                {fourthMealForCategory, fifthMealForCategory, sixthMealForCategory}
            );
            var thirdPlannedMeal = new PlannedMeal(new DateTime(2023, 03, 03), new []
                {seventhMealForCategory, eightMealForCategory, ninthMealForCategory}
            );

            var sessionKey = "key";
            var date = new DateTime(2023, 03, 03);
            var meals = new [] { firstPlannedMeal, secondPlannedMeal, thirdPlannedMeal };

            var expected = new PlannedMealsResponseModel(HttpStatusCode.OK, ServerSettings.DefaultSuccessfulConnectionMessage, meals);

            var service = new Mock<IPlannedMealsService>();
            var controller = new PlannedMealsController(service.Object);

            service.Setup(mock => mock.GetPlannedMeals(sessionKey, It.IsAny<DateTime>())).Returns(meals);

            var response = controller.GetPlannedMeals(sessionKey, date);

            Assert.That(response.Code, Is.EqualTo(expected.Code));
            Assert.That(response.Message, Is.EqualTo(expected.Message));
            Assert.That(response.PlannedMeals, Is.EqualTo(meals));
            service.Verify(mock => mock.GetPlannedMeals(sessionKey, It.IsAny<DateTime>()), Times.Once);
        }

        [Test]
        public void ShouldNotRemovePlannedMealIfNoSession()
        {
            var sessionKey = "key";
            var date = new DateTime(2023, 03, 03);

            var expected = new PlannedMealsResponseModel(HttpStatusCode.Unauthorized, "message", null!);

            var service = new Mock<IPlannedMealsService>();
            var controller = new PlannedMealsController(service.Object);

            service.Setup(mock => mock.GetPlannedMeals(sessionKey, It.IsAny<DateTime>())).Throws(() => new UnauthorizedAccessException("message"));

            var response = controller.GetPlannedMeals(sessionKey, date);

            Assert.That(response.Code, Is.EqualTo(expected.Code));
            Assert.That(response.Message, Is.EqualTo(expected.Message));
            Assert.That(response.PlannedMeals, Is.EqualTo(null!));
            service.Verify(mock => mock.GetPlannedMeals(sessionKey, It.IsAny<DateTime>()), Times.Once);
        }

        [Test]
        public void ShouldNotRemovePlannedMealIfServerError()
        {
            var sessionKey = "key";
            var date = new DateTime(2023, 03, 03);

            var expected = new PlannedMealsResponseModel(HttpStatusCode.InternalServerError, "message", null!);

            var service = new Mock<IPlannedMealsService>();
            var controller = new PlannedMealsController(service.Object);

            service.Setup(mock => mock.GetPlannedMeals(sessionKey, It.IsAny<DateTime>())).Throws(() => new ArgumentException("message"));

            var response = controller.GetPlannedMeals(sessionKey, date);

            Assert.That(response.Code, Is.EqualTo(expected.Code));
            Assert.That(response.Message, Is.EqualTo(expected.Message));
            Assert.That(response.PlannedMeals, Is.EqualTo(null!));
            service.Verify(mock => mock.GetPlannedMeals(sessionKey, It.IsAny<DateTime>()), Times.Once);
        }
    }
}
