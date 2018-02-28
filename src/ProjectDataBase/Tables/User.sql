﻿CREATE TABLE [dbo].[User]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [PasswordHash] VARBINARY(256) NOT NULL,
    [Salt] BINARY(50) NOT NULL,
    [FirstName] NVARCHAR(50) NOT NULL,
    [LastName] NVARCHAR(50) NOT NULL,
    [Email] NVARCHAR(256) UNIQUE NOT NULL,
    [UserRoleId] INT NOT NULL,
    FOREIGN KEY (UserRoleId) REFERENCES [dbo].[UserRole](Id)
)