
CREATE PROCEDURE [dbo].[GetNewsDetails]
@NewsID BIGINT,
@Group varchar(10)
AS
BEGIN

SELECT	NH.[NewsID]
		  ,NH.[Headline]
		  ,NH.[NewsTypeID]
		  ,NH.[PublishedDate]
		  ,NH.[PageUrl]
		  ,MIT.NewsType
		    ,CASE WHEN ISNULL(NI.Name,'')!='' THEN '/image/'+CAST(NH.[NewsID] AS Varchar(10))+'/'+NI.Name ELSE '' END  ImagePath
		  ,NC.MainContent 
	  FROM [dbo].[NewsHeader] NH 
	  INNER JOIN [dbo].[MasterNewsType] MIT  ON NH.[NewsTypeID]=MIT.ID
	  LEFT JOIN [dbo].NewsImage NI  ON NI.[NewsID]=NH.[NewsID]
	  LEFT JOIN [dbo].NewsContent NC  ON NC.[NewsID]=NH.[NewsID]
	  WHERE 
	  NH.NewsID=@NewsID  
	  AND  NH.IsPublished=1 
	  ORDER BY NH.PublishedDate DESC
	
	IF(@Group='Full')
	  SELECT UI.FirstName,UI.LastName,UI.Email,UI.ProfileImage 
	   ,CASE WHEN ISNULL(UI.ProfileImage,'')!='' THEN '/assets/images/user/'+CAST(UI.UserID AS Varchar(10))+'/'+UI.ProfileImage ELSE '' END  ProfileImage
		   FROM UserInfo UI
	   JOIN [dbo].[NewsHeader] NH ON NH.CreatedBy=UI.UserID
	   WHERE NH.NewsID=@NewsID 
END
