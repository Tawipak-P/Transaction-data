using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Core.Models
{
    public class RequestModel
    {
        public HttpMethod Method { get; set; } = HttpMethod.Get;
        public string Url { get; set; }
        public object Data { get; set; }
        public string ContentType { get; set; }
    }
}
