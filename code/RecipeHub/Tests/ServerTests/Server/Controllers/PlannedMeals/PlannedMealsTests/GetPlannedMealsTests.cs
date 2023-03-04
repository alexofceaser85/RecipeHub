using System.Net;
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
            var recipeOne = new Recipe(0, "author one", "recipe one", "desc one", true);
            var recipeTwo = new Recipe(1, "author two", "recipe two", "desc two", true);
            var recipeThree = new Recipe(2, "author three", "recipe three", "desc three", true);
            var recipeFour = new Recipe(3, "author four", "recipe four", "desc four", true);
            var recipeFive = new Recipe(4, "author five", "recipe five", "desc five", true);
            var recipeSix = new Recipe(5, "author six", "recipe six", "desc six", true);
            var recipeSeven = new Recipe(6, "author seven", "recipe seven", "desc seven", true);
            var recipeEight = new Recipe(6, "author eight", "recipe eight", "desc eight", true);

            var firstMealForCategory = new MealsForCategory(MealCategory.Breakfast, new Recipe[] { recipeOne, recipeTwo });
            var secondMealForCategory = new MealsForCategory(MealCategory.Lunch, new Recipe[] { recipeTwo });
            var thirdMealForCategory = new MealsForCategory(MealCategory.Dinner, new Recipe[] { });

            var fourthMealForCategory = new MealsForCategory(MealCategory.Breakfast, new Recipe[] { recipeThree });
            var fifthMealForCategory = new MealsForCategory(MealCategory.Lunch, new Recipe[] { recipeFour });
            var sixthMealForCategory = new MealsForCategory(MealCategory.Dinner, new Recipe[] { recipeFive });

            var seventhMealForCategory = new MealsForCategory(MealCategory.Breakfast, new Recipe[] { recipeSix });
            var eightMealForCategory = new MealsForCategory(MealCategory.Lunch, new Recipe[] { recipeSeven });
            var ninthMealForCategory = new MealsForCategory(MealCategory.Dinner, new Recipe[] { recipeEight });

            var firstPlannedMeal = new PlannedMeal(new DateTime(2023, 03, 01), new MealsForCategory[] 
                {firstMealForCategory, secondMealForCategory, thirdMealForCategory} 
            );
            var secondPlannedMeal = new PlannedMeal(new DateTime(2023, 03, 02), new MealsForCategory[]
                {fourthMealForCategory, fifthMealForCategory, sixthMealForCategory}
            );
            var thirdPlannedMeal = new PlannedMeal(new DateTime(2023, 03, 03), new MealsForCategory[]
                {seventhMealForCategory, eightMealForCategory, ninthMealForCategory}
            );

            var sessionKey = "key";
            var date = new DateTime(2023, 03, 03);
            var category = MealCategory.Breakfast;
            var recipeId = 1;
            var meals = new PlannedMeal[] { firstPlannedMeal, secondPlannedMeal, thirdPlannedMeal };

            var expected = new PlannedMealsResponseModel(HttpStatusCode.OK, ServerSettings.DefaultSuccessfulConnectionMessage, meals);

            var service = new Mock<IPlannedMealsService>();
            var controller = new PlannedMealsController(service.Object);

            service.Setup(mock => mock.GetPlannedMeals(sessionKey, It.IsAny<DateTime>())).Returns(meals);

            var response = controller.GetPlannedMeals(sessionKey);

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
            var category = MealCategory.Breakfast;
            var recipeId = 1;

            var expected = new PlannedMealsResponseModel(HttpStatusCode.Unauthorized, "message", null!);

            var service = new Mock<IPlannedMealsService>();
            var controller = new PlannedMealsController(service.Object);

            service.Setup(mock => mock.GetPlannedMeals(sessionKey, It.IsAny<DateTime>())).Throws(() => new UnauthorizedAccessException("message"));

            var response = controller.GetPlannedMeals(sessionKey);

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
            var category = MealCategory.Breakfast;
            var recipeId = 1;

            var expected = new PlannedMealsResponseModel(HttpStatusCode.InternalServerError, "message", null!);

            var service = new Mock<IPlannedMealsService>();
            var controller = new PlannedMealsController(service.Object);

            service.Setup(mock => mock.GetPlannedMeals(sessionKey, It.IsAny<DateTime>())).Throws(() => new ArgumentException("message"));

            var response = controller.GetPlannedMeals(sessionKey);

            Assert.That(response.Code, Is.EqualTo(expected.Code));
            Assert.That(response.Message, Is.EqualTo(expected.Message));
            Assert.That(response.PlannedMeals, Is.EqualTo(null!));
            service.Verify(mock => mock.GetPlannedMeals(sessionKey, It.IsAny<DateTime>()), Times.Once);
        }
    }
}
