CREATE TABLE [dbo].[Sessions]
(
    [userId] INT NOT NULL, 
    [sessionKey] NCHAR(128) NOT NULL PRIMARY KEY,
    [lastUpdateTime] DATETIME NOT NULL, 
    CONSTRAINT [FK_Sessions_To_Users] FOREIGN KEY (userId) REFERENCES [Users]([userId])
)
