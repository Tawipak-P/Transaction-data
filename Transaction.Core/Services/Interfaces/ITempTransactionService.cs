using Transaction.Core.Models;

namespace Transaction.Core.Services.Interfaces
{
    public interface ITempTransactionService
    {
        Task<ResponseModel> UploadTransactionWithSqlBlukCopyAsync(FileUploadModel file);
    }
}
