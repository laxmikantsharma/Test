
CREATE PROCEDURE [dbo].[GetNewsDetails]
@NewsID BIGINT
AS
BEGIN
SELECT NH.[NewsID]
		  ,NH.[Headline]
		  ,NH.[NewsTypeID]
		  ,NH.[PublishedDate]
		  ,MIT.NewsType
		  ,CASE WHEN ISNULL(NI.Name,'')!='' THEN '/assets/images/news/'+CAST(NH.[NewsID] AS Varchar(10))+'/'+NI.Name ELSE '' END  ImagePath
		  ,NC.MainContent 
	  FROM [dbo].[NewsHeader] NH 
	  INNER JOIN [dbo].[MasterNewsType] MIT  ON NH.[NewsTypeID]=MIT.ID
	  LEFT JOIN [dbo].NewsImage NI  ON NI.[NewsID]=NH.[NewsID]
	  LEFT JOIN [dbo].NewsContent NC  ON NC.[NewsID]=NH.[NewsID]
	  WHERE 
	  NH.NewsID=@NewsID  
	  AND  NH.IsPublished=1 
	  ORDER BY NH.PublishedDate DESC

END
