﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Transaction.Core.Models
{
    public class TransactionModel 
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Transaction Id shoud not exceed 50 characters.")]
        public string TransactionId { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Account No. shoud not exceed 30 characters.")]
        public string AccountNo { get; set; }

        public decimal? Amount { get; set; }

        [Required]
        public string CurrencyCode { get; set; }

        public DateTime? TransactionDate { get; set; }

        [Required]
        public string Status { get; set; }
     }
}
