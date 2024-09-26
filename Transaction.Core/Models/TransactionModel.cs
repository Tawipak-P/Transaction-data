using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Infrastructor.Entities
{
    public class TransactionModel 
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Transaction Id shoud not exceed 50 characters.")]
        public string TransactionId { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Account No. shoud not exceed 30 characters.")]
        public string AccountNo { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string CurrencyCode { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public string Status { get; set; }
     }
}
