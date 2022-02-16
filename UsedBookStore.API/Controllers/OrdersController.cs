using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsedBookStore.API.Data;
using UsedBookStore.API.Filters;
using UsedBookStore.API.Models;
using UsedBookStore.API.Models.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsedBookStore.API.Controllers
{
    [ApiKeyAuth]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/<OrdersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderModel>>> GetOrders()
        {
            var items = new List<OrderModel>();
            foreach (var item in await _context.Orders.Include(x => x.Customer).ToListAsync())
            {
                items.Add(new OrderModel(
                    item.Id,
                    item.OrderDate,
                    item.CustomerEmail
                    ));
            }

            return items;
        }
        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderModel>> GetOrderEntity(int id)
        {
            var orderEntity = await _context.Orders.Include(x => x.Customer).FirstOrDefaultAsync(x => x.Id == id);

            if (orderEntity == null)
            {
                return NotFound();
            }
            return new OrderModel(
                   orderEntity.Id,
                   orderEntity.OrderDate,
                   new CustomerModel(orderEntity.Customer.FirstName, orderEntity.Customer.LastName)
                );
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<ActionResult<OrderModel>> PostOrderEntity(OrderCreateModel orderCreateModel)
        {
            var _orderEntity = new OrderEntity(
                orderCreateModel.OrderDate,
                orderCreateModel.CustomerEmail
                );

            _context.Orders.Add(_orderEntity);
            await _context.SaveChangesAsync();

            var orderEntity = await _context.Orders.Include(x => x.Customer).FirstOrDefaultAsync(x => x.Id == _orderEntity.Id);

            return CreatedAtAction("GetOrderEntity", new { id = orderEntity.Id }, new OrderModel(
                orderEntity.Id,
                orderEntity.OrderDate,
                orderEntity.CustomerEmail
                ));

        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderEntity(int id, OrderUpdateModel orderUpdateModel)
        {
            if (id != orderUpdateModel.Id)
            {
                return BadRequest();
            }
            var orderEntity = await _context.Orders.FindAsync(id);
            orderEntity.Id = orderUpdateModel.Id;
            orderEntity.OrderDate = orderUpdateModel.OrderDate;
            orderEntity.CustomerEmail = orderUpdateModel.CustomerEmail;

            _context.Entry(orderEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderEntityExists(id))
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

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderEntity(int id)
        {
            var orderEntity = await _context.Orders.FindAsync(id);
            if (orderEntity == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(orderEntity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool OrderEntityExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }


    }
}
