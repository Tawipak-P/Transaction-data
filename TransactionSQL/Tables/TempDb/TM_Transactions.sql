USE [Temp_TransactionDB]
GO

/****** Object:  Table [dbo].[TM_Transactions]    Script Date: 9/29/2024 4:10:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TM_Transactions](
	[TransactionId] [nvarchar](100) NOT NULL,
	[AccountNo] [nvarchar](100) NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[CurrencyCode] [nvarchar](30) NULL,
	[TransactionDate] [datetime2](7) NOT NULL,
	[Status] [nvarchar](30) NULL,
	[Remark] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[TimeStamp] [datetime2](7) NOT NULL,
	[Action] [int] NOT NULL,
	[IsTransfer] [bit] NOT NULL,
 CONSTRAINT [PK_TM_Transactions] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[TM_Transactions] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [ModifiedDate]
GO

ALTER TABLE [dbo].[TM_Transactions] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [TimeStamp]
GO

ALTER TABLE [dbo].[TM_Transactions] ADD  DEFAULT ((0)) FOR [Action]
GO

ALTER TABLE [dbo].[TM_Transactions] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsTransfer]
GO


