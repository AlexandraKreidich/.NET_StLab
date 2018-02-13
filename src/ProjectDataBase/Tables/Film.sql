CREATE TABLE [dbo].[Film]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [StartShowDate] DATE NOT NULL,
    [EndShowDate] DATE NOT NULL,
    [Name] NVARCHAR(50) NOT NULL,
    [Description] NVARCHAR(300) NOT NULL
)