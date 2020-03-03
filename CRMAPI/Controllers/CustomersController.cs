using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRM;
using CRMAPI.Data;

namespace CRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CRMAPIContext _context;

        public CustomersController(CRMAPIContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            foreach (Order order in _context.Order)
            {
                 _context.Customer.FindAsync(order.CustomerId).Result.Orders.Add(order);
            }
            return await _context.Customer.ToListAsync();
        }

        // GET: api/Customers/Sum
        [HttpGet("{Sum}")]
        public List<Customer> GetCustomer(double Sum)
        {
            List<Customer> customers = new List<Customer>();
            foreach (Order order in _context.Order)
            {
                _context.Customer.FindAsync(order.CustomerId).Result.Orders.Add(order);
            }
            foreach (Customer customer in _context.Customer)
            {
                if (customer.GetAmountSum() > Sum && customer.Orders.Any(e => e.Date > DateTime.Now.AddYears(-1)) && customer.Orders.All(a => a.Amount > 1000))
                {
                    customers.Add(customer);
                }
            }
            return customers;
        }

        // PUT: api/Customers/id
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(Guid id, Customer customer)
        {
            customer.Id = id;
            _context.Entry(customer).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {

            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(Guid id)
        {
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        private bool CustomerExists(Guid id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}
