USE [SimpleCart]
GO

/****** Object:  Table [dbo].[Products]    Script Date: 2021/12/18 17:19:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[ImageUrl] [varchar](255) NOT NULL,
	[DetailHtml] [nvarchar](max) NOT NULL,
	[Price] [numeric](18, 0) NOT NULL,
	[Inventory] [int] NOT NULL,
 CONSTRAINT [PK__Products__3214EC0738CEE214] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


