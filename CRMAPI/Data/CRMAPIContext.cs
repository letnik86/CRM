using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRM;

namespace CRMAPI.Data
{
    public class CRMAPIContext : DbContext
    {
        public CRMAPIContext (DbContextOptions<CRMAPIContext> options)
            : base(options)
        {
        }

        public DbSet<CRM.Customer> Customer { get; set; }

        public DbSet<CRM.Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Order>()
                .HasKey(s => s.Id);
        }


    }
}
