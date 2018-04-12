/*
Post-Deployment Script Template
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.
 Use SQLCMD syntax to include a file in the post-deployment script.
 Example:      :r .\myfile.sql
 Use SQLCMD syntax to reference a variable in the post-deployment script.
 Example:      :setvar TableName MyTable
               SELECT * FROM [$(TableName)]
--------------------------------------------------------------------------------------
*/

BEGIN TRY

    IF NOT EXISTS (SELECT 1 FROM dbo.Cinema WHERE Id = 1)

    BEGIN TRANSACTION

    PRINT 'Inserting seed data for Cinema table'

    INSERT INTO dbo.Cinema ([Name], [City])
    VALUES
        ('Silver Screen', 'Minsk'),
        ('Red star', 'Grodno'),
        ('Belarus', 'Minsk'),
        ('October', 'Grodno')

    PRINT 'Inserting seed data for Hall table'

    INSERT INTO dbo.Hall ([CinemaId], [Name])
        VALUES
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='Silver Screen'), 'A'), /*(1)*/
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='Red star'), 'A'), /*(2)*/
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='Belarus'), 'A'), /*(3)*/
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='October'), 'A') /*(4)*/
        /*
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='Silver Screen'), 'B'),
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='Silver Screen'), 'C'),
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='Red star'), 'B'),
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='Belarus'), 'B'),
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='Belarus'), 'C'),
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='October'), 'B')
        */

    PRINT 'Inserting seed data for HallScheme table'

    INSERT INTO dbo.HallScheme (RowNumber, PlacesCount, HallId)
    VALUES
        (1,2,1),
        (2,4,1),
        (3,3,1),
        (1,2,2),
        (2,4,2),
        (3,3,2),
        (1,2,3),
        (2,4,3),
        (3,3,3),
        (1,2,4),
        (2,4,4),
        (3,3,4)
        /*
        (1,2,5),
        (2,4,5),
        (3,3,5),
        (1,2,6),
        (2,4,6),
        (3,3,6),
        (1,2,7),
        (2,4,7),
        (3,3,7),
        (1,2,8),
        (2,4,8),
        (3,3,8),
        (1,2,9),
        (2,4,9),
        (3,3,9),
        (1,2,10),
        (2,4,10),
        (3,3,10)
        */

    PRINT 'Inserting seed data for Film table'

    INSERT INTO dbo.Film(StartRentdate, EndRentdate, [Name], [Description])
    VALUES
        (convert(datetime, '20180601'), convert(datetime, '20190606'), 'Delirium', 'description'), /*(1)*/
        (convert(datetime, '20180601'), convert(datetime, '20190606'), 'Star Wars', 'description'), /*(2)*/
        (convert(datetime, '20180601'), convert(datetime, '20190606'), 'Tor', 'description'), /*(3)*/
        (convert(datetime, '20180601'), convert(datetime, '20190606'), 'Selfie', 'description'), /*(4)*/
        (convert(datetime, '20180601'), convert(datetime, '20190606'), 'Ferdinant', 'description'), /*(5)*/
        (convert(datetime, '20180601'), convert(datetime, '20190606'), 'Happy End', 'description'), /*(6)*/
        (convert(datetime, '20180601'), convert(datetime, '20190606'), 'Three Billboards Outside Ebbing', 'description'), /*(7)*/
        (convert(datetime, '20180601'), convert(datetime, '20190606'), 'Marry me', 'description'), /*(8)*/
        (convert(datetime, '20180601'), convert(datetime, '20190606'), 'Madagaskar', 'description'), /*(9)*/
        (convert(datetime, '20180601'), convert(datetime, '20190606'), 'Number one', 'description') /*(10)*/

    PRINT 'Inserting seed data for Session table'

    INSERT INTO dbo.Session (FilmId, HallId, [Date])
    VALUES
        (1, 1, convert(datetimeoffset, '20171008 12:15:00')),
        (2, 1, convert(datetimeoffset, '20171007 12:15:00')),
        (3, 1, convert(datetimeoffset, '20171006 12:15:00')),
        (4, 2, convert(datetimeoffset, '20171008 18:15:00')),
        (5, 2, CONVERT(datetimeoffset, '20171007 18:15:00')),
        (6, 2, CONVERT(datetimeoffset, '20171006 18:15:00')),
        (7, 3, convert(datetimeoffset, '20171008 14:15:00')),
        (8, 3, convert(datetimeoffset, '20171007 14:15:00')),
        (9, 3, convert(datetimeoffset, '20171006 14:15:00')),
        (10, 4, CONVERT(datetimeoffset, '20171008 11:15:00')),
        (1, 4, convert(datetimeoffset, '20171007 11:15:00')),
        (2, 4, convert(datetimeoffset, '20171006 11:15:00'))
        /*
        (3, 5, convert(datetimeoffset, '20171008 17:15:00')),
        (4, 5, convert(datetimeoffset, '20171007 17:15:00')),
        (5, 5, convert(datetimeoffset, '20171006 17:15:00')),
        (6, 6, convert(datetimeoffset, '20171008 19:15:00')),
        (7, 6, convert(datetimeoffset, '20171007 19:15:00')),
        (8, 6, convert(datetimeoffset, '20171006 19:15:00')),
        (9, 7, convert(datetimeoffset, '20171008 20:15:00')),
        (10, 7, convert(datetimeoffset, '20171007 21:15:00')),
        (1, 7, convert(datetimeoffset, '20171006 22:15:00')),
        (2, 8, convert(datetimeoffset, '20171008 19:15:00')),
        (3, 8, convert(datetimeoffset, '20171007 19:15:00')),
        (4, 8, convert(datetimeoffset, '20171006 19:15:00')),
        (5, 9, convert(datetimeoffset, '20171008 19:15:00')),
        (6, 9, convert(datetimeoffset, '20171007 19:15:00')),
        (7, 9, convert(datetimeoffset, '20171006 19:15:00')),
        (8, 10, convert(datetimeoffset, '20171008 12:15:00')),
        (9, 10, convert(datetimeoffset, '20171007 12:15:00')),
        (10, 10, convert(datetimeoffset, '20171006 12:15:00'))
        */

    PRINT 'Inserting seed data for PlaceType table'

    INSERT INTO dbo.PlaceType([Name])
    VALUES
        ('Standart'),
        ('Double'),
        ('VIP')

    PRINT 'Inserting seed data for Place table'

    INSERT INTO dbo.Place(HallId, PlaceTypeId, RowNumber, PlaceNumber)
    VALUES
        (1, 1, 1, 1),
        (1, 1, 1, 2),
        (1, 1, 2, 1),
        (1, 1, 2, 2),
        (1, 1, 2, 3),
        (1, 1, 2, 4),
        (1, 1, 3, 1),
        (1, 1, 3, 2),
        (1, 1, 3, 3),

        (2, 1, 1, 1),
        (2, 1, 1, 2),
        (2, 1, 2, 1),
        (2, 1, 2, 2),
        (2, 1, 2, 3),
        (2, 1, 2, 4),
        (2, 1, 3, 1),
        (2, 1, 3, 2),
        (2, 1, 3, 3),

        (3, 1, 1, 1),
        (3, 1, 1, 2),
        (3, 1, 2, 1),
        (3, 1, 2, 2),
        (3, 1, 2, 3),
        (3, 1, 2, 4),
        (3, 1, 3, 1),
        (3, 1, 3, 2),
        (3, 1, 3, 3),

        (4, 1, 1, 1),
        (4, 1, 1, 2),
        (4, 1, 2, 1),
        (4, 1, 2, 2),
        (4, 1, 2, 3),
        (4, 1, 2, 4),
        (4, 1, 3, 1),
        (4, 1, 3, 2),
        (4, 1, 3, 3)
        /*
        (5, 1, 1, 1),
        (5, 1, 1, 2),
        (5, 1, 2, 1),
        (5, 1, 2, 2),
        (5, 1, 2, 3),
        (5, 1, 2, 4),
        (5, 1, 3, 1),
        (5, 1, 3, 2),
        (5, 1, 3, 3),

        (6, 1, 1, 1),
        (6, 1, 1, 2),
        (6, 1, 2, 1),
        (6, 1, 2, 2),
        (6, 1, 2, 3),
        (6, 1, 2, 4),
        (6, 1, 3, 1),
        (6, 1, 3, 2),
        (6, 1, 3, 3),

        (7, 1, 1, 1),
        (7, 1, 1, 2),
        (7, 1, 2, 1),
        (7, 1, 2, 2),
        (7, 1, 2, 3),
        (7, 1, 2, 4),
        (7, 1, 3, 1),
        (7, 1, 3, 2),
        (7, 1, 3, 3),

        (8, 1, 1, 1),
        (8, 1, 1, 2),
        (8, 1, 2, 1),
        (8, 1, 2, 2),
        (8, 1, 2, 3),
        (8, 1, 2, 4),
        (8, 1, 3, 1),
        (8, 1, 3, 2),
        (8, 1, 3, 3),

        (9, 1, 1, 1),
        (9, 1, 1, 2),
        (9, 1, 2, 1),
        (9, 1, 2, 2),
        (9, 1, 2, 3),
        (9, 1, 2, 4),
        (9, 1, 3, 1),
        (9, 1, 3, 2),
        (9, 1, 3, 3),

        (10, 1, 1, 1),
        (10, 1, 1, 2),
        (10, 1, 2, 1),
        (10, 1, 2, 2),
        (10, 1, 2, 3),
        (10, 1, 2, 4),
        (10, 1, 3, 1),
        (10, 1, 3, 2),
        (10, 1, 3, 3)
        */

    PRINT 'Inserting seed data for Price table'

    /*DECLARE @number INT
    DECLARE @placeId INT
    SET @number = 1;
    SET @placeId = 1;
    WHILE @NUMBER <= 30
        BEGIN
            WHILE @placeId < 90
            BEGIN
                INSERT INTO dbo.Price(SessionId, PlaceId, Price, SessionDate)
                VALUES
                    (@number, @placeId, 8, (SELECT Session.Date FROM Session WHERE Session.Id = @number))
                SET @placeId = @placeId + 1
            END;
            SET @number = @number + 1
            SET @placeId = 1
        END;*/

    INSERT INTO dbo.Price(SessionId, PlaceId, Price)
    VALUES
        /*21 price for 3 sessions in one hall with 9 places*/

        /*for the first hall with id=1*/

        (1, 1, 8),
        (1, 2, 8),
        (1, 3, 8),
        (1, 4, 8),
        (1, 5, 8),
        (1, 6, 8),
        (1, 7, 8),
        (1, 8, 8),
        (1, 9, 8),

        (2, 1, 8),
        (2, 2, 8),
        (2, 3, 8),
        (2, 4, 8),
        (2, 5, 8),
        (2, 6, 8),
        (2, 7, 8),
        (2, 8, 8),
        (2, 9, 8),

        (3, 1, 8),
        (3, 2, 8),
        (3, 3, 8),
        (3, 4, 8),
        (3, 5, 8),
        (3, 6, 8),
        (3, 7, 8),
        (3, 8, 8),
        (3, 9, 8),

        /*for the second hall with id=2*/

        (4, 10, 9),
        (4, 11, 9),
        (4, 12, 9),
        (4, 13, 9),
        (4, 14, 9),
        (4, 15, 9),
        (4, 16, 9),
        (4, 17, 9),
        (4, 18, 9),

        (5, 10, 9),
        (5, 11, 9),
        (5, 12, 9),
        (5, 13, 9),
        (5, 14, 9),
        (5, 15, 9),
        (5, 16, 9),
        (5, 17, 9),
        (5, 18, 9),

        (6, 10, 9),
        (6, 11, 9),
        (6, 12, 9),
        (6, 13, 9),
        (6, 14, 9),
        (6, 15, 9),
        (6, 16, 9),
        (6, 17, 9),
        (6, 18, 9),

        /*for the third hall with id=3*/

        (7, 19, 10),
        (7, 20, 10),
        (7, 21, 10),
        (7, 22, 10),
        (7, 23, 10),
        (7, 24, 10),
        (7, 25, 10),
        (7, 26, 10),
        (7, 27, 10),

        (8, 19, 10),
        (8, 20, 10),
        (8, 21, 10),
        (8, 22, 10),
        (8, 23, 10),
        (8, 24, 10),
        (8, 25, 10),
        (8, 26, 10),
        (8, 27, 10),

        (9, 19, 10),
        (9, 20, 10),
        (9, 21, 10),
        (9, 22, 10),
        (9, 23, 10),
        (9, 24, 10),
        (9, 25, 10),
        (9, 26, 10),
        (9, 27, 10),

        /*for the fourth hall with id=4*/

        (10, 28, 11),
        (10, 29, 11),
        (10, 30, 11),
        (10, 31, 11),
        (10, 32, 11),
        (10, 33, 11),
        (10, 34, 11),
        (10, 35, 11),
        (10, 36, 11),

        (11, 28, 11),
        (11, 29, 11),
        (11, 30, 11),
        (11, 31, 11),
        (11, 32, 11),
        (11, 33, 11),
        (11, 34, 11),
        (11, 35, 11),
        (11, 36, 11),

        (12, 28, 11),
        (12, 29, 11),
        (12, 30, 11),
        (12, 31, 11),
        (12, 32, 11),
        (12, 33, 11),
        (12, 34, 11),
        (12, 35, 11),
        (12, 36, 11)

    PRINT 'Inserting seed data for UserRole table'

    INSERT INTO dbo.UserRole([Name])
    VALUES
        ('User'),
        ('Admin')

    PRINT 'Inserting seed data for User table'

    INSERT INTO dbo.[User](PasswordHash, Salt, FirstName, LastName, Email, UserRoleId)
    VALUES
        (0x5B75CFC9814F736F0F5333C06EF4FC0E1E295B650CE42A3C5CDC4EE28820C70504D33A352E19AC7C2AD7E7450E6C36816275CBC3AC6B092D1A01E13C55041B22, 0x32DE15C9947A0293ABF91273985EA1631C437CD422138FE4B916C58CFC1690CFBD6B40811F544D0670020DBE6E9F2D6DBC0D, 'Alexandr', 'Dimidov', 'a.Dimidov@gmail.com', 1),
        (0xB7CBCA824304188F77EAADD65507B22B5EB3346B9DA8BC062852BB83F3D736E4EEDE7C74FCE59C5A7461B47EAE9B77A1DCDF32C72FA371B3C1A0E37DCE6AA335, 0xCD1243CDA5FF8555A77F62AA42C7CE40910110E5268462B46C928967B6888DBE03389EA89245D2282017D88B2F3CFF860C10, 'Maria', 'Kuharchuk', 'm.kuharchuk@gmail.com', 1),
        (0x3188FC2F019CCC0AA692BE1F518550AA39289C00A8D5FA065F0067109BD8309B7B01DA229F4DD08E05A2C04FAA734B0E2C99F4C966A11BE01EC353961D68ED38, 0xF2AB25571633B18F23A97762C95D3636EFBF390ED3CB9B5246FCCC27B8976BA64805C44C19861501962DCD792885D7D3C6BF, 'Alexandra', 'Kreidich', 'a.kreidich@gmail.com', 1),
        (0x16F1ED0DB49FB34725288A6E3AE8A9FCAF2EA6E681FB5B64AFF263F9E0DD481765FEBF3542FB08B9D189C9AE304EA6FAEA2F5D50B285365C7EBBE15D04E0C670, 0x01A3FF1C8127196B04573BA2AF7B35D032356F5249CBE37D57A05C08136C3A6A37C8BA228A8B3186E4349C80D8606A31AC97, 'Ivan', 'Ivanov', 'i.ivanov@gmail.com', 1),
        (0x2C6286DF7CDE4B15E8314C677610C3C14B2A165670EB64F6353C46CC8671651DF27B212ED73497CC3028EC0CC9C46D2C000E004210067782D5562FDF8C01CF2F, 0xDF659A4735710A37C4165811B8B17B6193D8724AB1AF15C0D77175EDA59458EAE4D073BEDFC566DC656A814D5777C50F869A, 'Vladislav', 'Klochkov', 'v.klochkov@gmail.com', 1)

    PRINT 'Inserting seed data for Service table'

    INSERT INTO dbo.[Service]([Name], Price)
    VALUES
        ('Popcorn', 5),
        ('Sweets', 3),
        ('Drink', 3)

    PRINT 'Inserting seed data for Status table'

    INSERT INTO dbo.[TicketStatus]([Name])
    VALUES
        ('Paid'),
        ('InProcess')

    PRINT 'Inserting seed data for Ticket table'

    INSERT INTO dbo.Ticket(PriceId, UserId, TicketStatusId, CreatedAt)
    VALUES
        (1, 1, 1, convert(datetimeoffset, '20180409 12:15:00.0000000 +03:00')),
        (2, 1, 2, CONVERT(datetimeoffset, '20180409 12:15:00.0000000 +03:00')),
        (3, 2, 1, CONVERT(datetimeoffset, '20180409 12:15:00.0000000 +03:00')),
        (4, 2, 1, CONVERT(datetimeoffset, '20180409 12:15:00.0000000 +03:00')),
        (5, 3, 2, CONVERT(datetimeoffset, '20180409 19:10:00.0000000 +03:00')),
        (6, 3, 1, CONVERT(datetimeoffset, '20180409 12:15:00.0000000 +03:00')),
        (7, 4, 1, CONVERT(datetimeoffset, '20180409 12:15:00.0000000 +03:00')),
        (8, 4, 2, CONVERT(datetimeoffset, '20180410 12:15:00.0000000 +03:00')),
        (9, 5, 1, CONVERT(datetimeoffset, '20180410 12:15:00.0000000 +03:00')),

        (10, 5, 2, CONVERT(datetimeoffset, '20180409 19:15:00.0000000 +03:00'))

    PRINT 'Inserting seed data for TicketService table'

    INSERT INTO dbo.TicketService(TicketId, ServiceId)
    VALUES
        (1, 1),
        (1, 2),
        (2, 2),
        (3, 3),
        (4, 1),
        (5, 2),
        (6, 3)

    PRINT 'Inserting seed data for SessionService table'

    INSERT INTO dbo.SessionService(ServiceId, SessionId)
    VALUES
        (1, 1),
        (1, 2),
        (2, 2),
        (2, 3),
        (3, 1),
        (3, 2),
        (3, 3)

    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    PRINT ERROR_MESSAGE();
END catch