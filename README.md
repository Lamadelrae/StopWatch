# StopWatch
StopWatch Program with Dapper and SQL Server



Table: 

```
USE [StopWatch]
GO

/****** Object:  Table [dbo].[StopWatch]    Script Date: 12/2/2021 5:36:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StopWatch](
	[Id] [uniqueidentifier] NOT NULL,
	[Start] [time](7) NULL,
	[Stop] [time](7) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[StopWatch] ADD  DEFAULT (newid()) FOR [Id]
GO

```
