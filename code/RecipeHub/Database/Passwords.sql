CREATE TABLE [dbo].[Passwords]
(
    [userId] INT NOT NULL PRIMARY KEY, 
    [password] NCHAR(128) NOT NULL,
    CONSTRAINT [FK_Passwords_To_Users] FOREIGN KEY (userId) REFERENCES [Users]([userId])
)
