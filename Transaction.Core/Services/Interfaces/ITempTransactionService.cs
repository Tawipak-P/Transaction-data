using System.Data;
using System.Xml.Linq;
using Transaction.Core.Models;

namespace Transaction.Core.Services.Interfaces
{
    public interface ITempTransactionService
    {
        Task<ResponseModel> UploadTransactionDataFromCSVAsync(DataTable dataTable);
        Task<ResponseModel> UploadTransactionDataFromXMLAsync(XDocument xDocument);
    }
}
