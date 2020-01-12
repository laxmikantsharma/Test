CREATE TABLE [dbo].[MasterImageType] (
    [ImageTypeID] BIGINT        NOT NULL,
    [ImageType]   NVARCHAR (50) NULL,
    CONSTRAINT [PK_MasterImageType] PRIMARY KEY CLUSTERED ([ImageTypeID] ASC)
);

