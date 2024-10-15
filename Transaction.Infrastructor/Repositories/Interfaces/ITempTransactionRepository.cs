using System.Data;


namespace Transaction.Infrastructor.Repositories.Interfaces
{
    public interface ITempTransactionRepository
    {
        Task<bool> UploadTransactionWithSqlBlukCopyAsync(DataTable dataTable);
    }
}
