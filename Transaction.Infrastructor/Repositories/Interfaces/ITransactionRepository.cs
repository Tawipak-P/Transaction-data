using Transaction.Infrastructor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Infrastructor.Models;

namespace Transaction.Infrastructor.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task<ResponseModel> UploadTransactionData(TransactionData transactionData);
    }
}
