CREATE TABLE [dbo].[Hall]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [CinemaId] INT NOT NULL,
    [Name] NVARCHAR(50) NOT NULL,
    FOREIGN KEY (CinemaId) REFERENCES [dbo].[Cinema](Id)
)