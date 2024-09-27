using Transaction.Core.Models;
using TransactionData.Core.DTO;

namespace Transaction.Core.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<ResponseModel> SearchTransactionDataAsync(SearchCriteria searchCriteria);
    }
}
