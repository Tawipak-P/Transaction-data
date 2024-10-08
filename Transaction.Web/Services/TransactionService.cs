using Transaction.Web.Models;
using Transaction.Web.Services.Interfaces;
using Transaction.Web.DTO;
using Transaction.Helpers;

namespace Transaction.Web.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IBaseService _baseService;

        public TransactionService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseModel> GetAllCurrencyCodeAsync()
        {
            return await _baseService.SendAsync(new RequestModel
            {
                Method = HttpMethod.Get,
                Url = ApiHelper.GetAllCurrencyCodeApi
            });
        }

        public async Task<ResponseModel> GetAllStatusAsync()
        {
            return await _baseService.SendAsync(new RequestModel
            {
                Method = HttpMethod.Get,
                Url = ApiHelper.GetAllStatusApi
            });
        }

        public async Task<ResponseModel> SearchAsync(SearchCriteria searchCriteria)
        {
            return await _baseService.SendAsync(new RequestModel
            {
                Method = HttpMethod.Post,
                Url = ApiHelper.SearchTransactionDataApi,
                Data = searchCriteria,
            });
        }

    }
}
