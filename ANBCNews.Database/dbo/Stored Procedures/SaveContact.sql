CREATE PROC SaveContact
@Name nvarchar(100),
@Email varchar(100),
@Message nvarchar(max)
AS
BEGIN
INSERT INTO [dbo].[Contact]
           ([Name]
           ,[Email]
           ,[Message])
     VALUES
           (@Name
           ,@Email
           ,@Message)
		     SELECT IDENT_CURRENT('Comment') AS ID
END