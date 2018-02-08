CREATE TABLE [dbo].[Cinema]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] VARCHAR(MAX) NOT NULL, 
    [city] VARCHAR(MAX) NOT NULL, 
    [hallsNumber] INT NOT NULL
)
