CREATE TABLE [dbo].[Place]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [HallId] INT NOT NULL,
    [PlaceTypeId] INT NOT NULL,
    [RowNumber] INT NOT NULL,
    [PlaceNumber] INT NOT NULL,
    FOREIGN KEY (HallId) REFERENCES [dbo].[Hall](Id),
    FOREIGN KEY (PlaceTypeId) REFERENCES [dbo].[PlaceType](Id)
)