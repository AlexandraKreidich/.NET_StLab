CREATE TABLE [dbo].[User]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [Login] NVARCHAR(50) NOT NULL,
    [PasswordHash] NVARCHAR(300) NOT NULL,
    [Salt] NVARCHAR(300) NOT NULL,
    [FirstName] NVARCHAR(50) NOT NULL,
    [LastName] NVARCHAR(50) NOT NULL,
    [Email] NVARCHAR(50) NOT NULL,
    [UserRoleId] INT NOT NULL,
    FOREIGN KEY (UserRoleId) REFERENCES [dbo].[UserRole](Id)
)