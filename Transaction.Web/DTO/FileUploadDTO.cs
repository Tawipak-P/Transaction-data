
namespace Transaction.Web.DTO
{
    public class FileUploadDTO
    {
        public IFormFile TransactionFile { get; set; }
        public string FileName { get; set; }
    }
}
