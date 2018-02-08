CREATE TABLE [dbo].[User]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [login] TEXT NOT NULL, 
    [password] TEXT NOT NULL, 
    [firstName] TEXT NOT NULL, 
    [lastName] TEXT NOT NULL, 
    [email] TEXT NOT NULL, 
    [userRoleId] INT NOT NULL, 
    FOREIGN KEY (userRoleId) REFERENCES [dbo].[UserRole](id)
)
