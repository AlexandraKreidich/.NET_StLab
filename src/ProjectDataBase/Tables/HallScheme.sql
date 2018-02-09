CREATE TABLE [dbo].[HallScheme]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [RowNumber] INT NOT NULL,
    [PlacesCount] INT NOT NULL,
    [HallId] INT NOT NULL,
    FOREIGN KEY (HallId) REFERENCES [dbo].[Hall](Id)
)