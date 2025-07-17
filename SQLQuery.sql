USE [master]
GO
/****** Object:  Database [PizzaOrderingSystem]    Script Date: 7/17/2025 2:11:46 PM ******/
CREATE DATABASE [PizzaOrderingSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PizzaOrderingSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\PizzaOrderingSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PizzaOrderingSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\PizzaOrderingSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PizzaOrderingSystem] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PizzaOrderingSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PizzaOrderingSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PizzaOrderingSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PizzaOrderingSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PizzaOrderingSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PizzaOrderingSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [PizzaOrderingSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PizzaOrderingSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PizzaOrderingSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PizzaOrderingSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PizzaOrderingSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PizzaOrderingSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PizzaOrderingSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PizzaOrderingSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PizzaOrderingSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PizzaOrderingSystem] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PizzaOrderingSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PizzaOrderingSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PizzaOrderingSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PizzaOrderingSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PizzaOrderingSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PizzaOrderingSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PizzaOrderingSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PizzaOrderingSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [PizzaOrderingSystem] SET  MULTI_USER 
GO
ALTER DATABASE [PizzaOrderingSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PizzaOrderingSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PizzaOrderingSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PizzaOrderingSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PizzaOrderingSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PizzaOrderingSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PizzaOrderingSystem', N'ON'
GO
ALTER DATABASE [PizzaOrderingSystem] SET QUERY_STORE = ON
GO
ALTER DATABASE [PizzaOrderingSystem] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PizzaOrderingSystem]
GO
/****** Object:  User [msdba]    Script Date: 7/17/2025 2:11:46 PM ******/
CREATE USER [msdba] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 7/17/2025 2:11:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[AdminId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[AdminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 7/17/2025 2:11:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[FName] [nvarchar](50) NULL,
	[LName] [nvarchar](50) NULL,
	[Address] [nvarchar](100) NULL,
	[PhoneNo] [nvarchar](20) NULL,
	[City] [nvarchar](20) NULL,
	[Email] [nvarchar](20) NULL,
	[PassWord] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 7/17/2025 2:11:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[PassWord] [nvarchar](100) NULL,
	[FName] [nvarchar](20) NULL,
	[LName] [nvarchar](20) NULL,
	[Address] [nvarchar](50) NULL,
	[PhoneNo] [nvarchar](20) NULL,
	[Email] [nvarchar](20) NULL,
	[city] [nvarchar](20) NULL,
	[BranchCode] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 7/17/2025 2:11:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[EmployeeID] [int] NULL,
	[PizzaID] [int] NULL,
	[OrderStatus] [nvarchar](50) NULL,
	[TotalPrice] [decimal](10, 2) NULL,
	[DeliveryDateTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pizza]    Script Date: 7/17/2025 2:11:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pizza](
	[PizzaID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[ImageURL] [nvarchar](100) NULL,
	[Category] [nvarchar](50) NULL,
	[SmallPrice] [int] NULL,
	[MediumPrice] [int] NULL,
	[LargePrice] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PizzaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Toppings]    Script Date: 7/17/2025 2:11:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Toppings](
	[ToppingID] [int] IDENTITY(1,1) NOT NULL,
	[SmallPrice] [int] NULL,
	[MediumPrice] [int] NULL,
	[LargePrice] [int] NULL,
	[ToppingName] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ToppingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admins] ON 

INSERT [dbo].[Admins] ([AdminId], [Email], [Password]) VALUES (1, N'Malik@gmail.com', N'admin@123')
SET IDENTITY_INSERT [dbo].[Admins] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerID], [FName], [LName], [Address], [PhoneNo], [City], [Email], [PassWord]) VALUES (5, N'chuka', N'thukla', N'fukla', N'1234567890', N'sordondu', N'khaman@gmail.com', N'string')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeID], [UserName], [PassWord], [FName], [LName], [Address], [PhoneNo], [Email], [city], [BranchCode]) VALUES (1, N'prithvi', N'lasan', N'prithvi', N'raj', N'BR001', N'1234567890', N'pr@gmail.com', NULL, N'BR001')
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Pizza] ON 

INSERT [dbo].[Pizza] ([PizzaID], [Name], [ImageURL], [Category], [SmallPrice], [MediumPrice], [LargePrice]) VALUES (1, N'Margaritta', N'https://shorturl.at/VCiU6', N'Italian', 100, 200, 300)
SET IDENTITY_INSERT [dbo].[Pizza] OFF
GO
SET IDENTITY_INSERT [dbo].[Toppings] ON 

INSERT [dbo].[Toppings] ([ToppingID], [SmallPrice], [MediumPrice], [LargePrice], [ToppingName]) VALUES (1, 100, 200, 300, N'cheese')
SET IDENTITY_INSERT [dbo].[Toppings] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Admins__A9D10534A482DB9A]    Script Date: 7/17/2025 2:11:47 PM ******/
ALTER TABLE [dbo].[Admins] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Customer__A9D105345861765A]    Script Date: 7/17/2025 2:11:47 PM ******/
ALTER TABLE [dbo].[Customer] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Employee__C9F284566BFD0507]    Script Date: 7/17/2025 2:11:47 PM ******/
ALTER TABLE [dbo].[Employee] ADD UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([PizzaID])
REFERENCES [dbo].[Pizza] ([PizzaID])
GO
USE [master]
GO
ALTER DATABASE [PizzaOrderingSystem] SET  READ_WRITE 
GO
