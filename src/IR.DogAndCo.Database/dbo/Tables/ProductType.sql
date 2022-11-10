CREATE TABLE [dbo].[ProductType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Code] UNIQUEIDENTIFIER NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL
)

GO

CREATE UNIQUE INDEX [UX_ProductType_Code] ON [dbo].[ProductType] ([Code])
