CREATE TABLE [dbo].[Order]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Code] UNIQUEIDENTIFIER NOT NULL,
    [CustomerId] INT NOT NULL, 
    [OrderDate] DATETIME NOT NULL, 
    CONSTRAINT [FK_Order_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([Id])
)

GO

CREATE UNIQUE INDEX [UX_Order_Code] ON [dbo].[Order] ([Code])