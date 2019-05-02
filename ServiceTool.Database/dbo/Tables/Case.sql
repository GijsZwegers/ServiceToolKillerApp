CREATE TABLE [dbo].[Case] (
    [idCase]       INT          IDENTITY (1, 1) NOT NULL,
    [idCompany]    INT          NOT NULL,
    [idCaseStatus] INT          NOT NULL,
    [CaseNumber]   VARCHAR (50) NULL,
    [Comment]      TEXT         NULL,
    [Active]       BIT          NOT NULL,
    CONSTRAINT [PK_Case] PRIMARY KEY CLUSTERED ([idCase] ASC),
    CONSTRAINT [FK_Case_CaseStatus] FOREIGN KEY ([idCaseStatus]) REFERENCES [dbo].[CaseStatus] ([idCaseStatus]),
    CONSTRAINT [FK_Case_Company] FOREIGN KEY ([idCompany]) REFERENCES [dbo].[Company] ([idCompany])
);

