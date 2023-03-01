CREATE TABLE [dbo].[RecipeTypes] (
    [recipeId] INT NOT NULL,
    [typeId]   INT NOT NULL,
    PRIMARY KEY CLUSTERED ([recipeId] ASC, [typeId] ASC),
    CONSTRAINT [fk_recipeTypes_Recipe] FOREIGN KEY ([recipeId]) REFERENCES [dbo].[Recipes] ([recipeId]),
    CONSTRAINT [fk_recipeTypes_Type] FOREIGN KEY ([typeId]) REFERENCES [dbo].[Type] ([typeId])
);