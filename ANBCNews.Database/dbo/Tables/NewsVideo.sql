CREATE TABLE [dbo].[NewsVideo] (
    [VideoID]  BIGINT         IDENTITY (1, 1) NOT NULL,
    [NewsID]   BIGINT         NULL,
    [Text]     NVARCHAR (300) NULL,
    [Name]     NVARCHAR (100) NULL,
    [Time]     VARCHAR (10)   NULL,
    [Url]      NVARCHAR (300) NULL,
    [Type]     VARCHAR (10)   NULL,
    [IsActive] BIT            CONSTRAINT [DF_NewsVideo_IsActive] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_NewsVideo] PRIMARY KEY CLUSTERED ([VideoID] ASC),
    CONSTRAINT [FK_NewsVideo_NewsHeader] FOREIGN KEY ([NewsID]) REFERENCES [dbo].[NewsHeader] ([NewsID])
);

