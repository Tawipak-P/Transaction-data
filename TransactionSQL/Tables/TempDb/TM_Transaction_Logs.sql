USE [Temp_TransactionDB]
GO

/****** Object:  Table [dbo].[TM_Transaction_Logs]    Script Date: 9/29/2024 4:09:28 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TM_Transaction_Logs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionId] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](300) NULL,
	[LogDate] [datetime] NULL,
 CONSTRAINT [PK_TM_Transaction_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TM_Transaction_Logs] ADD  CONSTRAINT [DF_TM_Transaction_Logs_LogDate]  DEFAULT (getdate()) FOR [LogDate]
GO


