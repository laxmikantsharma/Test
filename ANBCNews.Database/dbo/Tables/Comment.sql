CREATE TABLE [dbo].[Comment] (
    [ID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (100) NULL,
    [Email]       VARCHAR (100)  NULL,
    [Subject]     NVARCHAR (500) NULL,
    [Message]     NVARCHAR (MAX) NULL,
    [CreatedDate] DATETIME       CONSTRAINT [DF_Comment_CreatedDate] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED ([ID] ASC)
);

