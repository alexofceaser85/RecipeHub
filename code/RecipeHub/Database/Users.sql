CREATE TABLE [dbo].[Users]
(
	[userId] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [userName] NCHAR(100) NOT NULL, 
    [firstName] NCHAR(100) NOT NULL, 
    [lastName] NCHAR(100) NOT NULL, 
    [email] NCHAR(200) NOT NULL, 
    CONSTRAINT [UN_Users_UserName] UNIQUE (userName)
)
