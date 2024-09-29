USE [TransactionDB]
GO

/****** Object:  Table [dbo].[TD_Transactions]    Script Date: 9/29/2024 5:31:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TD_Transactions](
	[TransactionId] [nvarchar](50) NOT NULL,
	[AccountNo] [nvarchar](30) NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[CurrencyCode] [nvarchar](3) NULL,
	[TransactionDate] [datetime2](7) NOT NULL,
	[Status] [nvarchar](10) NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_TD_Transactions] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TD_Transactions] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreateDate]
GO


