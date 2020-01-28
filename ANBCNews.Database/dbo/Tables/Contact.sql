CREATE TABLE [dbo].[Contact] (
    [ID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (100) NULL,
    [Email]       VARCHAR (100)  NULL,
    [Message]     NVARCHAR (MAX) NULL,
    [CreatedDate] DATETIME       CONSTRAINT [DF_Contact_CreatedDate] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED ([ID] ASC)
);

