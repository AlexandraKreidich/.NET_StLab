CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Login] TEXT NOT NULL,
	[Password] TEXT NOT NULL,
	[FirstName] TEXT NOT NULL,
	[LastName] TEXT NOT NULL,
	[Email] TEXT NOT NULL,
	[UserRoleId] INT NOT NULL,
	FOREIGN KEY (UserRoleId) REFERENCES [dbo].[UserRole](Id)
)