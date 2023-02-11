CREATE TABLE [dbo].[RecipeSteps]
(
	[recipeId] INT NOT NULL, 
    [stepNumber] INT NOT NULL, 
    [stepName] NCHAR(100) NOT NULL, 
    [instructions] NCHAR(300) NOT NULL,
    PRIMARY KEY (recipeId, stepNumber)
)
