CREATE TYPE dbo.TransactionTableType AS TABLE
(
    TransactionId nvarchar(50),
    AccountNo nvarchar(30),
    Amount decimal(18,2),
    CurrencyCode varchar(3),
    TransactionDate datetime,
    Status varchar(10)
);