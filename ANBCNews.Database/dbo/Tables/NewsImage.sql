CREATE TABLE [dbo].[NewsImage] (
    [ImageID]       BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]          VARCHAR (50)   NULL,
    [ImageTypeID]   INT            NULL,
    [NewsID]        BIGINT         NULL,
    [AlternateText] NVARCHAR (50)  NULL,
    [Description]   NVARCHAR (300) NULL,
    [IsActive]      BIT            NULL
);

