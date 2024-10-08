using Microsoft.AspNetCore.Http;

namespace Transaction.Core.Models
{
    public class FileUploadModel
    {
        public IFormFile TransactionFile { get; set; }
        public string FileName { get; set; }
    }
}
