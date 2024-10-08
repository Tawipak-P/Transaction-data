using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Transaction.Core.Models;
using Transaction.Core.Services.Interfaces;
using Transaction.Infrastructor.Repositories.Interfaces;
using Transaction.Core.DTO;

namespace Transaction.Core.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ILogger<TransactionService> _logger;
        public TransactionService(ITransactionRepository transactionRepository, ILogger<TransactionService> logger)
        {
            _transactionRepository = transactionRepository;
            _logger = logger;
        }

        public async Task<ResponseModel> GetAllCurrencyCodeAsync()
        {
            var response = new ResponseModel();
            try
            {

                var results = await _transactionRepository.GetAllCurrencyCodeAsync();
                response.IsSuccess = true;
                response.Result = results;
                return response;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                throw ex.InnerException != null ? ex.InnerException : ex;
            }
        }

        public async Task<ResponseModel> GetAllStatusAsync()
        {
            var response = new ResponseModel();
            try
            {

                var results = await _transactionRepository.GetAllStatusAsync();
                response.IsSuccess = true;
                response.Result = results;
                return response;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                throw ex.InnerException != null ? ex.InnerException : ex;
            }
        }

        public async Task<ResponseModel> SearchTransactionDataAsync(SearchCriteria searchCriteria)
        {
            var response = new ResponseModel();
            try
            {

                var sqlParam = new List<SqlParameter>()
                {
                    new SqlParameter("@CurrencyCode", (object)searchCriteria.CurrencyCode ?? DBNull.Value),
                    new SqlParameter("@DateFrom", (object)searchCriteria.ConvertToDateFrom() ?? DBNull.Value),
                    new SqlParameter("@DateTo", (object)searchCriteria.ConvertToDateTo() ?? DBNull.Value),
                    new SqlParameter("@Status", (object)searchCriteria.Status ?? DBNull.Value),
                    new SqlParameter("@PageSize", searchCriteria.PageSize),
                    new SqlParameter("@PageNumber", searchCriteria.PageNumber),
                };

                var results = await _transactionRepository.SearchTransactionDataAsync(sqlParam);
                response.IsSuccess = true;
                response.Result = results;
                return response;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                throw ex.InnerException != null ? ex.InnerException : ex;
            }
        }


    }
}
