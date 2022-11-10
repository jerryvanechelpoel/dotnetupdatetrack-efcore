CREATE TABLE [dbo].[OrderLine]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [OrderId] INT NOT NULL, 
    [ProductId] INT NOT NULL, 
    [Amount] DECIMAL(18, 2) NOT NULL, 
    [Price] DECIMAL(18, 2) NOT NULL, 
    CONSTRAINT [FK_OrderLine_Order] FOREIGN KEY ([OrderId]) REFERENCES [Order]([Id]),
    CONSTRAINT [FK_OrderLine_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id])
)
