CREATE TABLE [dbo].[NewsSection] (
    [NewSectionID] INT      IDENTITY (1, 1) NOT NULL,
    [SectionID]    INT      NULL,
    [NewsID]       BIGINT   NULL,
    [ArchiveDate]  DATETIME NULL,
    [IsActive]     BIT      CONSTRAINT [DF_NewsSection_IsActive] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_NewsSection] PRIMARY KEY CLUSTERED ([NewSectionID] ASC)
);

