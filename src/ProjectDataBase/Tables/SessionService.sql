CREATE TABLE [dbo].[SessionService]
(
    [ServiceId] INT NOT NULL,
    [SessionId] INT NOT NULL,
    FOREIGN KEY (ServiceId) REFERENCES [dbo].[Service](Id) ON DELETE CASCADE,
    FOREIGN KEY (SessionId) REFERENCES [dbo].[Session](Id) ON DELETE CASCADE
)
