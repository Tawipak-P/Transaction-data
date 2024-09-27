using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Infrastructor.StoreProcedures
{ 
    public class TransactionDataResults
    {
        public string Id { get; set; }
        public string Payment { get; set; }
        public string Status { get; set; }
     }
}
