using Transaction.Core.Models;
using Transaction.Core.DTO;
using Transaction.Infrastructor.Entities;

namespace Transaction.Core.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<ResponseModel> SearchTransactionDataAsync(SearchCriteria searchCriteria);
        Task<ResponseModel> GetAllStatusAsync();
        Task<ResponseModel> GetAllCurrencyCodeAsync();
    }
}
