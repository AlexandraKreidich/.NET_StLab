﻿CREATE TABLE [dbo].[Cinema]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(50) NOT NULL,
    [City] NVARCHAR(50) NOT NULL,
    [HallsNumber] INT NOT NULL
)