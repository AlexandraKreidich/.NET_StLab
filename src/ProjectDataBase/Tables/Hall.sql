CREATE TABLE [dbo].[Hall]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [CinemaId] INT NOT NULL,
    [Name] NVARCHAR(50) NOT NULL,
    FOREIGN KEY (CinemaId) REFERENCES [dbo].[Cinema](Id)
)