using Microsoft.AspNetCore.Http;

namespace Transaction.Api.DTO
{
    public class FileUploadDTO
    {
        public IFormFile TransactionFile { get; set; }
        public string FileName { get; set; }
    }
}
