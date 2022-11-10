CREATE TABLE [dbo].[Promotion]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Code] UNIQUEIDENTIFIER NOT NULL, 
    [Description] NVARCHAR(200) NOT NULL, 
    [PromotionType] INT NOT NULL, 
    [DiscountValue] DECIMAL(18, 2) NOT NULL, 
    [StartDate] DATETIME NOT NULL, 
    [EndDate] DATETIME NOT NULL
)

GO

CREATE UNIQUE INDEX [UX_Promotion_Code] ON [dbo].[Promotion] ([Code])