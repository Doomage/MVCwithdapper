USE [bookstore]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 15/1/2019 6:35:15 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) COLLATE Greek_100_CI_AI NOT NULL,
	[Author] [nvarchar](100) COLLATE Greek_100_CI_AI NOT NULL,
	[Price] [decimal](6, 2) NOT NULL,
	[PublicationYear] [int] NOT NULL,
	[PublisherId] [int] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
)
GO
/****** Object:  Table [dbo].[Publishers]    Script Date: 15/1/2019 6:35:15 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publishers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE Greek_100_CI_AI NOT NULL,
 CONSTRAINT [PK_Publisher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
)
GO
SET IDENTITY_INSERT [dbo].[Publishers] ON 
GO
INSERT [dbo].[Publishers] ([Id], [Name]) VALUES (1, N'Παπασωτηρίου')
GO
INSERT [dbo].[Publishers] ([Id], [Name]) VALUES (2, N'Πατάκης')
GO
INSERT [dbo].[Publishers] ([Id], [Name]) VALUES (3, N'Σαβάλας')
GO
INSERT [dbo].[Publishers] ([Id], [Name]) VALUES (4, N'Gutenberg')
GO
INSERT [dbo].[Publishers] ([Id], [Name]) VALUES (5, N'Μεταίχμιο')
GO
INSERT [dbo].[Publishers] ([Id], [Name]) VALUES (6, N'O''Reilly')
GO
SET IDENTITY_INSERT [dbo].[Publishers] OFF
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Book_Publisher] FOREIGN KEY([PublisherId])
REFERENCES [dbo].[Publishers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Book_Publisher]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [CK_Books_Year] CHECK  (([PublicationYear]<=datepart(year,getdate())))
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [CK_Books_Year]
GO
