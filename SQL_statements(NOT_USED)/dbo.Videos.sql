CREATE TABLE [dbo].[Videos] (
    [Id]     INT           IDENTITY (1, 1) NOT NULL,
    [Title]  NVARCHAR (50) NOT NULL,
    [URL]    NVARCHAR (50) NOT NULL,
    [userID] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Videos_Users] FOREIGN KEY ([userID]) REFERENCES [dbo].[Users] ([Id])
);

