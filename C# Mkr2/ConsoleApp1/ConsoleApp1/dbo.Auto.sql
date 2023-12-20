CREATE TABLE [dbo].[Auto] (
    [Id]          INT            NOT NULL,
    [LastName]    NVARCHAR (50)  NULL,
    [CarNumber]   NVARCHAR (50)  NULL,
    [Brand]       NVARCHAR (50)  NULL,
    [Price]       DECIMAL (18)   NULL,
    [HomeAddress] NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

