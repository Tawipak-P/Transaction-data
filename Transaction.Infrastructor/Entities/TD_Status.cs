using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2C2P.AssignmentTest.Infrastructor.Entities
{
    public class TD_Status
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
    }
}
