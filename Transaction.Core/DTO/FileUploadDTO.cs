using Microsoft.AspNetCore.Http;

namespace Transaction.Core.DTO
{
    public class FileUploadDTO
    {
        public IFormFile TransactionFile { get; set; }
        public string FileName { get; set; }
    }
}
