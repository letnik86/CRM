using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM
{
    public class Customer
    {
        private Guid id;
        private string name;
        private short age;
        private List<Order> orders = new List<Order>();

        public Customer() { }

        public Guid Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public short Age { get => age; set => age = value; }
        public List<Order> Orders { get => orders; set => orders = value; }
    }
}
