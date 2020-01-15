/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
SET IDENTITY_INSERT [dbo].[MasterImageType] ON  
 
IF(NOT EXISTS(SELECT 1 FROM [MasterImageType] WHERE ImageTypeID = 1))
BEGIN
	INSERT [dbo].[MasterImageType] (ImageTypeID, ImageType) VALUES (1, N'Banner')
END
SET IDENTITY_INSERT [dbo].[MasterImageType] OFF

GO

SET IDENTITY_INSERT [dbo].[MasterNewsSection] ON  
  
IF(NOT EXISTS(SELECT 1 FROM [MasterNewsSection] WHERE [SectionID] = 1))
BEGIN
INSERT [dbo].[MasterNewsSection] ([SectionID], [NewsSection], [MaxNewsInSection], [IsActive]) VALUES (1, N'Home Slider News', 5, 1)
END 
IF(NOT EXISTS(SELECT 1 FROM [MasterNewsSection] WHERE [SectionID] = 2))
BEGIN
INSERT [dbo].[MasterNewsSection] ([SectionID], [NewsSection], [MaxNewsInSection], [IsActive]) VALUES (2, N'Header Breaking News', 3, 1)
END 
IF(NOT EXISTS(SELECT 1 FROM [MasterNewsSection] WHERE [SectionID] = 3))
BEGIN
INSERT [dbo].[MasterNewsSection] ([SectionID], [NewsSection], [MaxNewsInSection], [IsActive]) VALUES (3, N'Home Latest News ', 3, 1)
END 
IF(NOT EXISTS(SELECT 1 FROM [MasterNewsSection] WHERE [SectionID] = 4))
BEGIN
INSERT [dbo].[MasterNewsSection] ([SectionID], [NewsSection], [MaxNewsInSection], [IsActive]) VALUES (4, N'Home News ', 20, 1)
END  
IF(NOT EXISTS(SELECT 1 FROM [MasterNewsSection] WHERE [SectionID] = 5))
BEGIN
INSERT [dbo].[MasterNewsSection] ([SectionID], [NewsSection], [MaxNewsInSection], [IsActive]) VALUES (5, N'Trading News', 1, 1)
END  
SET IDENTITY_INSERT [dbo].[MasterNewsSection] OFF

GO

SET IDENTITY_INSERT [dbo].[MasterNewsType] ON 

IF(NOT EXISTS(SELECT 1 FROM [MasterNewsType] WHERE [ID] = 1))
BEGIN
	INSERT [dbo].[MasterNewsType] ([ID], [NewsType], [IsActive]) VALUES (1, N'सामान्य न्यूज़', 1)
END
IF(NOT EXISTS(SELECT 1 FROM [MasterNewsType] WHERE [ID] = 2))
BEGIN
	INSERT [dbo].[MasterNewsType] ([ID], [NewsType], [IsActive]) VALUES (2, N'Social News', 1)
END
IF(NOT EXISTS(SELECT 1 FROM [MasterNewsType] WHERE [ID] = 3))
BEGIN
	INSERT [dbo].[MasterNewsType] ([ID], [NewsType], [IsActive]) VALUES (3, N'Auto News', 1)
END
IF(NOT EXISTS(SELECT 1 FROM [MasterNewsType] WHERE [ID] = 4))
BEGIN
	INSERT [dbo].[MasterNewsType] ([ID], [NewsType], [IsActive]) VALUES (4, N'Tech News', 1)
END
IF(NOT EXISTS(SELECT 1 FROM [MasterNewsType] WHERE [ID] = 5))
BEGIN
	INSERT [dbo].[MasterNewsType] ([ID], [NewsType], [IsActive]) VALUES (5, N'Legal News', 1)
END
IF(NOT EXISTS(SELECT 1 FROM [MasterNewsType] WHERE [ID] = 6))
BEGIN
	INSERT [dbo].[MasterNewsType] ([ID], [NewsType], [IsActive]) VALUES (6, N'Crime News', 1)
END
IF(NOT EXISTS(SELECT 1 FROM [MasterNewsType] WHERE [ID] = 7))
BEGIN
INSERT [dbo].[MasterNewsType] ([ID], [NewsType], [IsActive]) VALUES (7, N'National News', 1)
END
IF(NOT EXISTS(SELECT 1 FROM [MasterNewsType] WHERE [ID] = 8))
BEGIN
	INSERT [dbo].[MasterNewsType] ([ID], [NewsType], [IsActive]) VALUES (8, N'International News', 1)
END
IF(NOT EXISTS(SELECT 1 FROM [MasterNewsType] WHERE [ID] = 9))
BEGIN
	INSERT [dbo].[MasterNewsType] ([ID], [NewsType], [IsActive]) VALUES (9, N'Lifestyle News', 1)
END
IF(NOT EXISTS(SELECT 1 FROM [MasterNewsType] WHERE [ID] = 10))
BEGIN
	INSERT [dbo].[MasterNewsType] ([ID], [NewsType], [IsActive]) VALUES (10, N'Art News', 1)
END
IF(NOT EXISTS(SELECT 1 FROM [MasterNewsType] WHERE [ID] = 11))
BEGIN
	INSERT [dbo].[MasterNewsType] ([ID], [NewsType], [IsActive]) VALUES (11, N'Entertainment News', 1)
END
IF(NOT EXISTS(SELECT 1 FROM [MasterNewsType] WHERE [ID] = 12))
BEGIN
	INSERT [dbo].[MasterNewsType] ([ID], [NewsType], [IsActive]) VALUES (12, N'Sports News', 1)
END
IF(NOT EXISTS(SELECT 1 FROM [MasterNewsType] WHERE [ID] = 13))
BEGIN
	INSERT [dbo].[MasterNewsType] ([ID], [NewsType], [IsActive]) VALUES (13, N'Legal News', 1)
END
IF(NOT EXISTS(SELECT 1 FROM [MasterNewsType] WHERE [ID] = 14))
BEGIN
	INSERT [dbo].[MasterNewsType] ([ID], [NewsType], [IsActive]) VALUES (14, N'Business News', 1)
END 
SET IDENTITY_INSERT [dbo].[MasterNewsType] OFF

GO
