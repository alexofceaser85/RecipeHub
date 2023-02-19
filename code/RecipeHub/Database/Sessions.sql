CREATE TABLE [dbo].[Sessions]
(
    [userId] INT NOT NULL PRIMARY KEY, 
    [sessionKey] NCHAR(128) NOT NULL,
    [lastUpdateTime] DATETIME NOT NULL, 
    CONSTRAINT [FK_Sessions_To_Users] FOREIGN KEY (userId) REFERENCES [Users]([userId])
)
