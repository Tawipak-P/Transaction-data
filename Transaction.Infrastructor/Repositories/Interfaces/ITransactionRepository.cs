using Transaction.Infrastructor.StoreProcedures;
using Microsoft.Data.SqlClient;
using Transaction.Infrastructor.Entities;

namespace Transaction.Infrastructor.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task<List<TransactionDataResults>> SearchTransactionDataAsync(List<SqlParameter> sqlParameter);
        Task<List<TD_Status>> GetAllStatusAsync();
        Task<List<TD_CurrencyCode>> GetAllCurrencyCodeAsync();
    }
}
