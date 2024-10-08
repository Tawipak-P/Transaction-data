using Newtonsoft.Json;
using Serilog;
using System.Net;
using System.Text;
using Transaction.Enums;
using Transaction.Web.Models;
using Transaction.Web.Services.Interfaces;

namespace Transaction.Web.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<ResponseModel> SendAsync(RequestModel requestModel)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("TransactionApi");

                // Request Message
                var httpRequestMessage = new HttpRequestMessage();
                httpRequestMessage.RequestUri = new Uri(requestModel.Url);


                if (requestModel.ContentType == ContentType.MultipartFormData)
                {
                    httpRequestMessage.Headers.Add("Accept", "*/*");
                    var content = new MultipartFormDataContent();
                    foreach(var prop in requestModel.Data.GetType().GetProperties())
                    {
                        var value = prop.GetValue(requestModel.Data);
                        if(value is FormFile)
                        {
                            var file = (FormFile)value;
                            if(file is not null)
                            {
                                content.Add(new StreamContent(file.OpenReadStream()), prop.Name, file.FileName);
                            }
                        }
                    }

                    httpRequestMessage.Content = content;
                }
                else
                {
                    httpRequestMessage.Headers.Add("Accept", "application/json");
                    if (requestModel.Data != null)
                    {
                        httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(requestModel.Data), Encoding.UTF8, "application/json");
                    }
                }
                
                
                httpRequestMessage.Method = requestModel.Method;

                // Response Message
                var httpResponseMessage = new HttpResponseMessage();
                httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                switch (httpResponseMessage.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new ResponseModel() { IsSuccess = false, ErrorMessages = new List<string> { "Not Found" } };
                    case HttpStatusCode.BadRequest:
                        return new ResponseModel() { IsSuccess = false, ErrorMessages = new List<string> { "Bad Request" } };
                    default:
                        var content = await httpResponseMessage.Content.ReadAsStringAsync();
                        var response = JsonConvert.DeserializeObject<ResponseModel>(content);
                        return response;
                } 
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return new ResponseModel()
                {
                    IsSuccess = false,
                    ErrorMessages = new List<string> { ex.Message }
                };
            }
        }
    }
}
