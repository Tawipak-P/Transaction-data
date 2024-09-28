using Transaction.Infrastructor.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Transaction.Infrastructor.StoreProcedures;

namespace Transaction.Infrastructor.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly TransactionDbContext _dbContext;

        #region Constructor
        public TransactionRepository(TransactionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion


        public async Task<List<TransactionDataResults>> SearchTransactionDataAsync(List<SqlParameter> sqlParameter)
        {
            var response = new List<TransactionDataResults>();
            try
            {
                response =  await _dbContext.Set<TransactionDataResults>().FromSqlRaw(
                    "EXECUTE dbo.SP_SearchTransaction @CurrencyCode, @DateFrom,@DateTo, @Status, @PageSize, @PageNumber",
                    sqlParameter.ToArray()).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw ex.InnerException != null ? ex.InnerException : ex;
                
            }
        }
    }
}
