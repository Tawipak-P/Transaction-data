using Microsoft.AspNetCore.Http;
using System.Data;
using System.Xml.Linq;
using Transaction.Core.DTO;
using Transaction.Core.Models;

namespace Transaction.Core.Services.Interfaces
{
    public interface ITempTransactionService
    {
        Task<ResponseModel> UploadTransactionDataFromCSVAsync(FileUploadDTO file);
        Task<ResponseModel> UploadTransactionDataFromXMLAsync(FileUploadDTO file);
    }
}
