CREATE TABLE [dbo].[Ingredients]
(
	[ingredientId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [name] NCHAR(200) NOT NULL, 
    [measurementType] INT NOT NULL,
    CONSTRAINT [FK_Ingredients_To_MeasurementType] FOREIGN KEY (measurementType) REFERENCES [MeasurementTypes]([typeId])
)
