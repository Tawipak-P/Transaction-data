using Transaction.Infrastructor.Entities;
using Transaction.Infrastructor.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Infrastructor.Models;

namespace Transaction.Infrastructor.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly TransactionDbContext _dbContext;
        private readonly ILogger<TransactionRepository> _logger;

        #region Constructor
        public TransactionRepository(TransactionDbContext dbContext, ILogger<TransactionRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        public async Task<ResponseModel> UploadTransactionDataAsync(List<TransactionData> transactionData)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                foreach(var transaction in transactionData)
                {
                    _dbContext.TD_TransactionData.Add(transaction);
                }
                await _dbContext.SaveChangesAsync();
                response.IsSuccess = true;
                return response;
            }
            catch(Exception ex)
            {
                _logger?.LogError(ex.ToString());
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                return response;
            }
        }
    }
}
