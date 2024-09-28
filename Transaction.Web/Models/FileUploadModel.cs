using System.ComponentModel.DataAnnotations;
using Transaction.Extension;

namespace Transaction.Web.Models
{
    public class FileUploadModel
    {
        [MaxFileSize(1)]
        [AllowedExtension(new string[] { ".csv", ".xml" })]
        [Required(ErrorMessage = "Please select file.")]
        public IFormFile TransactionFile { get; set; }
        public string? FileName { get; set; }
    }
}
