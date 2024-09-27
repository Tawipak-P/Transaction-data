using Transaction.Infrastructor.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Transaction.Infrastructor.StoreProcedures;

namespace Transaction.Infrastructor.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly TransactionDbContext _dbContext;
        private readonly ILogger<TransactionRepository> _logger;

        #region Constructor
        public TransactionRepository(TransactionDbContext dbContext, ILogger<TransactionRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
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
                _logger?.LogError(ex.ToString());
                throw ex.InnerException != null ? ex.InnerException : ex;
                
            }
        }
    }
}
