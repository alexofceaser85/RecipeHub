CREATE TABLE [dbo].[Type] (
    [typeId]   INT          IDENTITY (1, 1) NOT NULL,
    [typeName] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([typeId] ASC)
);