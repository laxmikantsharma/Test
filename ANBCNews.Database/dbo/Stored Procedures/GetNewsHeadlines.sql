
CREATE PROCEDURE [dbo].[GetNewsHeadlines]
@NewsTypeID INT=0,
@SectionID INT=0
AS
BEGIN

DECLARE   @temp TABLE(NewsID INT)  
DECLARE @MaxNewsInSection INT 

	IF(@SectionID>0)
	BEGIN
		SELECT @MaxNewsInSection=CASE WHEN MNS.MaxNewsInSection>0 THEN  MNS.MaxNewsInSection ELSE 200 END 
		FROM [dbo].[MasterNewsSection] MNS WHERE  MNS.SectionID=@SectionID 

		  INSERT INTO @temp  SELECT TOP(@MaxNewsInSection) NH.[NewsID] 
		  FROM [dbo].[NewsHeader] NH 
			JOIN [dbo].[NewsSection] NS ON NH.NewsID =NS.NewsID
			WHERE NS.SectionID=@SectionID 
			ORDER BY PublishedDate DESC
	END

	SELECT NH.[NewsID]
		  ,NH.[Headline]
		  ,NH.[NewsTypeID]
		  ,NH.[PublishedDate]
		  ,MIT.NewsType
		  ,CASE WHEN ISNULL(NI.Name,'')!='' THEN '/assets/images/news/'+CAST(NH.[NewsID] AS Varchar(10))+'/'+NI.Name ELSE '' END  ImagePath
	  FROM [dbo].[NewsHeader] NH 
	  INNER JOIN [dbo].[MasterNewsType] MIT  ON NH.[NewsTypeID]=MIT.ID
	  LEFT JOIN [dbo].NewsImage NI  ON NI.[NewsID]=NH.[NewsID]
	  WHERE 
	  (NH.NewsTypeID=@NewsTypeID OR @NewsTypeID=0)
	  AND (NH.NewsID IN(SELECT NS.NewsID FROM @temp NS) OR @SectionID=0)
	  AND  NH.IsPublished=1 
	  ORDER BY NH.PublishedDate DESC

END