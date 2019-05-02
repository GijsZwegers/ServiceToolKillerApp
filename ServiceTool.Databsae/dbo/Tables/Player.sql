CREATE TABLE [dbo].[Player] (
    [idPlayer] INT           IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (15) NOT NULL,
    [Mail]     NVARCHAR (50) NULL,
    CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED ([idPlayer] ASC)
);

