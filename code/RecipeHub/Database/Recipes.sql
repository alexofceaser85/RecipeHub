CREATE TABLE [dbo].[Recipes]
(
    [recipeId] INT NOT NULL PRIMARY KEY IDENTITY (1, 1), 
    [authorId] INT NOT NULL, 
    [name] NCHAR(100) NOT NULL, 
    [description] NCHAR(500) NOT NULL, 
    [isPublic] TINYINT NOT NULL,
    CONSTRAINT [FK_Recipe_To_Users] FOREIGN KEY (authorId) REFERENCES [Users]([userId])
)
