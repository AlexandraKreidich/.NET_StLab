CREATE TABLE [dbo].[Hall]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [CinemaId] INT NOT NULL,
    [Name] VARCHAR(MAX) NOT NULL,
    FOREIGN KEY (CinemaId) REFERENCES [dbo].[Cinema](Id)
)