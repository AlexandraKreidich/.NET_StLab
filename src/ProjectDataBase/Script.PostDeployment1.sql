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
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='Silver Screen'), 'B'), /*(2)*/
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='Silver Screen'), 'C'), /*(3)*/
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='Red star'), 'A'), /*(4)*/
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='Red star'), 'B'), /*(5)*/
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='Belarus'), 'A'), /*(6)*/
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='Belarus'), 'B'), /*(7)*/
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='Belarus'), 'C'), /*(8)*/
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='October'), 'A'), /*(9)*/
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='October'), 'B') /*(10)*/

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
        (3,3,4),
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

    PRINT 'Inserting seed data for Film table'

    INSERT INTO dbo.Film(StartRentdate, EndRentdate, [Name], [Description])
    VALUES
        (convert(datetimeoffset, '20170601'), convert(datetimeoffset, '20170606'), 'Delirium', 'description'), /*(1)*/
        (convert(datetimeoffset, '20170601'), convert(datetimeoffset, '20170606'), 'Star Wars', 'description'), /*(2)*/
        (convert(datetimeoffset, '20170601'), convert(datetimeoffset, '20170606'), 'Tor', 'description'), /*(3)*/
        (convert(datetimeoffset, '20170601'), convert(datetimeoffset, '20170606'), 'Selfie', 'description'), /*(4)*/
        (convert(datetimeoffset, '20170601'), convert(datetimeoffset, '20170606'), 'Ferdinant', 'description'), /*(5)*/
        (convert(datetimeoffset, '20170601'), convert(datetimeoffset, '20170606'), 'Happy End', 'description'), /*(6)*/
        (convert(datetimeoffset, '20170601'), convert(datetimeoffset, '20170606'), 'Three Billboards Outside Ebbing', 'description'), /*(7)*/
        (convert(datetimeoffset, '20170601'), convert(datetimeoffset, '20170606'), 'Marry me', 'description'), /*(8)*/
        (convert(datetimeoffset, '20170601'), convert(datetimeoffset, '20170606'), 'Madagaskar', 'description'), /*(9)*/
        (convert(datetimeoffset, '20170601'), convert(datetimeoffset, '20170606'), 'Number one', 'description') /*(10)*/

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
        (2, 4, convert(datetimeoffset, '20171006 11:15:00')),
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
        (4, 1, 3, 3),

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

    PRINT 'Inserting seed data for Price table'

    DECLARE @number INT
    SET @number = 1;
    WHILE @NUMBER <= 30
        BEGIN
            INSERT INTO dbo.Price(SessionId, PlaceId, Price)
        VALUES
            (@number, 1, 8),
            (@number, 2, 8),
            (@number, 3, 8),
            (@number, 4, 8),
            (@number, 5, 8),
            (@number, 6, 8),
            (@number, 7, 8),
            (@number, 8, 8),
            (@number, 9, 8),
            (@number, 10, 8),
            (@number, 11, 8),
            (@number, 12, 8),
            (@number, 13, 8),
            (@number, 14, 8),
            (@number, 15, 8),
            (@number, 16, 8),
            (@number, 17, 8),
            (@number, 18, 8),
            (@number, 19, 8),
            (@number, 20, 8),
            (@number, 21, 8),
            (@number, 22, 8),
            (@number, 23, 8),
            (@number, 24, 8),
            (@number, 25, 8),
            (@number, 26, 8),
            (@number, 27, 8),
            (@number, 28, 8),
            (@number, 29, 8),
            (@number, 30, 8),
            (@number, 31, 8),
            (@number, 32, 8),
            (@number, 33, 8),
            (@number, 34, 8),
            (@number, 35, 8),
            (@number, 36, 8),
            (@number, 37, 8),
            (@number, 38, 8),
            (@number, 39, 8),
            (@number, 40, 8),
            (@number, 41, 8),
            (@number, 42, 8),
            (@number, 43, 8),
            (@number, 44, 8),
            (@number, 45, 8),
            (@number, 46, 8),
            (@number, 47, 8),
            (@number, 48, 8),
            (@number, 49, 8),
            (@number, 50, 8),
            (@number, 51, 8),
            (@number, 52, 8),
            (@number, 53, 8),
            (@number, 54, 8),
            (@number, 55, 8),
            (@number, 56, 8),
            (@number, 57, 8),
            (@number, 58, 8),
            (@number, 59, 8),
            (@number, 60, 8),
            (@number, 61, 8),
            (@number, 62, 8),
            (@number, 63, 8),
            (@number, 64, 8),
            (@number, 65, 8),
            (@number, 66, 8),
            (@number, 67, 8),
            (@number, 68, 8),
            (@number, 69, 8),
            (@number, 70, 8),
            (@number, 71, 8),
            (@number, 72, 8),
            (@number, 73, 8),
            (@number, 74, 8),
            (@number, 75, 8),
            (@number, 76, 8),
            (@number, 77, 8),
            (@number, 78, 8),
            (@number, 79, 8),
            (@number, 80, 8),
            (@number, 81, 8),
            (@number, 82, 8),
            (@number, 83, 8),
            (@number, 84, 8),
            (@number, 85, 8),
            (@number, 86, 8),
            (@number, 87, 8),
            (@number, 88, 8),
            (@number, 89, 8),
            (@number, 90, 8)

            SET @number = @number + 1
        END;

    PRINT 'Inserting seed data for UserRole table'

    INSERT INTO dbo.UserRole([Name])
    VALUES
        ('Administrator'),
        ('User')

    PRINT 'Inserting seed data for User table'

    INSERT INTO dbo.[User](PasswordHash, Salt, FirstName, LastName, Email, UserRoleId)
    VALUES
        ('vladK', '12345', 'Vladislav', 'Krasnitskiy', 'v.krasnitskiy@gmail.com', 2),
        ('alex', '12345', 'Alexandr', 'Dimidov', 'a.Dimidov@gmail.com', 2),
        ('maria', '12345', 'Maria', 'Kuharchuk', 'm.kuharchuk@gmail.com', 2),
        ('sasha', '12345', 'Alexandra', 'Kreidich', 'a.kreidich@gmail.com', 2),
        ('admin', '123456789', 'Ivan', 'Ivanov', 'i.ivanov@gmail.com', 1)

    PRINT 'Inserting seed data for Service table'

    INSERT INTO dbo.[Service]([Name], Price)
    VALUES
        ('Popcorn', 5),
        ('Sweets', 3),
        ('Drink', 3)

    PRINT 'Inserting seed data for Status table'

    INSERT INTO dbo.[TicketStatus]([Name])
    VALUES
        ('Ok'),
        ('Error'),
        ('InProcess')

    PRINT 'Inserting seed data for Ticket table'

    INSERT INTO dbo.Ticket(PlaceId, UserId, TicketStatusId, CreatedAt)
    VALUES
        (1, 1, 1, convert(datetimeoffset, '20171006 12:15:00')),
        (2, 2, 1, CONVERT(datetimeoffset, '20171006 12:15:00')),
        (3, 3, 1, CONVERT(datetimeoffset, '20171006 12:15:00')),
        (4, 4, 1, CONVERT(datetimeoffset, '20171006 12:15:00')),
        (5, 1, 1, CONVERT(datetimeoffset, '20171006 12:15:00')),
        (6, 2, 1, CONVERT(datetimeoffset, '20171006 12:15:00'))

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

    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    PRINT ERROR_MESSAGE();
END catch