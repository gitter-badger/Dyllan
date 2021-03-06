USE [Douban]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TraceDetails_TraceChange]') AND parent_object_id = OBJECT_ID(N'[dbo].[TraceDetails]'))
ALTER TABLE [dbo].[TraceDetails] DROP CONSTRAINT [FK_TraceDetails_TraceChange]
GO
/****** Object:  Index [IX_TraceDetails]    Script Date: 6/18/2016 09:14:45 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TraceDetails]') AND name = N'IX_TraceDetails')
DROP INDEX [IX_TraceDetails] ON [dbo].[TraceDetails]
GO
/****** Object:  Table [dbo].[TraceDetails]    Script Date: 6/18/2016 09:14:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TraceDetails]') AND type in (N'U'))
DROP TABLE [dbo].[TraceDetails]
GO
/****** Object:  Table [dbo].[TraceChange]    Script Date: 6/18/2016 09:14:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TraceChange]') AND type in (N'U'))
DROP TABLE [dbo].[TraceChange]
GO
/****** Object:  Table [dbo].[BookInfo]    Script Date: 6/18/2016 09:14:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BookInfo]') AND type in (N'U'))
DROP TABLE [dbo].[BookInfo]
GO
/****** Object:  StoredProcedure [dbo].[ProcInsertOrUpdateBookInfos]    Script Date: 6/18/2016 09:14:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProcInsertOrUpdateBookInfos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ProcInsertOrUpdateBookInfos]
GO
/****** Object:  StoredProcedure [dbo].[ProcGetMaxDownloadedNumer]    Script Date: 6/18/2016 09:14:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProcGetMaxDownloadedNumer]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ProcGetMaxDownloadedNumer]
GO
/****** Object:  UserDefinedTableType [dbo].[BookInfoType]    Script Date: 6/18/2016 09:14:45 ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'BookInfoType' AND ss.name = N'dbo')
DROP TYPE [dbo].[BookInfoType]
GO
USE [master]
GO
/****** Object:  Database [Douban]    Script Date: 6/18/2016 09:14:45 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'Douban')
DROP DATABASE [Douban]
GO
/****** Object:  Database [Douban]    Script Date: 6/18/2016 09:14:45 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'Douban')
BEGIN
CREATE DATABASE [Douban]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Douban', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Douban.mdf' , SIZE = 8602624KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Douban_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Douban_log.ldf' , SIZE = 2160960KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
END

GO
ALTER DATABASE [Douban] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Douban].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Douban] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Douban] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Douban] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Douban] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Douban] SET ARITHABORT OFF 
GO
ALTER DATABASE [Douban] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Douban] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Douban] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Douban] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Douban] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Douban] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Douban] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Douban] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Douban] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Douban] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Douban] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Douban] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Douban] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Douban] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Douban] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Douban] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Douban] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Douban] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Douban] SET RECOVERY FULL 
GO
ALTER DATABASE [Douban] SET  MULTI_USER 
GO
ALTER DATABASE [Douban] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Douban] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Douban] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Douban] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Douban', N'ON'
GO
USE [Douban]
GO
/****** Object:  UserDefinedTableType [dbo].[BookInfoType]    Script Date: 6/18/2016 09:14:45 ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'BookInfoType' AND ss.name = N'dbo')
CREATE TYPE [dbo].[BookInfoType] AS TABLE(
	[ID] [uniqueidentifier] NOT NULL,
	[WebUrl] [nvarchar](200) NOT NULL,
	[UrlNumber] [int] NOT NULL,
	[BookName] [nvarchar](500) NULL,
	[Author] [nvarchar](max) NULL,
	[Publisher] [nvarchar](500) NULL,
	[PublishDate] [nvarchar](500) NULL,
	[PageNum] [nvarchar](50) NULL,
	[Price] [nvarchar](50) NULL,
	[ISBN] [nvarchar](50) NULL,
	[AverageScore] [float] NULL,
	[RatingNum] [int] NULL,
	[FiveStar] [float] NULL,
	[FourStar] [float] NULL,
	[ThreeStar] [float] NULL,
	[TwoStar] [float] NULL,
	[OneStar] [float] NULL,
	[ContentDescription] [nvarchar](max) NULL,
	[AuthorDescription] [nvarchar](max) NULL,
	[Tags] [nvarchar](max) NULL,
	[HttpStatus] [nvarchar](500) NULL
)
GO
/****** Object:  StoredProcedure [dbo].[ProcGetMaxDownloadedNumer]    Script Date: 6/18/2016 09:14:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProcGetMaxDownloadedNumer]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[ProcGetMaxDownloadedNumer]
AS
BEGIN
	SELECT MAX(URLNumber) FROM BookInfo
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ProcInsertOrUpdateBookInfos]    Script Date: 6/18/2016 09:14:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProcInsertOrUpdateBookInfos]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ProcInsertOrUpdateBookInfos]
(@BookInfos AS dbo.[BookInfoType] READONLY)
AS
BEGIN

	--UPDATE [dbo].[BookInfo]
	--SET
	--	[BookName] = T.BookName,
	--	[Author] = T.Author,
	--	[Publisher] = T.Publisher,
	--	[PublishDate] = T.PublishDate,
	--	[PageNum] = T.PageNum,
	--	[Price] = T.Price,
	--	[ISBN] = T.ISBN,
	--	[AverageScore] = T.AverageScore,
	--	[RatingNum] = T.RatingNum,
	--	[FiveStar] = T.FiveStar,
	--	[FourStar] = T.FourStar,
	--	[ThreeStar] = T.ThreeStar,
	--	[TwoStar] = T.TwoStar,
	--	[OneStar] = T.OneStar,
	--	[ContentDescription] = T.ContentDescription,
	--	[AuthorDescription] = T.AuthorDescription,
	--	[Tags] = T.Tags,
	--	[HttpStatus] = T.HttpStatus,
	--	[UpdateTime] = GETDATE()
	--FROM [BookInfo] AS B INNER JOIN @BookInfos AS T ON B.URLNumber = T.URLNumber AND B.[HttpStatus] <> ''OK''

	INSERT INTO [dbo].[BookInfo]
		([ID]
		,[WebUrl]
		,[BookName]
		,URLNumber
		,[Author]
		,[Publisher]
		,[PublishDate]
		,[PageNum]
		,[Price]
		,[ISBN]
		,[AverageScore]
		,[RatingNum]
		,[FiveStar]
		,[FourStar]
		,[ThreeStar]
		,[TwoStar]
		,[OneStar]
		,[ContentDescription]
		,[AuthorDescription]
		,[Tags]
		,[HttpStatus]
		,[CreateTime]
		,[UpdateTime])
	SELECT t.[ID] ,t.[WebUrl] ,t.[BookName], t.[UrlNumber], t.[Author] ,t.[Publisher] ,t.[PublishDate]
		,t.[PageNum] ,t.[Price] ,t.[ISBN] ,t.[AverageScore] ,t.[RatingNum] ,t.[FiveStar]
		,t.[FourStar] ,t.[ThreeStar] ,t.[TwoStar] ,t.[OneStar] ,t.[ContentDescription]
		,t.[AuthorDescription] ,t.[Tags] ,t.[HttpStatus] ,GETDATE() ,GETDATE()
	FROM @BookInfos t
	LEFT JOIN [BookInfo] b on t.URLNumber = b.URLNumber WHERE b.URLNumber IS NULL

END

' 
END
GO
/****** Object:  Table [dbo].[BookInfo]    Script Date: 6/18/2016 09:14:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BookInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BookInfo](
	[ID] [uniqueidentifier] NOT NULL,
	[WebUrl] [nvarchar](200) NOT NULL,
	[URLNumber] [int] NOT NULL,
	[BookName] [nvarchar](500) NULL,
	[Author] [nvarchar](max) NULL,
	[Publisher] [nvarchar](500) NULL,
	[PublishDate] [nvarchar](500) NULL,
	[PageNum] [nvarchar](50) NULL,
	[Price] [nvarchar](50) NULL,
	[ISBN] [nvarchar](50) NULL,
	[AverageScore] [float] NULL,
	[RatingNum] [int] NULL,
	[FiveStar] [float] NULL,
	[FourStar] [float] NULL,
	[ThreeStar] [float] NULL,
	[TwoStar] [float] NULL,
	[OneStar] [float] NULL,
	[ContentDescription] [nvarchar](max) NULL,
	[AuthorDescription] [nvarchar](max) NULL,
	[Tags] [nvarchar](max) NULL,
	[HttpStatus] [nvarchar](500) NULL,
	[CreateTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_BookInfo] PRIMARY KEY CLUSTERED 
(
	[URLNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TraceChange]    Script Date: 6/18/2016 09:14:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TraceChange]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TraceChange](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_TraceChange] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TraceDetails]    Script Date: 6/18/2016 09:14:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TraceDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TraceDetails](
	[ID] [int] NOT NULL,
	[PID] [int] NOT NULL,
	[TableName] [nvarchar](50) NOT NULL,
	[ColumnName] [nvarchar](50) NOT NULL,
	[OldValue] [nvarchar](500) NOT NULL,
	[NewValue] [nvarchar](500) NULL,
	[LastUpdateTime] [datetime] NULL,
 CONSTRAINT [PK_TraceDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Index [IX_TraceDetails]    Script Date: 6/18/2016 09:14:45 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TraceDetails]') AND name = N'IX_TraceDetails')
CREATE NONCLUSTERED INDEX [IX_TraceDetails] ON [dbo].[TraceDetails]
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TraceDetails_TraceChange]') AND parent_object_id = OBJECT_ID(N'[dbo].[TraceDetails]'))
ALTER TABLE [dbo].[TraceDetails]  WITH CHECK ADD  CONSTRAINT [FK_TraceDetails_TraceChange] FOREIGN KEY([PID])
REFERENCES [dbo].[TraceChange] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TraceDetails_TraceChange]') AND parent_object_id = OBJECT_ID(N'[dbo].[TraceDetails]'))
ALTER TABLE [dbo].[TraceDetails] CHECK CONSTRAINT [FK_TraceDetails_TraceChange]
GO
USE [master]
GO
ALTER DATABASE [Douban] SET  READ_WRITE 
GO
