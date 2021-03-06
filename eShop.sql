USE [master]
GO
/****** Object:  Database [eShop]    Script Date: 8/12/2018 1:44:47 AM ******/
CREATE DATABASE [eShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'eTender', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\eTender.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'eTender_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\eTender_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [eShop] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [eShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [eShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [eShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [eShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [eShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [eShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [eShop] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [eShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [eShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [eShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [eShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [eShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [eShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [eShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [eShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [eShop] SET  ENABLE_BROKER 
GO
ALTER DATABASE [eShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [eShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [eShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [eShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [eShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [eShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [eShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [eShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [eShop] SET  MULTI_USER 
GO
ALTER DATABASE [eShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [eShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [eShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [eShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [eShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [eShop] SET QUERY_STORE = OFF
GO
USE [eShop]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [eShop]
GO
/****** Object:  Table [dbo].[Bids]    Script Date: 8/12/2018 1:44:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bids](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[productid] [int] NULL,
	[buyerid] [int] NULL,
	[price] [decimal](18, 0) NULL,
	[date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Buyer]    Script Date: 8/12/2018 1:44:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buyer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NULL,
	[email] [varchar](100) NULL,
	[password] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contract]    Script Date: 8/12/2018 1:44:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[productId] [int] NULL,
	[bidid] [int] NULL,
	[price] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 8/12/2018 1:44:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](100) NULL,
	[description] [varchar](100) NULL,
	[price] [decimal](18, 0) NULL,
	[publishdate] [datetime] NULL,
	[lastdate] [datetime] NULL,
	[sellerid] [int] NULL,
	[Image] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Seller]    Script Date: 8/12/2018 1:44:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seller](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NULL,
	[License] [varchar](100) NULL,
	[email] [varchar](100) NULL,
	[password] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Buyer] ON 

INSERT [dbo].[Buyer] ([id], [name], [email], [password]) VALUES (1, N'Rain', N'rain@email.com', N'fagun')
INSERT [dbo].[Buyer] ([id], [name], [email], [password]) VALUES (2, N'c1', N'c1@email.com', N'fagun')
INSERT [dbo].[Buyer] ([id], [name], [email], [password]) VALUES (3, N'c1', N'c1@email.com', N'fagun')
INSERT [dbo].[Buyer] ([id], [name], [email], [password]) VALUES (4, N'c2', N'c2@email.com', N'fagun')
SET IDENTITY_INSERT [dbo].[Buyer] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([id], [title], [description], [price], [publishdate], [lastdate], [sellerid], [Image]) VALUES (3, N'Male t-shirt', N'Black mail t-shirt', CAST(15 AS Decimal(18, 0)), CAST(N'2017-06-30T11:45:50.000' AS DateTime), CAST(N'2017-06-30T00:00:00.000' AS DateTime), 2, N'636344199500738660male.png')
INSERT [dbo].[Product] ([id], [title], [description], [price], [publishdate], [lastdate], [sellerid], [Image]) VALUES (4, N'Female t-shirt', N'Black female t-shirt', CAST(10 AS Decimal(18, 0)), CAST(N'2017-07-01T23:42:32.000' AS DateTime), CAST(N'2017-07-02T00:00:00.000' AS DateTime), 2, N'636345493529428910female.png')
INSERT [dbo].[Product] ([id], [title], [description], [price], [publishdate], [lastdate], [sellerid], [Image]) VALUES (5, N'sample', N'sample', CAST(1 AS Decimal(18, 0)), CAST(N'1894-05-13T00:00:00.000' AS DateTime), CAST(N'1894-07-01T00:00:00.000' AS DateTime), 2, N'')
INSERT [dbo].[Product] ([id], [title], [description], [price], [publishdate], [lastdate], [sellerid], [Image]) VALUES (6, N'sam', N'www', CAST(2 AS Decimal(18, 0)), CAST(N'1894-05-13T00:00:00.000' AS DateTime), CAST(N'1894-07-04T00:00:00.000' AS DateTime), 2, N'')
INSERT [dbo].[Product] ([id], [title], [description], [price], [publishdate], [lastdate], [sellerid], [Image]) VALUES (7, N'sss', N'kkk', CAST(1 AS Decimal(18, 0)), CAST(N'2017-07-04T00:50:12.000' AS DateTime), CAST(N'2017-07-10T00:00:00.000' AS DateTime), 2, N'636347262121892698male.png')
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Seller] ON 

INSERT [dbo].[Seller] ([id], [name], [License], [email], [password]) VALUES (1, N'System.Web.UI.WebControls.TextBox', N'System.Web.UI.WebControls.TextBox', N'System.Web.UI.WebControls.TextBox', N'System.Web.UI.WebControls.TextBox')
INSERT [dbo].[Seller] ([id], [name], [License], [email], [password]) VALUES (2, N'Fagun', N'120120120', N'email@email.com', N'fagun')
INSERT [dbo].[Seller] ([id], [name], [License], [email], [password]) VALUES (3, N'Tender Host 2', N't21010', N't2@email.com', N'fagun')
INSERT [dbo].[Seller] ([id], [name], [License], [email], [password]) VALUES (4, N'Host 2', N't21010', N'h2@email.com', N'fagun')
SET IDENTITY_INSERT [dbo].[Seller] OFF
USE [master]
GO
ALTER DATABASE [eShop] SET  READ_WRITE 
GO
