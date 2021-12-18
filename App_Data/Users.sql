USE [SimpleCart]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 2021/12/18 17:13:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[Name] [nvarchar](63) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Mobile] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Name]  DEFAULT ('') FOR [Name]
GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Address]  DEFAULT ('') FOR [Address]
GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Mobile]  DEFAULT ('') FOR [Mobile]
GO


