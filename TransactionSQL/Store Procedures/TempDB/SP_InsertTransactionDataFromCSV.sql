USE [Temp_TransactionDB]
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertTransactionDataFromCSV]    Script Date: 9/29/2024 5:28:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		TawipakP
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

--CREATE TYPE dbo.TransactionTableType AS TABLE
--(
--    TransactionId nvarchar(50),
--    AccountNo nvarchar(30),
--    Amount decimal(18,2),
--	CurrencyCode varchar(3),
--	TransactionDate datetime,
--	Status varchar(10)
--);

ALTER PROCEDURE [dbo].[SP_InsertTransactionDataFromCSV]
	-- Add the parameters for the stored procedure here
	@DataTable dbo.TransactionTableType  READONLY
AS 

BEGIN

	DECLARE @IsSuccess bit = 0;

	BEGIN TRY
		BEGIN TRANSACTION;
			SET NOCOUNT ON;

			DECLARE @TransactionId nvarchar(50), @AccountNo nvarchar(30), @Amount decimal(18,2), @CurrencyCode varchar(3), @TransactionDate datetime, @Status varchar(10);

			--Loop data through cursor
			DECLARE cur CURSOR FOR
			SELECT TransactionId, AccountNo, Amount, CurrencyCode, TransactionDate, Status 
			FROM @DataTable

			--Open cursor
			OPEN cur

			--Fetch next row form cursor
			FETCH NEXT FROM cur INTO @TransactionId, @AccountNo, @Amount, @CurrencyCode, @TransactionDate, @Status

			WHILE @@FETCH_STATUS = 0
			BEGIN

				MERGE INTO [dbo].[TM_Transactions] AS Destination
				USING(SELECT @TransactionId AS TransactionId, @AccountNo AS AccountNo, @Amount AS Amount, @CurrencyCode AS CurrencyCode, @TransactionDate AS TransactionDate, @Status AS Status) AS Source
				ON Destination.TransactionId = Source.TransactionId
				WHEN MATCHED THEN
					UPDATE  SET 
					AccountNo = Source.AccountNo,
					Amount = Source.Amount, 
					CurrencyCode = Source.CurrencyCode, 
					TransactionDate = Source.TransactionDate, 
					Status = Source.Status,
					ModifiedDate = GETDATE(),
					TimeStamp  = GETDATE(),
					Action = 2
				WHEN NOT MATCHED BY TARGET THEN
					INSERT (TransactionId, AccountNo, Amount, CurrencyCode, TransactionDate, Status, ModifiedDate, TimeStamp, Action, IsTransfer)
					VALUES (Source.TransactionId, Source.AccountNo, Source.Amount, Source.CurrencyCode, Source.TransactionDate, Source.Status, GETDATE(), GETDATE(), 1, 0);

				FETCH NEXT FROM cur INTO @TransactionId, @AccountNo, @Amount, @CurrencyCode, @TransactionDate, @Status;
				
			END;

			--Close cursor
			CLOSE cur;
			--Prepared data
			DEALLOCATE cur;

			SET @IsSuccess = 1;

		COMMIT TRANSACTION;

		--Return row count
		SELECT @IsSuccess AS IsSuccess;

	END TRY

	BEGIN CATCH
		IF @@TRANCOUNT > 0
		BEGIN 
			ROLLBACK TRANSACTION;
		END

		DECLARE @ErrorMessage NVARCHAR(4000);

		SELECT 
			@ErrorMessage = ERROR_MESSAGE()

			RAISERROR (@ErrorMessage, 16 ,1) WITH LOG;
	END CATCH

END
