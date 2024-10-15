using Transaction.Web.Models;
using Transaction.Web.DTO;

namespace Transaction.Web.Services.Interfaces
{
    public interface ITempTransactionService
    {
        Task<ResponseModel> UploadTransactionWithSqlBlukCopyAsync(FileUploadModel file);
    }
}
