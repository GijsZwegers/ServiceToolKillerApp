CREATE TABLE [dbo].[ReplaceForm] (
    [idReplaceForm]                 INT          IDENTITY (1, 1) NOT NULL,
    [DateOfReplacement]             DATE         NOT NULL,
    [SerialNumberOptimizer]         VARCHAR (50) NOT NULL,
    [WallPlugsAttachedCorrectly]    BIT          NOT NULL,
    [idRooftype]                    INT          NOT NULL,
    [MeasuredElectricitySolarPanel] INT          NULL,
    [SerialnumberSolarPanel]        VARCHAR (50) NOT NULL,
    [MeasuredElectricityOptimizer]  INT          NULL,
    [SerialnumberNewOptimizer]      VARCHAR (50) NOT NULL,
    [SerialnumberNewSolarPanel]     VARCHAR (50) NOT NULL,
    [idCase]                        INT          NOT NULL,
    CONSTRAINT [PK_ReplaceForm] PRIMARY KEY CLUSTERED ([idReplaceForm] ASC),
    CONSTRAINT [FK_ReplaceForm_Case] FOREIGN KEY ([idCase]) REFERENCES [dbo].[Case] ([idCase]),
    CONSTRAINT [FK_ReplaceForm_Rooftype] FOREIGN KEY ([idRooftype]) REFERENCES [dbo].[Rooftype] ([idRooftype])
);

