using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2C2P.AssignmentTest.Infrastructor.Entities
{
    public class TransactionData
    {
        [Key]
        [MaxLength(50, ErrorMessage = "Transaction Id shoud not exceed 50 characters.")]
        public string TransactionId { get; set; }

        [MaxLength(30, ErrorMessage = "Account No. shoud not exceed 30 characters.")]
        public string AccountNo { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; }
     }
}
