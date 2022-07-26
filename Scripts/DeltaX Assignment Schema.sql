USE [master]
GO
/****** Object:  Database [Delta]    Script Date: 26-07-2022 11:41:50 ******/
CREATE DATABASE [Delta]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Delta', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS2014\MSSQL\DATA\Delta.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Delta_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS2014\MSSQL\DATA\Delta_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Delta] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Delta].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Delta] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Delta] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Delta] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Delta] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Delta] SET ARITHABORT OFF 
GO
ALTER DATABASE [Delta] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Delta] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Delta] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Delta] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Delta] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Delta] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Delta] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Delta] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Delta] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Delta] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Delta] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Delta] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Delta] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Delta] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Delta] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Delta] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Delta] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Delta] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Delta] SET  MULTI_USER 
GO
ALTER DATABASE [Delta] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Delta] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Delta] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Delta] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Delta] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Delta]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 26-07-2022 11:41:51 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Actors]    Script Date: 26-07-2022 11:41:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actors](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](126) NOT NULL,
	[Bio] [nvarchar](620) NULL,
	[DateofBirth] [datetime2](7) NOT NULL,
	[Gender] [nvarchar](max) NOT NULL,
	[MovieId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Actors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 26-07-2022 11:41:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](126) NOT NULL,
	[Plot] [nvarchar](620) NULL,
	[DateofRelease] [datetime2](7) NOT NULL,
	[Poster] [nvarchar](max) NULL,
	[ProducerId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producers]    Script Date: 26-07-2022 11:41:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producers](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](126) NOT NULL,
	[Bio] [nvarchar](620) NULL,
	[DateofBirth] [datetime2](7) NOT NULL,
	[Company] [nvarchar](126) NOT NULL,
	[Gender] [nvarchar](26) NOT NULL,
 CONSTRAINT [PK_Producers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Actors_MovieId]    Script Date: 26-07-2022 11:41:51 ******/
CREATE NONCLUSTERED INDEX [IX_Actors_MovieId] ON [dbo].[Actors]
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Movies_ProducerId]    Script Date: 26-07-2022 11:41:51 ******/
CREATE NONCLUSTERED INDEX [IX_Movies_ProducerId] ON [dbo].[Movies]
(
	[ProducerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Actors]  WITH CHECK ADD  CONSTRAINT [FK_Actors_Movies_MovieId] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([Id])
GO
ALTER TABLE [dbo].[Actors] CHECK CONSTRAINT [FK_Actors_Movies_MovieId]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Producers_ProducerId] FOREIGN KEY([ProducerId])
REFERENCES [dbo].[Producers] ([Id])
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Producers_ProducerId]
GO
USE [master]
GO
ALTER DATABASE [Delta] SET  READ_WRITE 
GO
