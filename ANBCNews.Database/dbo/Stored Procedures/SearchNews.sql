
CREATE PROCEDURE [dbo].[SearchNews]
@Keyword NVARCHAR(500),
@PageNo INT=1
AS
BEGIN
 
DECLARE  @PageSize INT =10,@TotalRecored INT
IF @PageNo=0
	SET @PageNo=1

 	SELECT @TotalRecored =Count(1) FROM [dbo].[NewsHeader] NH 
	  INNER JOIN [dbo].[MasterNewsType] MIT  ON NH.[NewsTypeID]=MIT.ID
	  LEFT JOIN [dbo].NewsImage NI  ON NI.[NewsID]=NH.[NewsID]
	  WHERE   
	   NH.IsPublished=1 
	  AND NH.[Headline] LIKE N'%'+@Keyword+'%'


	SELECT NH.[NewsID]
		  ,NH.[Headline]
		  ,NH.[NewsTypeID]
		  ,NH.[PublishedDate]
		  ,MIT.NewsType
		  ,CASE WHEN ISNULL(NI.Name,'')!='' THEN '/assets/images/news/'+CAST(NH.[NewsID] AS Varchar(10))+'/'+NI.Name ELSE '' END  ImagePath
		,@TotalRecored AS TotalRecored
	  FROM [dbo].[NewsHeader] NH 
	  INNER JOIN [dbo].[MasterNewsType] MIT  ON NH.[NewsTypeID]=MIT.ID
	  LEFT JOIN [dbo].NewsImage NI  ON NI.[NewsID]=NH.[NewsID]
	  WHERE   
	   NH.IsPublished=1 
	  AND NH.[Headline] LIKE N'%'+@Keyword+'%'
	  ORDER BY NH.PublishedDate DESC
	  OFFSET (@PageNo -1) * @PageSize ROWS
	  FETCH NEXT @PageSize ROWS ONLY

END
