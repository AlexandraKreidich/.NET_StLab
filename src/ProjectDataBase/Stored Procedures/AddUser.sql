CREATE PROCEDURE [dbo].[AddUser]
    @Email NVARCHAR(256),
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @UserRole NVARCHAR(50),
    @PasswordHash VARBINARY(256),
    @Salt VARBINARY(50)
AS
    INSERT INTO [dbo].[User] (PasswordHash, Salt, FirstName, LastName, Email, UserRoleId)
    VALUES (
    @PasswordHash,
    @Salt,
    @FirstName,
    @LastName,
    @Email,
    (SELECT Id FROM [dbo].UserRole
    WHERE [Name] = @UserRole))
SELECT SCOPE_IDENTITY()