CREATE TABLE [dbo].[Rooftype] (
    [idRooftype]  INT  IDENTITY (1, 1) NOT NULL,
    [Description] TEXT NOT NULL,
    CONSTRAINT [PK_Rooftype] PRIMARY KEY CLUSTERED ([idRooftype] ASC)
);

