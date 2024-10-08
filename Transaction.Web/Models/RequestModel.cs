

using Transaction.Enums;

namespace Transaction.Web.Models
{
    public class RequestModel
    {
        public HttpMethod Method { get; set; } = HttpMethod.Get;
        public string Url { get; set; }
        public object Data { get; set; }
        public ContentType ContentType { get; set; } = ContentType.Json;
    }
}
