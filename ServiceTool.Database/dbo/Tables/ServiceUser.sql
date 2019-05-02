CREATE TABLE [dbo].[ServiceUser] (
    [idServiceUser] INT          IDENTITY (1, 1) NOT NULL,
    [Password]      VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([idServiceUser] ASC)
);

