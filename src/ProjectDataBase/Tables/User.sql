CREATE TABLE [dbo].[User]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [PasswordHash] NVARCHAR(256) NOT NULL,
    [Salt] NVARCHAR(50) NOT NULL,
    [FirstName] NVARCHAR(50) NOT NULL,
    [LastName] NVARCHAR(50) NOT NULL,
    [Email] NVARCHAR(256) NOT NULL,
    [UserRoleId] INT NOT NULL,
    FOREIGN KEY (UserRoleId) REFERENCES [dbo].[UserRole](Id)
)