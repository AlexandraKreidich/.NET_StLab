﻿/*
Deployment script for ProjectDatabase

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ProjectDatabase"
:setvar DefaultFilePrefix "ProjectDatabase"
:setvar DefaultDataPath "D:\installs\SQLServer\MSSQL14.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "D:\installs\SQLServer\MSSQL14.MSSQLSERVER\MSSQL\DATA\"

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
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Creating [dbo].[Cinema]...';


GO
CREATE TABLE [dbo].[Cinema] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [name]        VARCHAR (MAX) NULL,
    [city]        VARCHAR (MAX) NULL,
    [hallsNumber] INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creating [dbo].[Film]...';


GO
CREATE TABLE [dbo].[Film] (
    [id]            INT  IDENTITY (1, 1) NOT NULL,
    [startShowDate] DATE NULL,
    [endShowDate]   DATE NULL,
    [name]          TEXT NULL,
    [description]   TEXT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Creating [dbo].[Hall]...';


GO
CREATE TABLE [dbo].[Hall] (
    [id]       INT           IDENTITY (1, 1) NOT NULL,
    [cinemaId] INT           NULL,
    [name]     VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


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
PRINT N'Creating [dbo].[Place]...';


GO
CREATE TABLE [dbo].[Place] (
    [id]          INT IDENTITY (1, 1) NOT NULL,
    [rowNumber]   INT NULL,
    [placeNumber] INT NULL,
    [priceId]     INT NULL,
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
PRINT N'Creating [dbo].[Price]...';


GO
CREATE TABLE [dbo].[Price] (
    [id]          INT IDENTITY (1, 1) NOT NULL,
    [placeTypeId] INT NULL,
    [sessionId]   INT NULL,
    [price]       INT NULL,
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
PRINT N'Creating [dbo].[Session]...';


GO
CREATE TABLE [dbo].[Session] (
    [id]     INT      IDENTITY (1, 1) NOT NULL,
    [filmId] INT      NULL,
    [hallId] INT      NULL,
    [date]   DATE     NULL,
    [time]   TIME (7) NULL,
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
PRINT N'Creating [dbo].[Ticket]...';


GO
CREATE TABLE [dbo].[Ticket] (
    [id]       INT IDENTITY (1, 1) NOT NULL,
    [placeId]  INT NULL,
    [userId]   INT NULL,
    [statusId] INT NULL,
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
PRINT N'Creating [dbo].[User]...';


GO
CREATE TABLE [dbo].[User] (
    [id]         INT  IDENTITY (1, 1) NOT NULL,
    [login]      TEXT NULL,
    [password]   TEXT NULL,
    [firstName]  TEXT NULL,
    [lastName]   TEXT NULL,
    [email]      TEXT NULL,
    [userRoleId] INT  NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
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
ALTER TABLE [dbo].[Hall]
    ADD FOREIGN KEY ([cinemaId]) REFERENCES [dbo].[Cinema] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[HallScheme]...';


GO
ALTER TABLE [dbo].[HallScheme]
    ADD FOREIGN KEY ([hallId]) REFERENCES [dbo].[Hall] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Place]...';


GO
ALTER TABLE [dbo].[Place]
    ADD FOREIGN KEY ([priceId]) REFERENCES [dbo].[Price] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Place]...';


GO
ALTER TABLE [dbo].[Place]
    ADD FOREIGN KEY ([hallId]) REFERENCES [dbo].[Hall] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Price]...';


GO
ALTER TABLE [dbo].[Price]
    ADD FOREIGN KEY ([sessionId]) REFERENCES [dbo].[Session] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Price]...';


GO
ALTER TABLE [dbo].[Price]
    ADD FOREIGN KEY ([placeTypeId]) REFERENCES [dbo].[PlaceType] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Session]...';


GO
ALTER TABLE [dbo].[Session]
    ADD FOREIGN KEY ([filmId]) REFERENCES [dbo].[Film] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Session]...';


GO
ALTER TABLE [dbo].[Session]
    ADD FOREIGN KEY ([hallId]) REFERENCES [dbo].[Hall] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Ticket]...';


GO
ALTER TABLE [dbo].[Ticket]
    ADD FOREIGN KEY ([userId]) REFERENCES [dbo].[User] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Ticket]...';


GO
ALTER TABLE [dbo].[Ticket]
    ADD FOREIGN KEY ([placeId]) REFERENCES [dbo].[Place] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Ticket]...';


GO
ALTER TABLE [dbo].[Ticket]
    ADD FOREIGN KEY ([statusId]) REFERENCES [dbo].[Status] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[TicketService]...';


GO
ALTER TABLE [dbo].[TicketService]
    ADD FOREIGN KEY ([serviceId]) REFERENCES [dbo].[Service] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[TicketService]...';


GO
ALTER TABLE [dbo].[TicketService]
    ADD FOREIGN KEY ([ticketId]) REFERENCES [dbo].[Ticket] ([id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[User]...';


GO
ALTER TABLE [dbo].[User]
    ADD FOREIGN KEY ([userRoleId]) REFERENCES [dbo].[UserRole] ([id]);


GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '81d485f4-462b-4aca-be79-797ac68226fc')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('81d485f4-462b-4aca-be79-797ac68226fc')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '639a2918-d47a-4909-aed1-47898e7f12ad')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('639a2918-d47a-4909-aed1-47898e7f12ad')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'a4d612e0-c743-48b2-8e5c-b55b17486032')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('a4d612e0-c743-48b2-8e5c-b55b17486032')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'd36c8bf9-ee3e-4239-9420-0b711a6d3755')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('d36c8bf9-ee3e-4239-9420-0b711a6d3755')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '50449530-fe0e-4777-8d80-c6f8f8941d7a')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('50449530-fe0e-4777-8d80-c6f8f8941d7a')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '53dce2fe-fd49-468d-b241-e16ba628a239')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('53dce2fe-fd49-468d-b241-e16ba628a239')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'd3001896-c39a-41e6-9750-dafc2929fe84')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('d3001896-c39a-41e6-9750-dafc2929fe84')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '36961592-7ce9-4f9b-909d-8003a915278b')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('36961592-7ce9-4f9b-909d-8003a915278b')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '7f7cfe30-d48e-4a0a-9922-ebd33d4d2825')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('7f7cfe30-d48e-4a0a-9922-ebd33d4d2825')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'c342a032-834b-49e4-acd1-b48a6bb9ad61')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('c342a032-834b-49e4-acd1-b48a6bb9ad61')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '5222da93-ba6d-429f-a1fe-b48d17962e0e')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('5222da93-ba6d-429f-a1fe-b48d17962e0e')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '6d46f940-aba9-4084-8e1d-d03e82f9a83c')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('6d46f940-aba9-4084-8e1d-d03e82f9a83c')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'd417d5d1-a193-4fff-94a4-27c0f78033b8')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('d417d5d1-a193-4fff-94a4-27c0f78033b8')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '48b341c3-24c5-410d-8e70-2ef124f0a834')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('48b341c3-24c5-410d-8e70-2ef124f0a834')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '1115a48b-4e81-48f1-bc28-c0c05574f68e')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('1115a48b-4e81-48f1-bc28-c0c05574f68e')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '89867a85-5693-4739-b2e4-43cb19e443d3')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('89867a85-5693-4739-b2e4-43cb19e443d3')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '730ebaba-dfd6-4647-bc7b-25270c7a03ed')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('730ebaba-dfd6-4647-bc7b-25270c7a03ed')
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

	PRINT 'Inserting seed data for Cinema table'

	INSERT INTO dbo.Cinema (name, city, hallsNumber)
	VALUES 
		('Silver Screen', 'Minsk', 3),
		('Red star', 'Grodno', 2),
		('Belarus', 'Minsk', 3),
		('October', 'Grodno', 2)

	PRINT 'Inserting seed data for Cinema table END'

	PRINT 'Inserting seed data for Hall table'

	INSERT INTO dbo.Hall (cinemaId, [name])
		VALUES 
		((SELECT id FROM dbo.Cinema WHERE Cinema.name='Silver Screen'), 'A'),
		((SELECT id FROM dbo.Cinema WHERE Cinema.name='Silver Screen'), 'B'),
		((SELECT id FROM dbo.Cinema WHERE Cinema.name='Silver Screen'), 'C'),
		((SELECT id FROM dbo.Cinema WHERE Cinema.name='Red star'), 'A'),
		((SELECT id FROM dbo.Cinema WHERE Cinema.name='Red star'), 'B'),
		((SELECT id FROM dbo.Cinema WHERE Cinema.name='Belarus'), 'A'),
		((SELECT id FROM dbo.Cinema WHERE Cinema.name='Belarus'), 'B'),
		((SELECT id FROM dbo.Cinema WHERE Cinema.name='Belarus'), 'C'),
		((SELECT id FROM dbo.Cinema WHERE Cinema.name='October'), 'A'),
		((SELECT id FROM dbo.Cinema WHERE Cinema.name='October'), 'B')

	PRINT 'Inserting seed data for Hall table END'

	PRINT 'Inserting seed data for HallScheme table'

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

	PRINT 'Inserting seed data for HallScheme table END'

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

	PRINT 'Inserting seed data for Film table END'

	PRINT 'Inserting seed data for Session table'

	INSERT INTO dbo.Session (filmId, hallId, [date], [time])
	VALUES 
		(1, 1, convert(DATE, '20171008'), '12.15.00'),
		(2, 1, convert(DATE, '20171007'), '12.15.00'),
		(3, 1, convert(DATE, '20171006'), '12.15.00')
		/*(4, 2, CAST('08/10/2017' AS date), '18.15.00'),
		(5, 2, CAST('07/10/2017' AS date), '18.15.00'),
		(6, 2, CAST('06/10/2017' AS date), '18.15.00'),
		(7, 3, CAST('08/10/2017' AS date), '14.15.00'),
		(8, 3, CAST('07/10/2017' AS date), '14.15.00'),
		(9, 3, CAST('06/10/2017' AS date), '14.15.00'),
		(10, 4, CAST('08/10/2017' AS date), '11.15.00'),
		(1, 4, CAST('07/10/2017' AS date), '11.15.00'),
		(2, 4, CAST('06/10/2017' AS date), '11.15.00'),
		(3, 5, CAST('08/10/2017' AS date), '17.15.00'),
		(4, 5, CAST('07/10/2017' AS date), '17.15.00'),
		(5, 5, CAST('06/10/2017' AS date), '17.15.00'),
		(6, 6, CAST('08/10/2017' AS date), '19.15.00'),
		(7, 6, CAST('07/10/2017' AS date), '19.15.00'),
		(8, 6, CAST('06/10/2017' AS date), '19.15.00'),
		(9, 7, CAST('08/10/2017' AS date), '20.15.00'),
		(10, 7, CAST('07/10/2017' AS date), '21.15.00'),
		(1, 7, CAST('06/10/2017' AS date), '22.15.00'),
		(2, 8, CAST('08/10/2017' AS date), '19.15.00'),
		(3, 8, CAST('07/10/2017' AS date), '19.15.00'),
		(4, 8, CAST('06/10/2017' AS date), '19.15.00'),
		(5, 9, CAST('08/10/2017' AS date), '19.15.00'),
		(6, 9, CAST('07/10/2017' AS date), '19.15.00'),
		(7, 9, CAST('06/10/2017' AS date), '19.15.00'),
		(8, 10, CAST('08/10/2017' AS date), '12.15.00'),
		(9, 10, CAST('07/10/2017' AS date), '12.15.00'),
		(10, 10, CAST('06/10/2017' AS date), '12.15.00')*/

	PRINT 'Inserting seed data for Session table END'

	PRINT 'Inserting seed data for PlaceType table'

	INSERT INTO dbo.PlaceType([name])
	VALUES 
		('double'),
		('standart'),
		('VIP')

	PRINT 'Inserting seed data for PlaceType table END'

	PRINT 'Inserting seed data for Price table'

	INSERT INTO dbo.Price(placeTypeId, sessionId, price)
	VALUES 
		(1, 1, 8),
		(2, 1, 6),
		(3, 1, 10),
		(1, 2, 8),
		(2, 2, 6),
		(3, 2, 10)

	PRINT 'Inserting seed data for Price table END'

	PRINT 'Inserting seed data for Place table'

	INSERT INTO dbo.Place(rowNumber, placeNumber, priceId, hallId)
	VALUES 
		(1, 1, 1, 1),
		(2, 1, 2, 1),
		(3, 1, 3, 1),
		(1, 2, 1, 1),
		(2, 2, 2, 1),
		(3, 2, 3, 1)

	PRINT 'Inserting seed data for Place table END'

	PRINT 'Inserting seed data for UserRole table'

	INSERT INTO dbo.UserRole([name])
	VALUES 
		('administrator'),
		('user')

	PRINT 'Inserting seed data for UserRole table END'

	PRINT 'Inserting seed data for User table'

	INSERT INTO dbo.[User]([login], [password], firstName, lastName, email, userRoleId)
	VALUES 
		('vladK', '12345', 'Vladislav', 'Krasnitskiy', 'v.krasnitskiy@gmail.com', 2),
		('alex', '12345', 'Alexandr', 'Dimidov', 'a.Dimidov@gmail.com', 2),
		('maria', '12345', 'Maria', 'Kuharchuk', 'm.kuharchuk@gmail.com', 2),
		('sasha', '12345', 'Alexandra', 'Kreidich', 'a.kreidich@gmail.com', 2),
		('admin', '123456789', 'Ivan', 'Ivanov', 'i.ivanov@gmail.com', 1)

	PRINT 'Inserting seed data for User table END'

	PRINT 'Inserting seed data for Service table'

	INSERT INTO dbo.[Service]([name], price)
	VALUES 
		('popcorn', 5),
		('sweets', 3),
		('drink', 3)

	PRINT 'Inserting seed data for Service table END'

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

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	PRINT ERROR_MESSAGE();
END catch




GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO
