

namespace Transaction.Web.Models
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }
    }
}
