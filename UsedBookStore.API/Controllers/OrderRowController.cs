using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsedBookStore.API.Data;
using UsedBookStore.API.Models;
using UsedBookStore.API.Models.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsedBookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderRowsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrderRowsController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/<OrderRowController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderRowModel>>> GetOrderRows()
        {
            var items = new List<OrderRowModel>();
            foreach (var item in await _context.OrderRows.Include(x => x.Book).Include(x => x.Order).ToListAsync())
            {
                items.Add(new OrderRowModel(
                    item.OrderRowId,
                    new OrderModel(item.Order.Id, item.Order.OrderDate, item.Order.CustomerEmail),
                    new BookModel(item.Book.Title),
                    item.Quantity
                    ));
            }

            return items;
        }

        // GET api/<OrderRowController>/5
        [HttpGet("{id}")]

        public async Task<ActionResult<OrderRowModel>> GetOrderRowEntity(int id)
        {
            var orderRowEntity = await _context.OrderRows.Include(x => x.Book).Include(x => x.Order).FirstOrDefaultAsync(x => x.OrderRowId == id);

            if (orderRowEntity == null)
            {
                return NotFound();
            }
            return new OrderRowModel(
                orderRowEntity.OrderRowId,
                new OrderModel(orderRowEntity.Order.Id, orderRowEntity.Order.OrderDate, orderRowEntity.Order.CustomerEmail),
                new BookModel(orderRowEntity.Book.Title),
                orderRowEntity.Quantity
                );
        }


        // POST api/<OrderRowController>
        [HttpPost]
        public async Task<ActionResult<OrderRowModel>> PostOrderRowEntity(OrderRowCreateModel orderRowCreateModel)
        {
            var order = _context.Orders.OrderByDescending(a => a.Id).FirstOrDefault();

            var _orderRowEntity = new OrderRowEntity(
                orderRowCreateModel.OrderRowId,
                order.Id,
                orderRowCreateModel.BookId,
                orderRowCreateModel.Quantity
                );

            _context.OrderRows.Add(_orderRowEntity);
            await _context.SaveChangesAsync();

            var orderRowEntity = await _context.OrderRows.Include(x => x.Book).Include(x => x.Order).Include(x => x.Order.Customer).FirstOrDefaultAsync(x => x.OrderRowId == _orderRowEntity.OrderRowId);


            return CreatedAtAction("GetOrderRowEntity", new { id = orderRowEntity.OrderRowId }, new OrderRowModel(
                orderRowEntity.OrderRowId,
                new OrderModel(orderRowEntity.Order.Id, orderRowEntity.Order.OrderDate, orderRowEntity.Order.CustomerEmail),
                new BookModel(orderRowEntity.Book.Title),
                orderRowEntity.Quantity
                ));

        }



        // PUT api/<OrderRowController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderModelEntity(int id, OrderRowUpdateModel orderRowUpdateModel)
        {
            if (id != orderRowUpdateModel.OrderRowId)
            {
                return BadRequest();
            }
            var orderRowEntity = await _context.OrderRows.FindAsync(id);
            orderRowEntity.OrderRowId = orderRowUpdateModel.OrderRowId;
            orderRowEntity.OrderId = orderRowUpdateModel.OrderId;
            orderRowEntity.BookId = orderRowUpdateModel.BookId;
            orderRowEntity.Quantity = orderRowUpdateModel.Quantity;

            _context.Entry(orderRowEntity).State = EntityState.Modified;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderRowEntityExists(id))
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


        // DELETE api/<OrderRowController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderRowEntity(int id)
        {
            var orderRowEntity = await _context.OrderRows.FindAsync(id);
            if (orderRowEntity == null)
            {
                return NotFound();
            }

            _context.OrderRows.Remove(orderRowEntity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool OrderRowEntityExists(int id)
        {
            return _context.OrderRows.Any(e => e.OrderRowId == id);
        }

    }
}
