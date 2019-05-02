CREATE TABLE [dbo].[User] (
    [idUser]         INT          IDENTITY (1, 1) NOT NULL,
    [Name]           VARCHAR (50) NOT NULL,
    [idCustomerUser] INT          NULL,
    [idServiceUser]  INT          NULL,
    [IsActive]       BIT          NOT NULL,
    CONSTRAINT [PK_User_1] PRIMARY KEY CLUSTERED ([idUser] ASC),
    CONSTRAINT [FK_User_CustomerUser] FOREIGN KEY ([idCustomerUser]) REFERENCES [dbo].[CustomerUser] ([idCustomerUser]),
    CONSTRAINT [FK_User_ServiceUser] FOREIGN KEY ([idServiceUser]) REFERENCES [dbo].[ServiceUser] ([idServiceUser])
);

