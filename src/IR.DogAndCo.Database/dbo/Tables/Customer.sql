CREATE TABLE [dbo].[Customer]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Code] UNIQUEIDENTIFIER NOT NULL, 
    [FirstName] NVARCHAR(200) NOT NULL, 
    [LastName] NVARCHAR(200) NOT NULL, 
    [AddressLine] NVARCHAR(200) NOT NULL, 
    [PostalCode] NVARCHAR(15) NOT NULL, 
    [City] NVARCHAR(50) NULL
)

GO

CREATE UNIQUE INDEX [UX_Customer_Code] ON [dbo].[Customer] ([Code])
