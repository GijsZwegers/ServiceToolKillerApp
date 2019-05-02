CREATE TABLE [dbo].[Company] (
    [idCompany] INT          IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (50) NOT NULL,
    [Active]    BIT          NOT NULL,
    CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED ([idCompany] ASC)
);

