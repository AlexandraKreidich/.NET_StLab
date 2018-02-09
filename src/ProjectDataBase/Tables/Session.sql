﻿CREATE TABLE [dbo].[Session]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [FilmId] INT NOT NULL,
    [HallId] INT NOT NULL,
    [Date] DATE NOT NULL,
    [Time] TIME NOT NULL,
    FOREIGN KEY (FilmId) REFERENCES [dbo].[Film](Id),
    FOREIGN KEY (HallId) REFERENCES [dbo].[Hall](Id)
)