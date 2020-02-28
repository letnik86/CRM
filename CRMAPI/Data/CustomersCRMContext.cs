using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRM;

namespace CustomersCRM.Data
{
    public class CustomersCRMContext : DbContext
    {
        public CustomersCRMContext (DbContextOptions<CustomersCRMContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}
