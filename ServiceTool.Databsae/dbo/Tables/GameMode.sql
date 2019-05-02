CREATE TABLE [dbo].[GameMode] (
    [idGameMode] INT           IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50) NOT NULL,
    [Date]       DATETIME      NOT NULL,
    CONSTRAINT [PK_GameMode] PRIMARY KEY CLUSTERED ([idGameMode] ASC)
);

