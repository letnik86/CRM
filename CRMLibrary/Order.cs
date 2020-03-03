using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRM
{
    public class Order
    {
        public Order() { }

        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public Guid CustomerId { get; set; }

    }
}
