using Transaction.Infrastructor.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Xml.Linq;
using Transaction.Infrastructor.StoreProcedures;
using Microsoft.Extensions.Configuration;

namespace Transaction.Infrastructor.Repositories
{
    public class TempTransactionRepository : ITempTransactionRepository
    {
        private readonly TempTransactionDbContext _tempDbContext;
        private readonly IConfiguration _configuration;

        #region Constructor
        public TempTransactionRepository(TempTransactionDbContext tempDbContext, IConfiguration configuration)
        {
            _tempDbContext = tempDbContext;
            _configuration = configuration;
        }
        #endregion

        public async Task<bool> UploadTransactionWithSqlBlukCopyAsync(DataTable dataTable)
        {

            var connectionString = _configuration.GetConnectionString("TransactionDb");
            using(SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();

                
                using (SqlTransaction sqlTransaction = (SqlTransaction)await sqlConnection.BeginTransactionAsync())
                {
                    try
                    {
                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(sqlConnection, SqlBulkCopyOptions.Default, sqlTransaction))
                        {
                            sqlBulkCopy.DestinationTableName = "TM_Transactions";

                            try
                            {
                                await sqlBulkCopy.WriteToServerAsync(dataTable);


                                string mergeData = @"MERGE INTO TD_Transactions AS TargetTable
                                                USING TM_Transactions AS SourceTable
                                                ON TargetTable.TransactionId = SourceTable.TransactionId
                                                WHEN MATCHED THEN
                                                UPDATE SET 
                                                    TargetTable.AccountNo = SourceTable.AccountNo, 
                                                    TargetTable.Amount = SourceTable.Amount, 
                                                    TargetTable.CurrencyCode = SourceTable.CurrencyCode,
                                                    TargetTable.TransactionDate = SourceTable.TransactionDate,
                                                    TargetTable.Status = SourceTable.Status, 
                                                    TargetTable.ModifiedDate = GETDATE()
                                            WHEN NOT MATCHED BY TARGET THEN
                                                INSERT (TransactionId, AccountNo, Amount, CurrencyCode, TransactionDate, Status, CreateDate)
                                                VALUES (SourceTable.TransactionId, SourceTable.AccountNo, SourceTable.Amount, SourceTable.CurrencyCode, SourceTable.TransactionDate, SourceTable.Status, GETDATE());";

                                await sqlTransaction.CommitAsync();

                                using (SqlCommand sqlCommand = new SqlCommand(mergeData, sqlConnection))
                                {
                                    await sqlCommand.ExecuteNonQueryAsync();
                                }
                                using (SqlCommand sqlCommand = new SqlCommand("TRUNCATE TABLE TM_Transactions;", sqlConnection))
                                {
                                    await sqlCommand.ExecuteNonQueryAsync();
                                }


                                return true;
                            }
                            catch (Exception ex)
                            {
                                using (SqlCommand sqlCommand = new SqlCommand("TRUNCATE TABLE TM_Transactions;", sqlConnection))
                                {
                                    await sqlCommand.ExecuteNonQueryAsync();
                                }
                                throw ex;
                            }
                        }
                    }
                    catch(Exception ex) {
                        await sqlTransaction.RollbackAsync();
                        throw ex;
                    }
                }
            }
        }
    }
}
