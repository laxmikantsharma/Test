-- Batch submitted through debugger: SQLQuery3.sql|0|0|C:\Users\Selu\AppData\Local\Temp\~vs27F0.sql
CREATE PROC SaveComment
@Name nvarchar(100),
@Email varchar(100),
@Subject nvarchar(500),
@Message nvarchar(max)
AS
BEGIN
INSERT INTO [dbo].[Comment]
           ([Name]
           ,[Email]
           ,[Subject]
           ,[Message])
     VALUES
           (@Name
           ,@Email
           ,@Subject
           ,@Message)
		     SELECT IDENT_CURRENT('Comment') AS ID
END


