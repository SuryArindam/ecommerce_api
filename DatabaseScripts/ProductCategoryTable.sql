USE [SuryaArindamEComm];
GO
IF NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[ProductCategory]') AND type in (N'U'))
BEGIN
CREATE TABLE ProductCategory (
    [ProductCategoryId] UNIQUEIDENTIFIER PRIMARY KEY,
    [Name] VARCHAR(50) NOT NULL,
    [Status] INT NOT NULL,
	[IsDeleted] BIT DEFAULT 0,
	[CreatedOn] DATETIME DEFAULT SYSDATETIME(),
	[UpdatedOn] DATETIME NULL
);
END
GO
