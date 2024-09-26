using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using Transaction.Core.Models;
using Transaction.Core.Services.Interfaces;
using Transaction.Infrastructor.Entities;
using Transaction.Infrastructor.Repositories.Interfaces;

namespace Transaction.Core.Services
{
    internal class TransactioService : ITransactioService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TransactioService> _logger;
        public TransactioService(ITransactionRepository transactionRepository, IMapper mapper, ILogger<TransactioService> logger)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ResponseModel> UploadTransactionDataAsync(List<TransactionModel> transactionModel)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var transactionData = _mapper.Map<List<TransactionData>>(transactionModel);
                var results = await _transactionRepository.UploadTransactionDataAsync(transactionData);
                response = _mapper.Map<ResponseModel>(results);
                return response;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                return response;
            }
        }
    }
}
