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