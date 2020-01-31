
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
		  ,NH.IsVideo 
	  FROM [dbo].[NewsHeader] NH 
	  INNER JOIN [dbo].[MasterNewsType] MIT  ON NH.[NewsTypeID]=MIT.ID 
	  WHERE 
	  NH.NewsID=@NewsID  
	  AND  NH.IsPublished=1 
	  ORDER BY NH.PublishedDate DESC
	
	SELECT	NH.[NewsID] 
		  ,NC.ContentID  
		  ,NC.MainContent  
		  ,NC.SubContent  
	  FROM [dbo].[NewsHeader] NH  
	    JOIN [dbo].NewsContent NC  ON NC.[NewsID]=NH.[NewsID] 
	  WHERE 
	  NH.NewsID=@NewsID  
	  AND  NH.IsPublished=1 
	
	SELECT	NH.[NewsID]
		  ,NI.ImageID
		  ,NI.Name
		  ,CASE WHEN ISNULL(NI.Name,'')!='' THEN '/image/'+CAST(NH.[NewsID] AS Varchar(10))+'/'+NI.Name ELSE '' END  ImagePath
	  FROM [dbo].[NewsHeader] NH  
	    JOIN [dbo].NewsImage NI  ON NI.[NewsID]=NH.[NewsID] 
	  WHERE 
	  NH.NewsID=@NewsID  
	  AND  NH.IsPublished=1   
	
	SELECT	NH.[NewsID] 
		  ,NV.VideoID  
		  ,NV.Name  
		  ,NV.Time    
		  ,NV.Type  
	  FROM [dbo].[NewsHeader] NH  
	    JOIN [dbo].NewsVideo NV  ON NV.[NewsID]=NH.[NewsID]
	  WHERE 
	  NH.NewsID=@NewsID  
	  AND  NH.IsPublished=1 

	IF(@Group='Full')
	  SELECT UI.FirstName,UI.LastName,UI.Email,UI.ProfileImage 
	   ,CASE WHEN ISNULL(UI.ProfileImage,'')!='' THEN '/assets/images/user/'+CAST(UI.UserID AS Varchar(10))+'/'+UI.ProfileImage ELSE '' END  ProfileImage
		   FROM UserInfo UI
	   JOIN [dbo].[NewsHeader] NH ON NH.CreatedBy=UI.UserID
	   WHERE NH.NewsID=@NewsID 
END
