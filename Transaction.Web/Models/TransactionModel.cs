﻿using System.ComponentModel.DataAnnotations;

namespace Transaction.Web.Models
{
    public class TransactionModel
    {
        public string Id { get; set; }

        public string Payment { get; set; }

        public string Status { get; set; }
     }
}
