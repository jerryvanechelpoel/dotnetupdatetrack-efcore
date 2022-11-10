CREATE TABLE [dbo].[ProductPromotion]
(
	[PromotionId] INT NOT NULL , 
    [ProductId] INT NOT NULL, 
    PRIMARY KEY ([PromotionId], [ProductId]), 
    CONSTRAINT [FK_ProductPromotion_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]),
    CONSTRAINT [FK_ProductPromotion_Promotion] FOREIGN KEY ([PromotionId]) REFERENCES [Promotion]([Id]),
)
