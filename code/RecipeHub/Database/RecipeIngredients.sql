CREATE TABLE [dbo].[RecipeIngredients]
(
	[ingredientId] INT NOT NULL, 
    [recipeId] INT NOT NULL, 
    [amount] INT NOT NULL,
    CONSTRAINT [FK_RecipeIngredients_To_Ingredients] FOREIGN KEY (ingredientId) REFERENCES [Ingredients]([ingredientId]),
    CONSTRAINT [FK_RecipeIngredients_To_Recipes] FOREIGN KEY (recipeId) REFERENCES [Recipes]([recipeId]),
    PRIMARY KEY ([ingredientId], [recipeId])
)
