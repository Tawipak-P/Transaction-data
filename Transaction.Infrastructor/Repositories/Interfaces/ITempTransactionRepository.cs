using System.Data;
using System.Xml.Linq;


namespace Transaction.Infrastructor.Repositories.Interfaces
{
    public interface ITempTransactionRepository
    {
        Task<bool> UploadTransactionDataFormCSVAsync(DataTable dataTable);
        Task<bool> UploadTransactionDataFromXMLAsync(XDocument xDocument);
    }
}
