
CREATE PROCEDURE GetAllImageType
AS
BEGIN
SELECT [ImageTypeID]
      ,[ImageType]
  FROM [dbo].[MasterImageType]
END
