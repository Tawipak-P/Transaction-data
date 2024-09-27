using System.ComponentModel.DataAnnotations;

namespace Transaction.Extension
{
    public class AllowedExtensionAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;

        public AllowedExtensionAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName).ToLower();
                if (!_extensions.Contains(extension))
                {
                    return new ValidationResult("Unknown format.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
