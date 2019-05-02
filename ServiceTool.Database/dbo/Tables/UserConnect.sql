CREATE TABLE [dbo].[UserConnect] (
    [idUserConnect]  INT IDENTITY (1, 1) NOT NULL,
    [idUser]         INT NOT NULL,
    [idServiceUser]  INT NULL,
    [idCustomerUser] INT NULL,
    CONSTRAINT [PK_UserConnect] PRIMARY KEY CLUSTERED ([idUserConnect] ASC),
    CONSTRAINT [FK_UserConnect_CustomerUser] FOREIGN KEY ([idCustomerUser]) REFERENCES [dbo].[CustomerUser] ([idCustomerUser]),
    CONSTRAINT [FK_UserConnect_ServiceUser] FOREIGN KEY ([idServiceUser]) REFERENCES [dbo].[ServiceUser] ([idServiceUser]),
    CONSTRAINT [FK_UserConnect_User] FOREIGN KEY ([idUser]) REFERENCES [dbo].[User] ([idUser])
);

