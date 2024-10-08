using Transaction.Web.Models;
using Transaction.Web.DTO;

namespace Transaction.Web.Services.Interfaces
{
    public interface ITempTransactionService
    {
        Task<ResponseModel> UploadTransactionDataFromCSVAsync(FileUploadModel file);
        Task<ResponseModel> UploadTransactionDataFromXMLAsync(FileUploadModel file);
    }
}
