﻿CREATE TABLE [dbo].[Film]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [StartShowDate] DATE NOT NULL,
    [EndShowDate] DATE NOT NULL,
    [Name] TEXT NOT NULL,
    [Description] TEXT NOT NULL
)