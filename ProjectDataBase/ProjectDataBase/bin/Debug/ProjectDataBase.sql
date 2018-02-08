﻿/*
Deployment script for ProjectDataBase

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ProjectDataBase"
:setvar DefaultFilePrefix "ProjectDataBase"
:setvar DefaultDataPath "C:\Users\a.kreidzich\AppData\Local\Microsoft\VisualStudio\SSDT\ProjectDataBase"
:setvar DefaultLogPath "C:\Users\a.kreidzich\AppData\Local\Microsoft\VisualStudio\SSDT\ProjectDataBase"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
The column [dbo].[cinema].[halls_number] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Cinema])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[film].[end_show_date] is being dropped, data loss could occur.

The column [dbo].[film].[start_show_date] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Film])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[hall].[cinema_id] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Hall])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[place].[hall_id] is being dropped, data loss could occur.

The column [dbo].[place].[place_number] is being dropped, data loss could occur.

The column [dbo].[place].[price_id] is being dropped, data loss could occur.

The column [dbo].[place].[row_number] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Place])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[price].[place_type_id] is being dropped, data loss could occur.

The column [dbo].[price].[session_id] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Price])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[session].[film_id] is being dropped, data loss could occur.

The column [dbo].[session].[hall_id] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Session])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[ticket].[additional_service_id] is being dropped, data loss could occur.

The column [dbo].[ticket].[place_id] is being dropped, data loss could occur.

The column [dbo].[ticket].[status] is being dropped, data loss could occur.

The column [dbo].[ticket].[user_id] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Ticket])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[user].[first_name] is being dropped, data loss could occur.

The column [dbo].[user].[last_name] is being dropped, data loss could occur.

The column [dbo].[user].[user_role_id] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[User])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Rename refactoring operation with key bae2ee98-c3d2-49b0-bf81-278f2caeb04b is skipped, element [dbo].[Status].[Id] (SqlSimpleColumn) will not be renamed to id';


GO
PRINT N'Rename refactoring operation with key f27e8317-9b5f-49d1-b751-f6d86a49b440 is skipped, element [dbo].[AdditionalService] (SqlTable) will not be renamed to [Service]';


GO
PRINT N'Dropping unnamed constraint on [dbo].[hall]...';


GO
ALTER TABLE [dbo].[hall] DROP CONSTRAINT [FK__hall__cinema_id__38996AB5];


GO
PRINT N'Dropping unnamed constraint on [dbo].[hall_scheme]...';


GO
ALTER TABLE [dbo].[hall_scheme] DROP CONSTRAINT [FK__hall_sche__hall___398D8EEE];


GO
PRINT N'Dropping unnamed constraint on [dbo].[place]...';


GO
ALTER TABLE [dbo].[place] DROP CONSTRAINT [FK__place__hall_id__3B75D760];


GO
PRINT N'Dropping unnamed constraint on [dbo].[session]...';


GO
ALTER TABLE [dbo].[session] DROP CONSTRAINT [FK__session__hall_id__3F466844];


GO
PRINT N'Dropping unnamed constraint on [dbo].[place]...';


GO
ALTER TABLE [dbo].[place] DROP CONSTRAINT [FK__place__price_id__3A81B327];


GO
PRINT N'Dropping unnamed constraint on [dbo].[ticket]...';


GO
ALTER TABLE [dbo].[ticket] DROP CONSTRAINT [FK__ticket__place_id__4222D4EF];


GO
PRINT N'Dropping unnamed constraint on [dbo].[price]...';


GO
ALTER TABLE [dbo].[price] DROP CONSTRAINT [FK__price__session_i__3C69FB99];


GO
PRINT N'Dropping unnamed constraint on [dbo].[price]...';


GO
ALTER TABLE [dbo].[price] DROP CONSTRAINT [FK__price__place_typ__3D5E1FD2];


GO
PRINT N'Dropping unnamed constraint on [dbo].[session]...';


GO
ALTER TABLE [dbo].[session] DROP CONSTRAINT [FK__session__film_id__3E52440B];


GO
PRINT N'Dropping unnamed constraint on [dbo].[ticket]...';


GO
ALTER TABLE [dbo].[ticket] DROP CONSTRAINT [FK__ticket__addition__403A8C7D];


GO
PRINT N'Dropping unnamed constraint on [dbo].[ticket]...';


GO
ALTER TABLE [dbo].[ticket] DROP CONSTRAINT [FK__ticket__user_id__412EB0B6];


GO
PRINT N'Dropping unnamed constraint on [dbo].[user]...';


GO
ALTER TABLE [dbo].[user] DROP CONSTRAINT [FK__user__user_role___4316F928];


GO
PRINT N'Starting rebuilding table [dbo].[Cinema]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Cinema] (
    [id]          INT  IDENTITY (1, 1) NOT NULL,
    [name]        TEXT NULL,
    [city]        TEXT NULL,
    [hallsNumber] INT  NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[cinema])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Cinema] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Cinema] ([id], [name], [city])
        SELECT   [id],
                 [name],
                 [city]
        FROM     [dbo].[cinema]
        ORDER BY [id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Cinema] OFF;
    END

DROP TABLE [dbo].[cinema];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Cinema]', N'Cinema';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Film]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Film] (
    [id]            INT  IDENTITY (1, 1) NOT NULL,
    [startShowDate] DATE NULL,
    [endShowDate]   DATE NULL,
    [name]          TEXT NULL,
    [description]   TEXT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[film])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Film] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Film] ([id], [description])
        SELECT   [id],
                 [description]
        FROM     [dbo].[film]
        ORDER BY [id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Film] OFF;
    END

DROP TABLE [dbo].[film];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Film]', N'Film';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Hall]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Hall] (
    [id]       INT IDENTITY (1, 1) NOT NULL,
    [cinemaId] INT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[hall])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Hall] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Hall] ([id])
        SELECT   [id]
        FROM     [dbo].[hall]
        ORDER BY [id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Hall] OFF;
    END

DROP TABLE [dbo].[hall];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Hall]', N'Hall';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Place]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Place] (
    [id]          INT IDENTITY (1, 1) NOT NULL,
    [rowNumber]   INT NULL,
    [placeNumber] INT NULL,
    [priceId]     INT NULL,
    [hallId]      INT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[place])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Place] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Place] ([id])
        SELECT   [id]
        FROM     [dbo].[place]
        ORDER BY [id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Place] OFF;
    END

DROP TABLE [dbo].[place];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Place]', N'Place';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Price]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Price] (
    [id]          INT IDENTITY (1, 1) NOT NULL,
    [placeTypeId] INT NULL,
    [sessionId]   INT NULL,
    [price]       INT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[price])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Price] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Price] ([id])
        SELECT   [id]
        FROM     [dbo].[price]
        ORDER BY [id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Price] OFF;
    END

DROP TABLE [dbo].[price];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Price]', N'Price';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Session]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Session] (
    [id]     INT      IDENTITY (1, 1) NOT NULL,
    [filmId] INT      NULL,
    [hallId] INT      NULL,
    [date]   DATE     NULL,
    [time]   TIME (7) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[session])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Session] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Session] ([id], [date], [time])
        SELECT   [id],
                 [date],
                 [time]
        FROM     [dbo].[session]
        ORDER BY [id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Session] OFF;
    END

DROP TABLE [dbo].[session];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Session]', N'Session';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Ticket]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Ticket] (
    [id]       INT IDENTITY (1, 1) NOT NULL,
    [placeId]  INT NULL,
    [userId]   INT NULL,
    [statusId] INT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[ticket])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Ticket] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Ticket] ([id])
        SELECT   [id]
        FROM     [dbo].[ticket]
        ORDER BY [id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Ticket] OFF;
    END

DROP TABLE [dbo].[ticket];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Ticket]', N'Ticket';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[User]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_User] (
    [id]         INT  IDENTITY (1, 1) NOT NULL,
    [login]      TEXT NULL,
    [password]   TEXT NULL,
    [firstName]  TEXT NULL,
    [lastName]   TEXT NULL,
    [email]      TEXT NULL,
    [userRoleId] INT  NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[user])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_User] ON;
        INSERT INTO [dbo].[tmp_ms_xx_User] ([id], [login], [password], [email])
        SELECT   [id],
                 [login],
                 [password],
                 [email]
        FROM     [dbo].[user]
        ORDER BY [id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_User] OFF;
    END

DROP TABLE [dbo].[user];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_User]', N'User';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[HallScheme]...';


GO
CREATE TABLE [dbo].[HallScheme] (
    [id]          INT IDENTITY (1, 1) NOT NULL,
    [rowNumber]   INT NULL,
    [placesCount] INT NULL,
    [hallId]      INT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creating [dbo].[PlaceType]...';


GO
CREATE TABLE [dbo].[PlaceType] (
    [id]   INT  IDENTITY (1, 1) NOT NULL,
    [name] TEXT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creating [dbo].[Service]...';


GO
CREATE TABLE [dbo].[Service] (
    [id]    INT  IDENTITY (1, 1) NOT NULL,
    [name]  TEXT NULL,
    [price] INT  NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creating [dbo].[Status]...';


GO
CREATE TABLE [dbo].[Status] (
    [id]         INT  IDENTITY (1, 1) NOT NULL,
    [statusName] TEXT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creating [dbo].[TicketService]...';


GO
CREATE TABLE [dbo].[TicketService] (
    [ticketId]  INT NULL,
    [serviceId] INT NULL
);


GO
PRINT N'Creating [dbo].[UserRole]...';


GO
CREATE TABLE [dbo].[UserRole] (
    [id]   INT  IDENTITY (1, 1) NOT NULL,
    [name] TEXT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creating unnamed constraint on [dbo].[Hall]...';


GO
ALTER TABLE [dbo].[Hall] WITH NOCHECK
    ADD FOREIGN KEY ([cinemaId]) REFERENCES [dbo].[Cinema] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Place]...';


GO
ALTER TABLE [dbo].[Place] WITH NOCHECK
    ADD FOREIGN KEY ([priceId]) REFERENCES [dbo].[Price] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Place]...';


GO
ALTER TABLE [dbo].[Place] WITH NOCHECK
    ADD FOREIGN KEY ([hallId]) REFERENCES [dbo].[Hall] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Price]...';


GO
ALTER TABLE [dbo].[Price] WITH NOCHECK
    ADD FOREIGN KEY ([sessionId]) REFERENCES [dbo].[Session] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Price]...';


GO
ALTER TABLE [dbo].[Price] WITH NOCHECK
    ADD FOREIGN KEY ([placeTypeId]) REFERENCES [dbo].[PlaceType] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Session]...';


GO
ALTER TABLE [dbo].[Session] WITH NOCHECK
    ADD FOREIGN KEY ([filmId]) REFERENCES [dbo].[User] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Session]...';


GO
ALTER TABLE [dbo].[Session] WITH NOCHECK
    ADD FOREIGN KEY ([hallId]) REFERENCES [dbo].[Hall] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Ticket]...';


GO
ALTER TABLE [dbo].[Ticket] WITH NOCHECK
    ADD FOREIGN KEY ([userId]) REFERENCES [dbo].[User] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Ticket]...';


GO
ALTER TABLE [dbo].[Ticket] WITH NOCHECK
    ADD FOREIGN KEY ([placeId]) REFERENCES [dbo].[Place] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Ticket]...';


GO
ALTER TABLE [dbo].[Ticket] WITH NOCHECK
    ADD FOREIGN KEY ([statusId]) REFERENCES [dbo].[Status] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[User]...';


GO
ALTER TABLE [dbo].[User] WITH NOCHECK
    ADD FOREIGN KEY ([userRoleId]) REFERENCES [dbo].[UserRole] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[HallScheme]...';


GO
ALTER TABLE [dbo].[HallScheme] WITH NOCHECK
    ADD FOREIGN KEY ([hallId]) REFERENCES [dbo].[Hall] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[TicketService]...';


GO
ALTER TABLE [dbo].[TicketService] WITH NOCHECK
    ADD FOREIGN KEY ([serviceId]) REFERENCES [dbo].[Service] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[TicketService]...';


GO
ALTER TABLE [dbo].[TicketService] WITH NOCHECK
    ADD FOREIGN KEY ([ticketId]) REFERENCES [dbo].[Ticket] ([id]);


GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'bae2ee98-c3d2-49b0-bf81-278f2caeb04b')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('bae2ee98-c3d2-49b0-bf81-278f2caeb04b')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'f27e8317-9b5f-49d1-b751-f6d86a49b440')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('f27e8317-9b5f-49d1-b751-f6d86a49b440')

GO

GO
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
	IF NOT EXISTS (SELECT 1 FROM dbo.Cinema WHERE id = 1)
	BEGIN TRANSACTION 

	SET IDENTITY_INSERT dbo ON

	PRINT 'Inserting seed data for cinema table'

	INSERT INTO dbo.Cinema (name, city, hallsNumber)
	VALUES 
		('Silver Screen', 'Minsk', 3),
		('Red star', 'Grodno', 2),
		('Belarus', 'Minsk', 3),
		('October', 'Grodno', 2)

	PRINT 'Inserting seed data for hall table'
	
	INSERT INTO dbo.Hall (cinemaId)
	VALUES 
		(1),
		(1),
		(1),
		(2),
		(2),
		(3),
		(3),
		(3),
		(4),
		(4)

	PRINT 'Inserting seed data for HallScheme table'
	/*for "Silver screen" cinema (hall_id's are: 1,2,3)
	  for "Red star" cinema (hall_id's are: 4,5)
	  for "Belarus" cinema (hall_id's are: 6,7,8)
	  for "October" cinema (hall_id's are: 9,10)*/

	INSERT INTO dbo.HallScheme (rowNumber, placesCount, hallId)
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

	INSERT INTO dbo.Film(startShowDate, endShowDate, [name], [description])
	VALUES 
		('2017.06.01', '2017.11.06', 'Delirium', 'description'),
		('2017.06.01', '2017.11.06', 'Star Wars', 'description'),
		('2017.06.01', '2017.11.06', 'Tor', 'description'),
		('2017.06.01', '2017.11.06', 'Selfie', 'description'),
		('2017.06.01', '2017.11.06', 'Ferdinant', 'description'),
		('2017.06.01', '2017.11.06', 'Happy End', 'description'),
		('2017.06.01', '2017.11.06', 'Three Billboards Outside Ebbing', 'description'),
		('2017.06.01', '2017.11.06', 'Marry me', 'description'),
		('2017.06.01', '2017.11.06', 'Madagaskar', 'description'),
		('2017.06.01', '2017.11.06', 'Number one', 'description')

	PRINT 'Inserting seed data for Session table'

	INSERT INTO dbo.Session (filmId, hallId, [date], [time])
	VALUES 
		(1, 1, '2017.10.08', '12.15.00'), /*price here*/
		(2, 1, '2017.10.07', '12.15.00'), /*Price here*/
		(3, 1, '2017.10.06', '12.15.00'),
		(4, 2, '2017.10.08', '18.15.00'),
		(5, 2, '2017.10.07', '18.15.00'),
		(6, 2, '2017.10.06', '18.15.00'),
		(7, 3, '2017.10.08', '14.15.00'),
		(8, 3, '2017.10.07', '14.15.00'),
		(9, 3, '2017.10.06', '14.15.00'),
		(10, 4, '2017.10.08', '11.15.00'),
		(1, 4, '2017.10.07', '11.15.00'),
		(2, 4, '2017.10.06', '11.15.00'),
		(3, 5, '2017.10.08', '17.15.00'),
		(4, 5, '2017.10.07', '17.15.00'),
		(5, 5, '2017.10.06', '17.15.00'),
		(6, 6, '2017.10.08', '19.15.00'),
		(7, 6, '2017.10.07', '19.15.00'),
		(8, 6, '2017.10.06', '19.15.00'),
		(9, 7, '2017.10.08', '20.15.00'),
		(10, 7, '2017.10.07', '21.15.00'),
		(1, 7, '2017.10.06', '22.15.00'),
		(2, 8, '2017.10.08', '19.15.00'),
		(3, 8, '2017.10.07', '19.15.00'),
		(4, 8, '2017.10.06', '19.15.00'),
		(5, 9, '2017.10.08', '19.15.00'),
		(6, 9, '2017.10.07', '19.15.00'),
		(7, 9, '2017.10.06', '19.15.00'),
		(8, 10, '2017.10.08', '12.15.00'),
		(9, 10, '2017.10.07', '12.15.00'),
		(10, 10, '2017.10.06', '12.15.00')

	PRINT 'Inserting seed data for PlaceType table'

	INSERT INTO dbo.PlaceType([name])
	VALUES 
		('double'),
		('standart'),
		('VIP')

	PRINT 'Inserting seed data for Price table'

	INSERT INTO dbo.Price(placeTypeId, sessionId, price)
	VALUES 
		(1, 1, 8),
		(2, 1, 6),
		(3, 1, 10),
		(1, 2, 8),
		(2, 2, 6),
		(3, 2, 10)

	PRINT 'Inserting seed data for Place table'

	INSERT INTO dbo.Place(rowNumber, placeNumber, priceId, hallId)
	VALUES 
		(1, 1, 1, 1),
		(2, 1, 2, 1),
		(3, 1, 3, 1),
		(1, 2, 1, 1),
		(2, 2, 2, 1),
		(3, 2, 3, 1)

	PRINT 'Inserting seed data for UserRole table'

	INSERT INTO dbo.UserRole([name])
	VALUES 
		('administrator'),
		('user')

	PRINT 'Inserting seed data for User table'

	INSERT INTO dbo.[User]([login], [password], firstName, lastName, email, userRoleId)
	VALUES 
		('vladK', '12345', 'Vladislav', 'Krasnitskiy', 'v.krasnitskiy@gmail.com', 2),
		('alex', '12345', 'Alexandr', 'Dimidov', 'a.Dimidov@gmail.com', 2),
		('maria', '12345', 'Maria', 'Kuharchuk', 'm.kuharchuk@gmail.com', 2),
		('sasha', '12345', 'Alexandra', 'Kreidich', 'a.kreidich@gmail.com', 2),
		('admin', '123456789', 'Ivan', 'Ivanov', 'i.ivanov@gmail.com', 1)

	PRINT 'Inserting seed data for Service table'

	INSERT INTO dbo.[Service]([name], price)
	VALUES 
		('popcorn', 5),
		('sweets', 3),
		('drink', 3)

	PRINT 'Inserting seed data for Status table'

	INSERT INTO dbo.[Status]([statusName])
	VALUES 
		('ok'),
		('error'),
		('inProcess')

	PRINT 'Inserting seed data for Ticket table'

	INSERT INTO dbo.Ticket(placeId, userId, statusId) 
	VALUES 
		(1, 1, 1),
		(2, 2, 1),
		(3, 3, 1),
		(4, 4, 1),
		(5, 1, 1),
		(6, 2, 1)

	PRINT 'Inserting seed data for TicketService table'

	INSERT INTO dbo.TicketService(ticketId, serviceId) 
	VALUES 
		(1, 1),
		(1, 2),
		(2, 2),
		(3, 3),
		(4, 1),
		(5, 2),
		(6, 3)

	SET IDENTITY_INSERT dbo OFF

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	SELECT   
        ERROR_NUMBER() AS ErrorNumber  
       ,ERROR_MESSAGE() AS ErrorMessage;
END catch




GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
CREATE TABLE [#__checkStatus] (
    id           INT            IDENTITY (1, 1) PRIMARY KEY CLUSTERED,
    [Schema]     NVARCHAR (256),
    [Table]      NVARCHAR (256),
    [Constraint] NVARCHAR (256)
);

SET NOCOUNT ON;

DECLARE tableconstraintnames CURSOR LOCAL FORWARD_ONLY
    FOR SELECT SCHEMA_NAME([schema_id]),
               OBJECT_NAME([parent_object_id]),
               [name],
               0
        FROM   [sys].[objects]
        WHERE  [parent_object_id] IN (OBJECT_ID(N'dbo.Hall'), OBJECT_ID(N'dbo.Place'), OBJECT_ID(N'dbo.Price'), OBJECT_ID(N'dbo.Session'), OBJECT_ID(N'dbo.Ticket'), OBJECT_ID(N'dbo.User'), OBJECT_ID(N'dbo.HallScheme'), OBJECT_ID(N'dbo.TicketService'))
               AND [type] IN (N'F', N'C')
                   AND [object_id] IN (SELECT [object_id]
                                       FROM   [sys].[check_constraints]
                                       WHERE  [is_not_trusted] <> 0
                                              AND [is_disabled] = 0
                                       UNION
                                       SELECT [object_id]
                                       FROM   [sys].[foreign_keys]
                                       WHERE  [is_not_trusted] <> 0
                                              AND [is_disabled] = 0);

DECLARE @schemaname AS NVARCHAR (256);

DECLARE @tablename AS NVARCHAR (256);

DECLARE @checkname AS NVARCHAR (256);

DECLARE @is_not_trusted AS INT;

DECLARE @statement AS NVARCHAR (1024);

BEGIN TRY
    OPEN tableconstraintnames;
    FETCH tableconstraintnames INTO @schemaname, @tablename, @checkname, @is_not_trusted;
    WHILE @@fetch_status = 0
        BEGIN
            PRINT N'Checking constraint: ' + @checkname + N' [' + @schemaname + N'].[' + @tablename + N']';
            SET @statement = N'ALTER TABLE [' + @schemaname + N'].[' + @tablename + N'] WITH ' + CASE @is_not_trusted WHEN 0 THEN N'CHECK' ELSE N'NOCHECK' END + N' CHECK CONSTRAINT [' + @checkname + N']';
            BEGIN TRY
                EXECUTE [sp_executesql] @statement;
            END TRY
            BEGIN CATCH
                INSERT  [#__checkStatus] ([Schema], [Table], [Constraint])
                VALUES                  (@schemaname, @tablename, @checkname);
            END CATCH
            FETCH tableconstraintnames INTO @schemaname, @tablename, @checkname, @is_not_trusted;
        END
END TRY
BEGIN CATCH
    PRINT ERROR_MESSAGE();
END CATCH

IF CURSOR_STATUS(N'LOCAL', N'tableconstraintnames') >= 0
    CLOSE tableconstraintnames;

IF CURSOR_STATUS(N'LOCAL', N'tableconstraintnames') = -1
    DEALLOCATE tableconstraintnames;

SELECT N'Constraint verification failed:' + [Schema] + N'.' + [Table] + N',' + [Constraint]
FROM   [#__checkStatus];

IF @@ROWCOUNT > 0
    BEGIN
        DROP TABLE [#__checkStatus];
        RAISERROR (N'An error occurred while verifying constraints', 16, 127);
    END

SET NOCOUNT OFF;

DROP TABLE [#__checkStatus];


GO
PRINT N'Update complete.';


GO
