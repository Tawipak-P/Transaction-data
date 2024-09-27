using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Infrastructor.Entities
{
    public class TD_Transaction
    {
        [Key]
        [MaxLength(50)]
        public string TransactionId { get; set; }

        [MaxLength(30)]
        public string AccountNo { get; set; }
        public decimal Amount { get; set; }

        [MaxLength(3)]
        public string CurrencyCode { get; set; }
        public DateTime TransactionDate { get; set; }

        [MaxLength(10)]
        public string Status { get; set; }
     }
}
