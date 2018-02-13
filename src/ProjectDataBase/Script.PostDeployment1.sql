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

    INSERT INTO dbo.Cinema ([Name], City, HallsNumber)
    VALUES
        ('Silver Screen', 'Minsk', 3),
        ('Red star', 'Grodno', 2),
        ('Belarus', 'Minsk', 3),
        ('October', 'Grodno', 2)

    PRINT 'Inserting seed data for Hall table'

    INSERT INTO dbo.Hall (CinemaId, [Name])
        VALUES
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='Silver Screen'), 'A'),
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='Silver Screen'), 'B'),
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='Silver Screen'), 'C'),
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='Red star'), 'A'),
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='Red star'), 'B'),
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='Belarus'), 'A'),
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='Belarus'), 'B'),
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='Belarus'), 'C'),
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='October'), 'A'),
        ((SELECT Id FROM dbo.Cinema WHERE Cinema.name='October'), 'B')

    PRINT 'Inserting seed data for HallScheme table'

    INSERT INTO dbo.HallScheme (RowNumber, PlacesCount, HallId)
    VALUES
        (1, 20, 1),
        (2, 20, 1),
        (3, 20, 1),
        (4, 20, 1),
        (5, 20, 1),
        (6, 20, 1),
        (7, 20, 1),
        (8, 20, 1),
        (9, 20, 1),
        (10, 16, 1),
        (1, 17, 2),
        (2, 18, 2),
        (3, 19, 2),
        (4, 20, 2),
        (5, 20, 2),
        (6, 20, 2),
        (7, 20, 2),
        (8, 20, 2),
        (9, 20, 2),
        (10, 10, 2),
        (1, 11, 3),
        (2, 12, 3),
        (3, 13, 3),
        (4, 14, 3),
        (5, 15, 3),
        (6, 16, 3),
        (7, 17, 3),
        (8, 18, 3),
        (9, 19, 3),
        (10, 20, 3),
        (1, 17, 4),
        (2, 18, 4),
        (3, 19, 4),
        (4, 20, 4),
        (1, 20, 5),
        (2, 20, 5),
        (3, 20, 5),
        (4, 20, 5),
        (5, 20, 5),
        (6, 10, 5),
        (1, 20, 6),
        (2, 20, 6),
        (3, 20, 6),
        (4, 20, 6),
        (5, 20, 6),
        (6, 20, 6),
        (7, 20, 6),
        (8, 20, 6),
        (9, 20, 6),
        (10, 20, 6),
        (1, 20, 7),
        (2, 20, 7),
        (3, 20, 7),
        (4, 20, 7),
        (5, 20, 7),
        (6, 20, 7),
        (7, 20, 7),
        (8, 20, 7),
        (9, 20, 7),
        (10, 20, 7),
        (1, 10, 8),
        (2, 14, 8),
        (3, 18, 8),
        (4, 20, 8),
        (5, 22, 8),
        (6, 24, 8),
        (1, 20, 9),
        (2, 20, 9),
        (3, 20, 9),
        (4, 20, 9),
        (1, 20, 10),
        (2, 20, 10),
        (3, 20, 10),
        (4, 20, 10),
        (5, 20, 10),
        (6, 20, 10),
        (7, 20, 10),
        (8, 20, 10),
        (9, 20, 10)

    PRINT 'Inserting seed data for Film table'

    INSERT INTO dbo.Film(StartShowDate, EndShowDate, [Name], [Description])
    VALUES
        (convert(DATE, '20170601'), convert(DATE, '20170606'), 'Delirium', 'description'),
        (convert(DATE, '20170601'), convert(DATE, '20170606'), 'Star Wars', 'description'),
        (convert(DATE, '20170601'), convert(DATE, '20170606'), 'Tor', 'description'),
        (convert(DATE, '20170601'), convert(DATE, '20170606'), 'Selfie', 'description'),
        (convert(DATE, '20170601'), convert(DATE, '20170606'), 'Ferdinant', 'description'),
        (convert(DATE, '20170601'), convert(DATE, '20170606'), 'Happy End', 'description'),
        (convert(DATE, '20170601'), convert(DATE, '20170606'), 'Three Billboards Outside Ebbing', 'description'),
        (convert(DATE, '20170601'), convert(DATE, '20170606'), 'Marry me', 'description'),
        (convert(DATE, '20170601'), convert(DATE, '20170606'), 'Madagaskar', 'description'),
        (convert(DATE, '20170601'), convert(DATE, '20170606'), 'Number one', 'description')

    PRINT 'Inserting seed data for Session table'

    INSERT INTO dbo.Session (FilmId, HallId, [Date], [Time])
    VALUES
        (1, 1, convert(DATE, '20171008'), cast('12:15:00' as time)),
        (2, 1, convert(DATE, '20171007'), cast('12:15:00' as time)),
        (3, 1, convert(DATE, '20171006'), cast('12:15:00' as time)),
        (4, 2, convert(DATE, '20171008'), CAST('18:15:00' AS TIME)),
        (5, 2, CONVERT(DATE, '20171007'), CAST('18:15:00' AS TIME)),
        (6, 2, CONVERT(DATE, '20171006'), cast('18:15:00' as time)),
        (7, 3, convert(DATE, '20171008'), cast('14:15:00' as time)),
        (8, 3, convert(DATE, '20171007'), cast('14:15:00' as time)),
        (9, 3, convert(DATE, '20171006'), cast('14:15:00' as time)),
        (10, 4, CONVERT(DATE, '20171008'), cast('11:15:00' as time)),
        (1, 4, convert(DATE, '20171007'), cast('11:15:00' as time)),
        (2, 4, convert(DATE, '20171006'), cast('11:15:00' as time)),
        (3, 5, convert(DATE, '20171008'), cast('17:15:00' as time)),
        (4, 5, convert(DATE, '20171007'), cast('17:15:00' as time)),
        (5, 5, convert(DATE, '20171006'), cast('17:15:00' as time)),
        (6, 6, convert(DATE, '20171008'), cast('19:15:00' as time)),
        (7, 6, convert(DATE, '20171007'), cast('19:15:00' as time)),
        (8, 6, convert(DATE, '20171006'), cast('19:15:00' as time)),
        (9, 7, convert(DATE, '20171008'), cast('20:15:00' as time)),
        (10, 7, convert(DATE, '20171007'), cast('21:15:00' as time)),
        (1, 7, convert(DATE, '20171006'), cast('22:15:00' as time)),
        (2, 8, convert(DATE, '20171008'), cast('19:15:00' as time)),
        (3, 8, convert(DATE, '20171007'), cast('19:15:00' as time)),
        (4, 8, convert(DATE, '20171006'), cast('19:15:00' as time)),
        (5, 9, convert(DATE, '20171008'), cast('19:15:00' as time)),
        (6, 9, convert(DATE, '20171007'), cast('19:15:00' as time)),
        (7, 9, convert(DATE, '20171006'), cast('19:15:00' as time)),
        (8, 10, convert(DATE, '20171008'), cast('12:15:00' as time)),
        (9, 10, convert(DATE, '20171007'), cast('12:15:00' as time)),
        (10, 10, convert(DATE, '20171006'), cast('12:15:00' as time))

    PRINT 'Inserting seed data for PlaceType table'

    INSERT INTO dbo.PlaceType([Name])
    VALUES
        ('double'),
        ('standart'),
        ('VIP')

    PRINT 'Inserting seed data for Price table'

    INSERT INTO dbo.Price(PlaceTypeId, SessionId, Price)
    VALUES
        (1, 1, 8),
        (2, 1, 6),
        (3, 1, 10),
        (1, 2, 8),
        (2, 2, 6),
        (3, 2, 10)

    PRINT 'Inserting seed data for Place table'

    INSERT INTO dbo.Place(RowNumber, PlaceNumber, PriceId, HallId)
    VALUES
        (1, 1, 1, 1),
        (2, 1, 2, 1),
        (3, 1, 3, 1),
        (1, 2, 1, 1),
        (2, 2, 2, 1),
        (3, 2, 3, 1)

    PRINT 'Inserting seed data for UserRole table'

    INSERT INTO dbo.UserRole([Name])
    VALUES
        ('administrator'),
        ('user')

    PRINT 'Inserting seed data for User table'

    INSERT INTO dbo.[User]([Login], [Password], FirstName, LastName, Email, UserRoleId)
    VALUES
        ('vladK', '12345', 'Vladislav', 'Krasnitskiy', 'v.krasnitskiy@gmail.com', 2),
        ('alex', '12345', 'Alexandr', 'Dimidov', 'a.Dimidov@gmail.com', 2),
        ('maria', '12345', 'Maria', 'Kuharchuk', 'm.kuharchuk@gmail.com', 2),
        ('sasha', '12345', 'Alexandra', 'Kreidich', 'a.kreidich@gmail.com', 2),
        ('admin', '123456789', 'Ivan', 'Ivanov', 'i.ivanov@gmail.com', 1)

    PRINT 'Inserting seed data for Service table'

    INSERT INTO dbo.[Service]([Name], Price)
    VALUES
        ('popcorn', 5),
        ('sweets', 3),
        ('drink', 3)

    PRINT 'Inserting seed data for Status table'

    INSERT INTO dbo.[TicketStatus]([StatusName])
    VALUES
        ('ok'),
        ('error'),
        ('inProcess')

    PRINT 'Inserting seed data for Ticket table'

    INSERT INTO dbo.Ticket(PlaceId, UserId, StatusId)
    VALUES
        (1, 1, 1),
        (2, 2, 1),
        (3, 3, 1),
        (4, 4, 1),
        (5, 1, 1),
        (6, 2, 1)

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