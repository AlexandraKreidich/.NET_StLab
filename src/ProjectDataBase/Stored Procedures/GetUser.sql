﻿CREATE PROCEDURE [dbo].[GetUser]
    @Email NVARCHAR(256)
AS
    SELECT
        u.Id,
        ur.Name as Role,
        u.Email,
        u.PasswordHash,
        u.Salt,
        u.FirstName,
        u.LastName
    FROM [User] u
        inner join UserRole ur
            on u.UserRoleId = ur.Id
    WHERE Email = @Email
