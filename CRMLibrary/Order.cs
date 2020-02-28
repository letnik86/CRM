using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM
{
    public class Order
    {
        private Guid id;
        private DateTime date;
        private Double amount;

        public Order() { }

        public Guid Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public double Amount { get => amount; set => amount = value; }
    }
}
