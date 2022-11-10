CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Code] Uniqueidentifier NOT NULL,
    [Name] NVARCHAR(50) NOT NULL, 
    [ProductTypeId] INT NOT NULL, 
    [Price] DECIMAL(18, 2) NULL, 
    CONSTRAINT [FK_Product_ProductType] FOREIGN KEY ([ProductTypeId]) REFERENCES [ProductType]([Id])
)

GO

CREATE UNIQUE INDEX [UX_Product_Code] ON [dbo].[Product] ([Code])
