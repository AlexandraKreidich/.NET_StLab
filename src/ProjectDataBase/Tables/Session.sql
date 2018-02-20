CREATE TABLE [dbo].[Session]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [FilmId] INT NOT NULL,
    [HallId] INT NOT NULL,
    [Date] DATETIMEOFFSET NOT NULL,
    FOREIGN KEY (FilmId) REFERENCES [dbo].[Film](Id),
    FOREIGN KEY (HallId) REFERENCES [dbo].[Hall](Id)
)