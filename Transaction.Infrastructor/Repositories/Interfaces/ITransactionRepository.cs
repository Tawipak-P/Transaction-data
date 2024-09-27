using Transaction.Infrastructor.StoreProcedures;
using Microsoft.Data.SqlClient;

namespace Transaction.Infrastructor.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task<List<TransactionDataResults>> SearchTransactionDataAsync(List<SqlParameter> sqlParameter);
    }
}
