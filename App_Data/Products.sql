CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CategoryId] INT NOT NULL, 
    [Title] NVARCHAR(50) NOT NULL, 
    [ImageUrl] VARCHAR(255) NOT NULL, 
    [DetailHtml] NVARCHAR(MAX) NOT NULL, 
    [Price] NUMERIC NOT NULL, 
    [Inventory] INT NOT NULL
)
