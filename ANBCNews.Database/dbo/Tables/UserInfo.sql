CREATE TABLE [dbo].[UserInfo] (
    [UserID]       BIGINT       IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (20) NULL,
    [LastName]     VARCHAR (20) NULL,
    [Username]     VARCHAR (50) NULL,
    [Password]     NCHAR (10)   NULL,
    [Email]        VARCHAR (50) NULL,
    [IsActive]     BIT          CONSTRAINT [DF_UserInfo_IsActive] DEFAULT ((0)) NULL,
    [ProfileImage] VARCHAR (50) NULL,
    CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED ([UserID] ASC)
);

