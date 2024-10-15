using Transaction.Web.Models;
using Transaction.Web.Services.Interfaces;
using Transaction.Web.DTO;
using Transaction.Helpers;
using Transaction.Enums;

namespace Transaction.Web.Services
{
    public class TempTransactionService : ITempTransactionService
    {
        private readonly IBaseService _baseService;

        public TempTransactionService(IBaseService baseService)
        {
            _baseService = baseService;
        }


        public async Task<ResponseModel> UploadTransactionWithSqlBlukCopyAsync(FileUploadModel file)
        {
            return await _baseService.SendAsync(new RequestModel
            {
                Method = HttpMethod.Post,
                Url = ApiHelper.UploadTransactionWithSqlBlukCopyApi,
                Data = file,
                ContentType = ContentType.MultipartFormData,
            });
        }
    }
}
