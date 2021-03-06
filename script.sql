USE [master]
GO
/****** Object:  Database [StockManagementSystemBatch50]    Script Date: 8/2/2018 5:09:24 AM ******/
CREATE DATABASE [StockManagementSystemBatch50]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StockManagementSystemBatch50', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\StockManagementSystemBatch50.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'StockManagementSystemBatch50_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\StockManagementSystemBatch50_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [StockManagementSystemBatch50] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StockManagementSystemBatch50].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StockManagementSystemBatch50] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StockManagementSystemBatch50] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StockManagementSystemBatch50] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StockManagementSystemBatch50] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StockManagementSystemBatch50] SET ARITHABORT OFF 
GO
ALTER DATABASE [StockManagementSystemBatch50] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [StockManagementSystemBatch50] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [StockManagementSystemBatch50] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StockManagementSystemBatch50] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StockManagementSystemBatch50] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StockManagementSystemBatch50] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StockManagementSystemBatch50] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StockManagementSystemBatch50] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StockManagementSystemBatch50] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StockManagementSystemBatch50] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StockManagementSystemBatch50] SET  ENABLE_BROKER 
GO
ALTER DATABASE [StockManagementSystemBatch50] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StockManagementSystemBatch50] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StockManagementSystemBatch50] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StockManagementSystemBatch50] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StockManagementSystemBatch50] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StockManagementSystemBatch50] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StockManagementSystemBatch50] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StockManagementSystemBatch50] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StockManagementSystemBatch50] SET  MULTI_USER 
GO
ALTER DATABASE [StockManagementSystemBatch50] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StockManagementSystemBatch50] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StockManagementSystemBatch50] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StockManagementSystemBatch50] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [StockManagementSystemBatch50]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 8/2/2018 5:09:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Companies]    Script Date: 8/2/2018 5:09:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ItemAvailableQuantity]    Script Date: 8/2/2018 5:09:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemAvailableQuantity](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ItemId] [bigint] NOT NULL,
	[AvailableQuantity] [int] NOT NULL,
 CONSTRAINT [PK_ItemAvailableStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Items]    Script Date: 8/2/2018 5:09:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CategoryId] [bigint] NOT NULL,
	[CompanyId] [bigint] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[ReorderLabel] [int] NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Login]    Script Date: 8/2/2018 5:09:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StockIn]    Script Date: 8/2/2018 5:09:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockIn](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyId] [bigint] NOT NULL,
	[CategoryId] [bigint] NOT NULL,
	[ItemId] [bigint] NOT NULL,
	[AvailableQuantity] [int] NOT NULL,
 CONSTRAINT [PK_StockIn] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StockOut]    Script Date: 8/2/2018 5:09:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockOut](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyId] [bigint] NOT NULL,
	[CategoryId] [bigint] NOT NULL,
	[ItemId] [bigint] NOT NULL,
	[StockOutQuantity] [int] NOT NULL,
	[StockOutDate] [date] NOT NULL,
	[StockOutType] [int] NOT NULL,
 CONSTRAINT [PK_StockOut] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Electronics')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Stationary')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Companies] ON 

INSERT [dbo].[Companies] ([Id], [Name]) VALUES (1, N'Bashundhara Group')
INSERT [dbo].[Companies] ([Id], [Name]) VALUES (2, N'Samsung')
SET IDENTITY_INSERT [dbo].[Companies] OFF
SET IDENTITY_INSERT [dbo].[ItemAvailableQuantity] ON 

INSERT [dbo].[ItemAvailableQuantity] ([Id], [ItemId], [AvailableQuantity]) VALUES (1, 2, 10)
SET IDENTITY_INSERT [dbo].[ItemAvailableQuantity] OFF
SET IDENTITY_INSERT [dbo].[Items] ON 

INSERT [dbo].[Items] ([Id], [CategoryId], [CompanyId], [Name], [ReorderLabel]) VALUES (1, 1, 1, N'Paper', 10)
INSERT [dbo].[Items] ([Id], [CategoryId], [CompanyId], [Name], [ReorderLabel]) VALUES (2, 1, 2, N'Smart Phone Model01', 5)
SET IDENTITY_INSERT [dbo].[Items] OFF
SET IDENTITY_INSERT [dbo].[Login] ON 

INSERT [dbo].[Login] ([Id], [Username], [Password]) VALUES (1, N'admin', N'123')
SET IDENTITY_INSERT [dbo].[Login] OFF
SET IDENTITY_INSERT [dbo].[StockIn] ON 

INSERT [dbo].[StockIn] ([Id], [CompanyId], [CategoryId], [ItemId], [AvailableQuantity]) VALUES (1, 2, 1, 2, 10)
SET IDENTITY_INSERT [dbo].[StockIn] OFF
ALTER TABLE [dbo].[ItemAvailableQuantity]  WITH CHECK ADD  CONSTRAINT [FK_ItemAvailableQuantity_Items] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([Id])
GO
ALTER TABLE [dbo].[ItemAvailableQuantity] CHECK CONSTRAINT [FK_ItemAvailableQuantity_Items]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Categories]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Companies] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Companies]
GO
ALTER TABLE [dbo].[StockIn]  WITH CHECK ADD  CONSTRAINT [FK_StockIn_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[StockIn] CHECK CONSTRAINT [FK_StockIn_Categories]
GO
ALTER TABLE [dbo].[StockIn]  WITH CHECK ADD  CONSTRAINT [FK_StockIn_Companies] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
ALTER TABLE [dbo].[StockIn] CHECK CONSTRAINT [FK_StockIn_Companies]
GO
ALTER TABLE [dbo].[StockIn]  WITH CHECK ADD  CONSTRAINT [FK_StockIn_Items] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([Id])
GO
ALTER TABLE [dbo].[StockIn] CHECK CONSTRAINT [FK_StockIn_Items]
GO
ALTER TABLE [dbo].[StockOut]  WITH CHECK ADD  CONSTRAINT [FK_StockOut_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[StockOut] CHECK CONSTRAINT [FK_StockOut_Categories]
GO
ALTER TABLE [dbo].[StockOut]  WITH CHECK ADD  CONSTRAINT [FK_StockOut_Companies] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
ALTER TABLE [dbo].[StockOut] CHECK CONSTRAINT [FK_StockOut_Companies]
GO
ALTER TABLE [dbo].[StockOut]  WITH CHECK ADD  CONSTRAINT [FK_StockOut_Items] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([Id])
GO
ALTER TABLE [dbo].[StockOut] CHECK CONSTRAINT [FK_StockOut_Items]
GO
USE [master]
GO
ALTER DATABASE [StockManagementSystemBatch50] SET  READ_WRITE 
GO
