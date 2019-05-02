CREATE TABLE [dbo].[CaseStatus] (
    [idCaseStatus] INT  IDENTITY (1, 1) NOT NULL,
    [Description]  TEXT NOT NULL,
    CONSTRAINT [PK_CaseStatus] PRIMARY KEY CLUSTERED ([idCaseStatus] ASC)
);

