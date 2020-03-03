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
    public class OrdersController : ControllerBase
    {
        private readonly CRMAPIContext _context;

        public OrdersController(CRMAPIContext context)
        {
            _context = context;
        }

        // GET: api/Orders/id
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Order>>> GetOrder(Guid id)
        {
            List<Order> orders = new List<Order>();
            await foreach (Order order in _context.Order)
            {
                if (order.CustomerId.Equals(id))
                {
                    orders.Add(order);
                }
            }

            if (orders == null)
            {
                return NotFound();
            }

            return orders;
        }

        // POST: api/Orders
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Guid id, Order order)
        {
            order.CustomerId = id;
            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }


        private bool OrderExists(Guid id)
        {
            return _context.Order.Any(e => e.Id == id);
        }
    }
}
