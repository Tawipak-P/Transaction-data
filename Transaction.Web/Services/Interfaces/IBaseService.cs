using Transaction.Web.Models;

namespace Transaction.Web.Services.Interfaces
{
    public interface IBaseService
    {
        Task<ResponseModel> SendAsync(RequestModel requestModel);
    }
}
