using Transaction.Web.Models;
using Transaction.Web.DTO;

namespace Transaction.Web.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<ResponseModel> SearchAsync(SearchCriteria searchCriteria);
        Task<ResponseModel> GetAllCurrencyCodeAsync();
        Task<ResponseModel> GetAllStatusAsync();
    }
}
