CREATE TABLE [dbo].[PlannedMeals]
(
	[mealId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [mealDate] DATETIME NOT NULL, 
    [mealCategory] INT NOT NULL, 
    [recipeId] INT NOT NULL, 
    [userId] INT NOT NULL,
    CONSTRAINT [FK_PlannedMeals_Recipe] FOREIGN KEY ([recipeId]) REFERENCES [dbo].[Recipes] ([recipeId]),
    CONSTRAINT [FK_PlannedMeals_Users] FOREIGN KEY ([userId]) REFERENCES [dbo].[Users] ([userId]),
    CONSTRAINT [CK_PlannedMeals_MealCategory] CHECK ([mealCategory] IN (0, 1, 2))
)
