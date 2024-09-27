using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Infrastructor.Entities
{
    public class TD_CurrencyCode
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(3)]
        public string CurrencyCode { get; set; }
    }
}
