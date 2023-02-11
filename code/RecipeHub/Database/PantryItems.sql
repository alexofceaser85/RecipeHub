CREATE TABLE [dbo].[PantryItems]
(
    [ingredientId] INT NOT NULL, 
    [userId] INT NOT NULL, 
    [amount] INT NOT NULL,
    CONSTRAINT [FK_PantryItems_To_Ingredients] FOREIGN KEY (ingredientId) REFERENCES [Ingredients]([ingredientId]),
    CONSTRAINT [FK_PantryItems_To_Users] FOREIGN KEY (userId) REFERENCES [Users]([userId]),
    PRIMARY KEY ([ingredientId], [userId])
)
