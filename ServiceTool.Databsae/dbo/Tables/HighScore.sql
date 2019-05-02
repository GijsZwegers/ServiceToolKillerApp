CREATE TABLE [dbo].[HighScore] (
    [idHighScore] INT      IDENTITY (1, 1) NOT NULL,
    [idPlayer]    INT      NOT NULL,
    [Date]        DATETIME NOT NULL,
    [idGameMode]  INT      NOT NULL,
    [Score]       INT      NULL,
    CONSTRAINT [PK_Score] PRIMARY KEY CLUSTERED ([idHighScore] ASC),
    CONSTRAINT [FK_HighScore_GameMode] FOREIGN KEY ([idGameMode]) REFERENCES [dbo].[GameMode] ([idGameMode]),
    CONSTRAINT [FK_HighScore_Player] FOREIGN KEY ([idPlayer]) REFERENCES [dbo].[Player] ([idPlayer])
);

