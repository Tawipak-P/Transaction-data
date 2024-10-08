USE [TransactionDB]
GO
/****** Object:  StoredProcedure [dbo].[SP_SearchTransaction]    Script Date: 9/29/2024 5:30:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		TawipakP
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_SearchTransaction]
	

	@CurrencyCode varchar(3),
	@DateFrom date,
	@DateTo date,
	@Status varchar(10),
	@PageSize int,
	@PageNumber int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
	SELECT 
		COUNT(*) OVER () AS TotalRecords,
		t.TransactionId AS Id,
		CONVERT(varchar, t.Amount) + ' ' + t.CurrencyCode AS Payment,
		s.Prefix AS Status
	FROM [dbo].[TD_Transactions] t
	LEFT JOIN [dbo].[TD_Statuses] s on t.Status = s.Name

	WHERE 1 = 1
		AND
			(@CurrencyCode IS NULL OR CurrencyCode = @CurrencyCode)
		AND
			(@DateFrom IS NULL OR TransactionDate >= CONVERT(datetime, @DateFrom, 126))
		AND
			(@DateTo IS NULL OR TransactionDate <= CONVERT(datetime, @DateTo, 126))
		AND
			(@Status IS NULL OR Status = @Status)


	ORDER BY Id
	--OFFSET (@PageSize * (@PageNumber - 1)) ROWS
	--FETCH NEXT @PageSize ROWS ONLY;
	
END
