using System;
using Transaction.Core.Models;
using Transaction.Infrastructor.Entities;

namespace Transaction.Core.Services.Interfaces
{
    public interface ITransactioService
    {
        Task<ResponseModel> UploadTransactionDataAsync(List<TransactionModel> transactionModel);
    }
}
