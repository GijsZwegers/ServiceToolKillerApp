CREATE TABLE [dbo].[CustomerUser] (
    [idCustomerUser] INT           IDENTITY (1, 1) NOT NULL,
    [Pin]            VARCHAR (50)  NULL,
    [Site]           VARCHAR (100) NOT NULL,
    [DateOfBirth]    DATE          NULL,
    [idCompany]      INT           NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([idCustomerUser] ASC),
    CONSTRAINT [FK_Customer_Company] FOREIGN KEY ([idCompany]) REFERENCES [dbo].[Company] ([idCompany])
);

