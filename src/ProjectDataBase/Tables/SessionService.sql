CREATE TABLE [dbo].[SessionService]
(
    [ServiceId] INT NOT NULL,
    [SessionId] INT NULL,
    FOREIGN KEY (ServiceId) REFERENCES [dbo].[Service](Id),
    FOREIGN KEY (SessionId) REFERENCES [dbo].[Session](Id)
)
