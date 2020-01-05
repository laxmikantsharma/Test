CREATE TABLE [dbo].[MasterNewsType] (
    [ID]       BIGINT         IDENTITY (1, 1) NOT NULL,
    [NewsType] NVARCHAR (100) NOT NULL,
    [IsActive] BIT            NULL,
    CONSTRAINT [PK_MasterNewsType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

