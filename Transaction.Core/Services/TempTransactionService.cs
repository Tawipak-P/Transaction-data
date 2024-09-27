using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Xml.Linq;
using Transaction.Core.Models;
using Transaction.Core.Services.Interfaces;
using Transaction.Infrastructor.Repositories.Interfaces;

namespace Transaction.Core.Services
{
    public class TempTransactionService : ITempTransactionService
    {
        private readonly ITempTransactionRepository _tempTransactionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TempTransactionService> _logger;
        public TempTransactionService(ITempTransactionRepository tempTransactionRepository, IMapper mapper, ILogger<TempTransactionService> logger)
        {
            _tempTransactionRepository = tempTransactionRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ResponseModel> UploadTransactionDataFromCSVAsync(DataTable dataTable)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var results = await _tempTransactionRepository.UploadTransactionDataFormCSVAsync(dataTable);
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


        public async Task<ResponseModel> UploadTransactionDataFromXMLAsync(XDocument xDocument)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var results = await _tempTransactionRepository.UploadTransactionDataFromXMLAsync(xDocument);
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
