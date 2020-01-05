
CREATE PROCEDURE GetNewsDetails
AS
BEGIN
SELECT [NewsID]
      ,[Headlines]
      ,[NewsTypeID]
      ,[PublishedDate]
      ,[IsPublished]
      ,[CreatedDate]
      ,[CreatedBy]
      ,[ModifyDate]
      ,[ModifyBy]
  FROM [dbo].[NewsHeader]
END
