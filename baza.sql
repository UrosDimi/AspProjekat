USE [ShopProjekat]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/16/2022 5:50:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AvailableDatas]    Script Date: 6/16/2022 5:50:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AvailableDatas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Specification_id] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](50) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_AvailableDatas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carts]    Script Date: 6/16/2022 5:50:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
	[User_id] [int] NOT NULL,
	[DateAndTime] [datetime2](7) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](50) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 6/16/2022 5:50:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Desc] [nvarchar](100) NOT NULL,
	[image_id] [int] NULL,
	[parent_id] [int] NULL,
	[ImageId] [int] NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](50) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoryProduct]    Script Date: 6/16/2022 5:50:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryProduct](
	[CategoriesId] [int] NOT NULL,
	[ProductsId] [int] NOT NULL,
 CONSTRAINT [PK_CategoryProduct] PRIMARY KEY CLUSTERED 
(
	[CategoriesId] ASC,
	[ProductsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategorySpecification]    Script Date: 6/16/2022 5:50:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategorySpecification](
	[CategoriesId] [int] NOT NULL,
	[SpecificationsId] [int] NOT NULL,
 CONSTRAINT [PK_CategorySpecification] PRIMARY KEY CLUSTERED 
(
	[CategoriesId] ASC,
	[SpecificationsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 6/16/2022 5:50:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](20) NOT NULL,
	[Comments] [nvarchar](150) NOT NULL,
	[Parent_comment_id] [int] NULL,
	[Product_id] [int] NOT NULL,
	[User_id] [int] NOT NULL,
	[ProductId] [int] NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](50) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImageProduct]    Script Date: 6/16/2022 5:50:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageProduct](
	[ImagesId] [int] NOT NULL,
	[ProductsId] [int] NOT NULL,
 CONSTRAINT [PK_ImageProduct] PRIMARY KEY CLUSTERED 
(
	[ImagesId] ASC,
	[ProductsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 6/16/2022 5:50:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Path] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prices]    Script Date: 6/16/2022 5:50:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[price] [decimal](18, 2) NOT NULL,
	[Product_id] [int] NOT NULL,
	[DateFrom] [datetime2](7) NOT NULL,
	[DateTo] [datetime2](7) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](50) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Prices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 6/16/2022 5:50:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Desc] [nvarchar](100) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](50) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductsCarts]    Script Date: 6/16/2022 5:50:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductsCarts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[ProductPrice] [decimal](18, 2) NOT NULL,
	[ProductAmount] [int] NOT NULL,
	[Product_id] [int] NOT NULL,
	[Cart_id] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](50) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProductsCarts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductSpecifications]    Script Date: 6/16/2022 5:50:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSpecifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[value] [nvarchar](30) NOT NULL,
	[Specification_id] [int] NOT NULL,
	[AvailableData_id] [int] NOT NULL,
	[Product_id] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](50) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProductSpecifications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specification]    Script Date: 6/16/2022 5:50:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specification](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](50) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Specification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/16/2022 5:50:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[UserName] [nvarchar](10) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[IsSuperUser] [bit] NOT NULL,
	[Email] [nvarchar](20) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[DeletedBy] [nvarchar](50) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserUseCase]    Script Date: 6/16/2022 5:50:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserUseCase](
	[UserId] [int] NOT NULL,
	[UserCaseId] [int] NOT NULL,
 CONSTRAINT [PK_UserUseCase] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[UserCaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220612163233_Initial', N'5.0.17')
GO
SET IDENTITY_INSERT [dbo].[Carts] ON 

INSERT [dbo].[Carts] ([Id], [TotalPrice], [User_id], [DateAndTime], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (3, CAST(520.00 AS Decimal(18, 2)), 2, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-06-16T10:05:39.0944425' AS DateTime2), 1, NULL, NULL, CAST(N'2022-06-16T10:35:45.6929268' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Carts] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [Desc], [image_id], [parent_id], [ImageId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (1, N'Category 1', N'Opis kategorije 1, nesto nesto nesto', NULL, NULL, NULL, CAST(N'2022-06-15T19:40:11.8600977' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Categories] ([Id], [Name], [Desc], [image_id], [parent_id], [ImageId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (2, N'Category 2', N'Opis kategorije 2, nesto nesto nesto', NULL, NULL, NULL, CAST(N'2022-06-15T19:40:28.2766863' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Categories] ([Id], [Name], [Desc], [image_id], [parent_id], [ImageId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (3, N'Category 3', N'Opis kategorije 3, nesto nesto nesto', NULL, NULL, NULL, CAST(N'2022-06-15T19:40:40.8387711' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Categories] ([Id], [Name], [Desc], [image_id], [parent_id], [ImageId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (4, N'Category 4', N'Opis kategorije 4, nesto nesto nesto', NULL, NULL, NULL, CAST(N'2022-06-15T19:41:41.6289654' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Categories] ([Id], [Name], [Desc], [image_id], [parent_id], [ImageId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (5, N'Category 5', N'Opis kategorije 5, nesto nesto nesto', NULL, 3, NULL, CAST(N'2022-06-15T19:43:31.7710581' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Categories] ([Id], [Name], [Desc], [image_id], [parent_id], [ImageId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (6, N'Category 6', N'Opis kategorije 6, nesto nesto nesto', NULL, 4, NULL, CAST(N'2022-06-15T19:43:48.0941319' AS DateTime2), 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([Id], [Title], [Comments], [Parent_comment_id], [Product_id], [User_id], [ProductId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (1, N'Test proba proba', N'Komentar 1, nesto nesto nesto nesto', NULL, 0, 2, 7, CAST(N'2022-06-16T12:53:52.8038397' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Comments] ([Id], [Title], [Comments], [Parent_comment_id], [Product_id], [User_id], [ProductId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (3, N'Komentar 1 na', N'Komentar 2, nesto nesto nesto nesto', 1, 0, 2, 7, CAST(N'2022-06-16T12:57:45.8114842' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Comments] ([Id], [Title], [Comments], [Parent_comment_id], [Product_id], [User_id], [ProductId], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (4, N'Komentar 1 na', N'Komentar 2, nesto nesto nesto nesto', 1, 0, 2, 7, CAST(N'2022-06-16T13:01:03.4310972' AS DateTime2), 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Comments] OFF
GO
INSERT [dbo].[ImageProduct] ([ImagesId], [ProductsId]) VALUES (3, 5)
INSERT [dbo].[ImageProduct] ([ImagesId], [ProductsId]) VALUES (4, 6)
INSERT [dbo].[ImageProduct] ([ImagesId], [ProductsId]) VALUES (5, 7)
GO
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([Id], [Path], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (1, N'16acf142-03ac-455b-9fca-d0373e59c4f6banner-2.jpg', CAST(N'2022-06-15T15:37:09.3731659' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Images] ([Id], [Path], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (2, N'75ea10a5-a609-4491-8e21-ef6c715b3493banner-3.jpg', CAST(N'2022-06-15T15:37:09.3731696' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Images] ([Id], [Path], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (3, N'db0fb187-011f-41e2-a823-6533c4a000c0banner-1.jpg', CAST(N'2022-06-16T09:53:25.0538343' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Images] ([Id], [Path], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (4, N'30c4d2ca-287b-4111-a848-d3f899f36fb7banner-1.jpg', CAST(N'2022-06-16T10:33:55.0291388' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Images] ([Id], [Path], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (5, N'f06a847e-a456-41f9-a86e-a452f1284e13404.png', CAST(N'2022-06-16T10:34:26.5431987' AS DateTime2), 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Images] OFF
GO
SET IDENTITY_INSERT [dbo].[Prices] ON 

INSERT [dbo].[Prices] ([Id], [price], [Product_id], [DateFrom], [DateTo], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (1, CAST(200.00 AS Decimal(18, 2)), 5, CAST(N'2022-06-16T09:53:18.3002825' AS DateTime2), NULL, CAST(N'2022-06-16T09:53:25.0538340' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Prices] ([Id], [price], [Product_id], [DateFrom], [DateTo], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (2, CAST(350.00 AS Decimal(18, 2)), 6, CAST(N'2022-06-16T10:33:54.6432585' AS DateTime2), NULL, CAST(N'2022-06-16T10:33:55.0291364' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Prices] ([Id], [price], [Product_id], [DateFrom], [DateTo], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (3, CAST(320.00 AS Decimal(18, 2)), 7, CAST(N'2022-06-16T10:34:26.5410477' AS DateTime2), NULL, CAST(N'2022-06-16T10:34:26.5431981' AS DateTime2), 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Prices] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [Desc], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (5, N'Product 6', N'Nesto nesto nesto nesto nesto', CAST(N'2022-06-16T09:53:25.0537926' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Products] ([Id], [Name], [Desc], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (6, N'Product 7', N'Nesto nesto nesto nesto nesto', CAST(N'2022-06-16T10:33:55.0290331' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Products] ([Id], [Name], [Desc], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (7, N'Product 8', N'Proba neka neka neka neka', CAST(N'2022-06-16T10:34:26.5431955' AS DateTime2), 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductsCarts] ON 

INSERT [dbo].[ProductsCarts] ([Id], [ProductName], [ProductPrice], [ProductAmount], [Product_id], [Cart_id], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (3, N'Product 6', CAST(200.00 AS Decimal(18, 2)), 3, 5, 3, CAST(N'2022-06-16T10:05:39.0944417' AS DateTime2), 1, NULL, NULL, CAST(N'2022-06-16T10:21:47.0922122' AS DateTime2), NULL)
INSERT [dbo].[ProductsCarts] ([Id], [ProductName], [ProductPrice], [ProductAmount], [Product_id], [Cart_id], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (4, N'Product 8', CAST(320.00 AS Decimal(18, 2)), 2, 7, 3, CAST(N'2022-06-16T10:35:45.6929251' AS DateTime2), 1, NULL, NULL, CAST(N'2022-06-16T10:51:52.1128843' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[ProductsCarts] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [LastName], [UserName], [Password], [IsSuperUser], [Email], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (2, N'Pera', N'Peric', N'PeraPera', N'pera123', 1, N'pera@gmail.com', CAST(N'2022-06-12T00:00:00.0000000' AS DateTime2), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([Id], [Name], [LastName], [UserName], [Password], [IsSuperUser], [Email], [CreatedAt], [IsActive], [DeletedAt], [DeletedBy], [UpdatedAt], [UpdatedBy]) VALUES (6, N'Mika', N'Mikic', N'Mika123', N'Lozinka123!', 0, N'mika@gmail.com', CAST(N'2022-06-15T15:57:00.9919326' AS DateTime2), 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
INSERT [dbo].[UserUseCase] ([UserId], [UserCaseId]) VALUES (2, 1)
INSERT [dbo].[UserUseCase] ([UserId], [UserCaseId]) VALUES (2, 3)
INSERT [dbo].[UserUseCase] ([UserId], [UserCaseId]) VALUES (2, 4)
INSERT [dbo].[UserUseCase] ([UserId], [UserCaseId]) VALUES (2, 5)
INSERT [dbo].[UserUseCase] ([UserId], [UserCaseId]) VALUES (2, 10)
INSERT [dbo].[UserUseCase] ([UserId], [UserCaseId]) VALUES (2, 11)
INSERT [dbo].[UserUseCase] ([UserId], [UserCaseId]) VALUES (2, 13)
INSERT [dbo].[UserUseCase] ([UserId], [UserCaseId]) VALUES (2, 14)
GO
ALTER TABLE [dbo].[AvailableDatas] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Carts] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Categories] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Comments] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Prices] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[ProductsCarts] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[ProductSpecifications] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Specification] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[AvailableDatas]  WITH CHECK ADD  CONSTRAINT [FK_AvailableDatas_Specification_Specification_id] FOREIGN KEY([Specification_id])
REFERENCES [dbo].[Specification] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AvailableDatas] CHECK CONSTRAINT [FK_AvailableDatas_Specification_Specification_id]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_Users_User_id] FOREIGN KEY([User_id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_Users_User_id]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories_parent_id] FOREIGN KEY([parent_id])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Categories_parent_id]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Images_ImageId] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Images] ([Id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Images_ImageId]
GO
ALTER TABLE [dbo].[CategoryProduct]  WITH CHECK ADD  CONSTRAINT [FK_CategoryProduct_Categories_CategoriesId] FOREIGN KEY([CategoriesId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CategoryProduct] CHECK CONSTRAINT [FK_CategoryProduct_Categories_CategoriesId]
GO
ALTER TABLE [dbo].[CategoryProduct]  WITH CHECK ADD  CONSTRAINT [FK_CategoryProduct_Products_ProductsId] FOREIGN KEY([ProductsId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CategoryProduct] CHECK CONSTRAINT [FK_CategoryProduct_Products_ProductsId]
GO
ALTER TABLE [dbo].[CategorySpecification]  WITH CHECK ADD  CONSTRAINT [FK_CategorySpecification_Categories_CategoriesId] FOREIGN KEY([CategoriesId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CategorySpecification] CHECK CONSTRAINT [FK_CategorySpecification_Categories_CategoriesId]
GO
ALTER TABLE [dbo].[CategorySpecification]  WITH CHECK ADD  CONSTRAINT [FK_CategorySpecification_Specification_SpecificationsId] FOREIGN KEY([SpecificationsId])
REFERENCES [dbo].[Specification] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CategorySpecification] CHECK CONSTRAINT [FK_CategorySpecification_Specification_SpecificationsId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Comments_Parent_comment_id] FOREIGN KEY([Parent_comment_id])
REFERENCES [dbo].[Comments] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Comments_Parent_comment_id]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Products_ProductId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users_User_id] FOREIGN KEY([User_id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users_User_id]
GO
ALTER TABLE [dbo].[ImageProduct]  WITH CHECK ADD  CONSTRAINT [FK_ImageProduct_Images_ImagesId] FOREIGN KEY([ImagesId])
REFERENCES [dbo].[Images] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImageProduct] CHECK CONSTRAINT [FK_ImageProduct_Images_ImagesId]
GO
ALTER TABLE [dbo].[ImageProduct]  WITH CHECK ADD  CONSTRAINT [FK_ImageProduct_Products_ProductsId] FOREIGN KEY([ProductsId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImageProduct] CHECK CONSTRAINT [FK_ImageProduct_Products_ProductsId]
GO
ALTER TABLE [dbo].[Prices]  WITH CHECK ADD  CONSTRAINT [FK_Prices_Products_Product_id] FOREIGN KEY([Product_id])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Prices] CHECK CONSTRAINT [FK_Prices_Products_Product_id]
GO
ALTER TABLE [dbo].[ProductsCarts]  WITH CHECK ADD  CONSTRAINT [FK_ProductsCarts_Carts_Cart_id] FOREIGN KEY([Cart_id])
REFERENCES [dbo].[Carts] ([Id])
GO
ALTER TABLE [dbo].[ProductsCarts] CHECK CONSTRAINT [FK_ProductsCarts_Carts_Cart_id]
GO
ALTER TABLE [dbo].[ProductsCarts]  WITH CHECK ADD  CONSTRAINT [FK_ProductsCarts_Products_Product_id] FOREIGN KEY([Product_id])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ProductsCarts] CHECK CONSTRAINT [FK_ProductsCarts_Products_Product_id]
GO
ALTER TABLE [dbo].[ProductSpecifications]  WITH CHECK ADD  CONSTRAINT [FK_ProductSpecifications_AvailableDatas_AvailableData_id] FOREIGN KEY([AvailableData_id])
REFERENCES [dbo].[AvailableDatas] ([Id])
GO
ALTER TABLE [dbo].[ProductSpecifications] CHECK CONSTRAINT [FK_ProductSpecifications_AvailableDatas_AvailableData_id]
GO
ALTER TABLE [dbo].[ProductSpecifications]  WITH CHECK ADD  CONSTRAINT [FK_ProductSpecifications_Products_Product_id] FOREIGN KEY([Product_id])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductSpecifications] CHECK CONSTRAINT [FK_ProductSpecifications_Products_Product_id]
GO
ALTER TABLE [dbo].[ProductSpecifications]  WITH CHECK ADD  CONSTRAINT [FK_ProductSpecifications_Specification_Specification_id] FOREIGN KEY([Specification_id])
REFERENCES [dbo].[Specification] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductSpecifications] CHECK CONSTRAINT [FK_ProductSpecifications_Specification_Specification_id]
GO
ALTER TABLE [dbo].[UserUseCase]  WITH CHECK ADD  CONSTRAINT [FK_UserUseCase_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserUseCase] CHECK CONSTRAINT [FK_UserUseCase_Users_UserId]
GO
