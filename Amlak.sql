USE [master]
GO
/****** Object:  Database [Makler]    Script Date: 19.04.2018 20:51:24 ******/
CREATE DATABASE [Makler]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Makler', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Makler.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Makler_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Makler_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Makler] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Makler].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Makler] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Makler] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Makler] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Makler] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Makler] SET ARITHABORT OFF 
GO
ALTER DATABASE [Makler] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Makler] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Makler] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Makler] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Makler] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Makler] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Makler] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Makler] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Makler] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Makler] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Makler] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Makler] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Makler] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Makler] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Makler] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Makler] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Makler] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Makler] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Makler] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Makler] SET  MULTI_USER 
GO
ALTER DATABASE [Makler] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Makler] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Makler] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Makler] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Makler]
GO
/****** Object:  Table [dbo].[Amlak]    Script Date: 19.04.2018 20:51:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Amlak](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NULL,
 CONSTRAINT [PK_Amlak] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Area]    Script Date: 19.04.2018 20:51:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[City] [nvarchar](50) NULL,
	[District] [nvarchar](50) NULL,
 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Elan]    Script Date: 19.04.2018 20:51:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Elan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Amlakid] [int] NULL,
	[Condition] [nvarchar](50) NULL,
	[Request] [nvarchar](50) NULL,
	[Areaid] [int] NULL,
	[Personalid] [int] NULL,
	[Client] [nvarchar](50) NULL,
	[C_Telefon] [int] NULL,
	[Price] [money] NULL,
	[Room] [int] NULL,
	[Note] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[DateIn] [date] NULL,
	[DateOut] [date] NULL,
	[Buyer] [nvarchar](50) NULL,
	[B_Telefon] [int] NULL,
 CONSTRAINT [PK_Elan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Personal]    Script Date: 19.04.2018 20:51:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Makler] [nvarchar](50) NULL,
	[Telefon] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_Personal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Amlak] ON 

INSERT [dbo].[Amlak] ([Id], [Type]) VALUES (1, N'Garaj')
INSERT [dbo].[Amlak] ([Id], [Type]) VALUES (2, N'Ev')
INSERT [dbo].[Amlak] ([Id], [Type]) VALUES (3, N'Torpaq')
INSERT [dbo].[Amlak] ([Id], [Type]) VALUES (4, N'Baq')
SET IDENTITY_INSERT [dbo].[Amlak] OFF
SET IDENTITY_INSERT [dbo].[Area] ON 

INSERT [dbo].[Area] ([Id], [City], [District]) VALUES (1, N'Bakı', N'Binəqədi')
INSERT [dbo].[Area] ([Id], [City], [District]) VALUES (2, N'Bakı', N'Qaradağ')
INSERT [dbo].[Area] ([Id], [City], [District]) VALUES (4, N'Bakı', N'Xəzər')
INSERT [dbo].[Area] ([Id], [City], [District]) VALUES (5, N'Bakı', N'Xətai')
INSERT [dbo].[Area] ([Id], [City], [District]) VALUES (6, N'Bakı', N'Nərimanov')
INSERT [dbo].[Area] ([Id], [City], [District]) VALUES (7, N'Bakı', N'Nəsimi')
INSERT [dbo].[Area] ([Id], [City], [District]) VALUES (8, N'Bakı', N'Nizami')
INSERT [dbo].[Area] ([Id], [City], [District]) VALUES (9, N'Bakı', N'Sabunçu')
INSERT [dbo].[Area] ([Id], [City], [District]) VALUES (10, N'Bakı', N'Səbail')
INSERT [dbo].[Area] ([Id], [City], [District]) VALUES (11, N'Bakı', N'Suraxanı')
INSERT [dbo].[Area] ([Id], [City], [District]) VALUES (12, N'Bakı', N'Yasamal')
INSERT [dbo].[Area] ([Id], [City], [District]) VALUES (13, N'Sumqayıt', N'şəhər')
INSERT [dbo].[Area] ([Id], [City], [District]) VALUES (14, N'Sumqayıt', N'Hacı Zeynalabdin')
INSERT [dbo].[Area] ([Id], [City], [District]) VALUES (15, N'Sumqayıt', N'Corat')
INSERT [dbo].[Area] ([Id], [City], [District]) VALUES (16, N'Qazax', N'Şəhər')
INSERT [dbo].[Area] ([Id], [City], [District]) VALUES (17, N'Qazax', N'Ağköynək kənd')
INSERT [dbo].[Area] ([Id], [City], [District]) VALUES (18, N'Qazax', N'Xanlıqlar kənd')
INSERT [dbo].[Area] ([Id], [City], [District]) VALUES (19, N'Qazax', N'Dəmirçilər kənd')
INSERT [dbo].[Area] ([Id], [City], [District]) VALUES (20, N'Qazax', N'Hüseynbəyli kənd')
SET IDENTITY_INSERT [dbo].[Area] OFF
SET IDENTITY_INSERT [dbo].[Elan] ON 

INSERT [dbo].[Elan] ([Id], [Amlakid], [Condition], [Request], [Areaid], [Personalid], [Client], [C_Telefon], [Price], [Room], [Note], [Status], [DateIn], [DateOut], [Buyer], [B_Telefon]) VALUES (1, 1, N'Yeni', N'Kirayə', 16, 2, N'Ilqar', 12345, 45.0000, 4, N'evroremont', N'Closed', CAST(0x143E0B00 AS Date), CAST(0x283E0B00 AS Date), N'mamed', 54321)
INSERT [dbo].[Elan] ([Id], [Amlakid], [Condition], [Request], [Areaid], [Personalid], [Client], [C_Telefon], [Price], [Room], [Note], [Status], [DateIn], [DateOut], [Buyer], [B_Telefon]) VALUES (2, 2, N'Yeni', N'Satılır', 15, 1, N'Shamil', 1, 45.0000, 4, N'mayak', N'Active', CAST(0x143E0B00 AS Date), CAST(0x283E0B00 AS Date), N'', 0)
INSERT [dbo].[Elan] ([Id], [Amlakid], [Condition], [Request], [Areaid], [Personalid], [Client], [C_Telefon], [Price], [Room], [Note], [Status], [DateIn], [DateOut], [Buyer], [B_Telefon]) VALUES (3, 4, N'Yeni', N'Satılır', 13, 2, N'Namiq', 123456, 1.5000, 4, N'Super', N'Active', CAST(0x143E0B00 AS Date), CAST(0x283E0B00 AS Date), N'', 0)
INSERT [dbo].[Elan] ([Id], [Amlakid], [Condition], [Request], [Areaid], [Personalid], [Client], [C_Telefon], [Price], [Room], [Note], [Status], [DateIn], [DateOut], [Buyer], [B_Telefon]) VALUES (4, 2, N'Yeni', N'Satılır', 1, 1, N'Zamiq', 131546, 15.0000, 4, N'Super', N'Closed', CAST(0x143E0B00 AS Date), CAST(0x283E0B00 AS Date), N'Fuad', 156)
INSERT [dbo].[Elan] ([Id], [Amlakid], [Condition], [Request], [Areaid], [Personalid], [Client], [C_Telefon], [Price], [Room], [Note], [Status], [DateIn], [DateOut], [Buyer], [B_Telefon]) VALUES (5, 4, N'Köhnə', N'Satılır', 13, 2, N'Nizami', 15656, 1.5000, 1, N'Super', N'Active', CAST(0x143E0B00 AS Date), CAST(0x283E0B00 AS Date), N'', 0)
SET IDENTITY_INSERT [dbo].[Elan] OFF
SET IDENTITY_INSERT [dbo].[Personal] ON 

INSERT [dbo].[Personal] ([Id], [Makler], [Telefon], [Status]) VALUES (1, N'Mamed Mamedov M', N'1234', N'YES')
INSERT [dbo].[Personal] ([Id], [Makler], [Telefon], [Status]) VALUES (2, N'Samed Samedov Y', N'4568', N'YES')
INSERT [dbo].[Personal] ([Id], [Makler], [Telefon], [Status]) VALUES (3, N'Fuad Ismayilov A', N'65897', N'NO')
INSERT [dbo].[Personal] ([Id], [Makler], [Telefon], [Status]) VALUES (4, N'Rahil Qarayev N', N'987654321', N'NO')
SET IDENTITY_INSERT [dbo].[Personal] OFF
ALTER TABLE [dbo].[Elan]  WITH CHECK ADD  CONSTRAINT [FK_Elan_Amlak] FOREIGN KEY([Amlakid])
REFERENCES [dbo].[Amlak] ([Id])
GO
ALTER TABLE [dbo].[Elan] CHECK CONSTRAINT [FK_Elan_Amlak]
GO
ALTER TABLE [dbo].[Elan]  WITH CHECK ADD  CONSTRAINT [FK_Elan_Area] FOREIGN KEY([Areaid])
REFERENCES [dbo].[Area] ([Id])
GO
ALTER TABLE [dbo].[Elan] CHECK CONSTRAINT [FK_Elan_Area]
GO
ALTER TABLE [dbo].[Elan]  WITH CHECK ADD  CONSTRAINT [FK_Elan_Personal] FOREIGN KEY([Personalid])
REFERENCES [dbo].[Personal] ([Id])
GO
ALTER TABLE [dbo].[Elan] CHECK CONSTRAINT [FK_Elan_Personal]
GO
USE [master]
GO
ALTER DATABASE [Makler] SET  READ_WRITE 
GO
