USE [Temp_TransactionDB]
GO

/****** Object:  UserDefinedTableType [dbo].[TransactionTableType]    Script Date: 9/29/2024 5:30:10 PM ******/
CREATE TYPE [dbo].[TransactionTableType] AS TABLE(
	[TransactionId] [nvarchar](50) NULL,
	[AccountNo] [nvarchar](30) NULL,
	[Amount] [decimal](18, 2) NULL,
	[CurrencyCode] [varchar](3) NULL,
	[TransactionDate] [datetime] NULL,
	[Status] [varchar](10) NULL
)
GO


