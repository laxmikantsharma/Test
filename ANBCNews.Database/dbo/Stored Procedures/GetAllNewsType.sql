
CREATE PROCEDURE GetAllNewsType
AS
BEGIN
SELECT [ID]
      ,[NewsType]
      ,[IsActive]
  FROM [dbo].[MasterNewsType]
END
