CREATE TABLE [dbo].[MasterImageType] (
    [ImageTypeID] BIGINT     IDENTITY (1, 1)  NOT NULL,
    [ImageType]   NVARCHAR (50) NULL,
    CONSTRAINT [PK_MasterImageType] PRIMARY KEY CLUSTERED ([ImageTypeID] ASC)
);

