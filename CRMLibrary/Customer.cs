using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRM
{
    public class Customer
    {
        public Customer() 
        {
            this.Orders = new HashSet<Order>();
        }
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public short Age { get; set; }

        [ForeignKey("CustomerId")]
        public ICollection<Order> Orders { get; set; }

        public double GetAmountSum()
        {
            double sum = 0;
            foreach (Order order in Orders)
            {
                sum += order.Amount;
            }
            return sum;
        }


    }
}
