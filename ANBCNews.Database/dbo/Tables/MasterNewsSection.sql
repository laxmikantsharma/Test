CREATE TABLE [dbo].[MasterNewsSection] (
    [SectionID]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [NewsSection]      NVARCHAR (100) NOT NULL,
    [MaxNewsInSection] INT            NULL,
	[ImageSize]		VARCHAR				NULL,
    [IsActive]         BIT            NULL,
    CONSTRAINT [PK_MasterNewsSection] PRIMARY KEY CLUSTERED ([SectionID] ASC)
);

