CREATE TABLE [dbo].[SessionService]
(
    [ServiceId] INT NOT NULL,
    [SessionId] INT NOT NULL,
    FOREIGN KEY (ServiceId) REFERENCES [dbo].[Service](Id),
    FOREIGN KEY (SessionId) REFERENCES [dbo].[Session](Id) ON DELETE CASCADE
)
