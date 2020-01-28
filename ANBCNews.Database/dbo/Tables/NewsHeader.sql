CREATE TABLE [dbo].[NewsHeader] (
    [NewsID]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [Headline]      NVARCHAR (300) NULL,
    [NewsTypeID]    BIGINT         NULL,
    [PublishedDate] DATETIME       CONSTRAINT [DF_NewsHeader_PublishedDate] DEFAULT (getdate()) NULL,
    [IsPublished]   BIT            CONSTRAINT [DF_NewsHeader_IsPublished] DEFAULT ((0)) NULL,
    [PageUrl]       NVARCHAR (300) NULL,
    [IsVideo]       BIT            CONSTRAINT [DF_NewsHeader_IsVideo] DEFAULT ((0)) NULL,
    [CreatedDate]   DATETIME       CONSTRAINT [DF_NewsHeader_CreatedDate] DEFAULT (getdate()) NULL,
    [CreatedBy]     BIGINT         NULL,
    [ModifyDate]    DATETIME       NULL,
    [ModifyBy]      BIGINT         NULL,
    CONSTRAINT [PK_NewsHeader] PRIMARY KEY CLUSTERED ([NewsID] ASC),
    CONSTRAINT [FK_NewsHeader_MasterNewsType] FOREIGN KEY ([NewsTypeID]) REFERENCES [dbo].[MasterNewsType] ([ID])
);

