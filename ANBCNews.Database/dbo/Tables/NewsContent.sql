CREATE TABLE [dbo].[NewsContent] (
    [ContentID]   BIGINT         NOT NULL,
    [NewsID]      BIGINT         NULL,
    [SubContent]  NVARCHAR (MAX) NULL,
    [MainContent] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_NewsContent] PRIMARY KEY CLUSTERED ([ContentID] ASC),
    CONSTRAINT [FK_NewsContent_NewsHeader] FOREIGN KEY ([NewsID]) REFERENCES [dbo].[NewsHeader] ([NewsID])
);

