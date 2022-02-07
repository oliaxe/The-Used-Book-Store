#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsedBookStore.API.Data;
using UsedBookStore.API.Models;

namespace UsedBookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Shoppings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingCartModel>>> GetShoppingCarts()
        {
            var items = new List<ShoppingCartModel>();
            foreach (var item in await _context.ShoppingCarts.ToListAsync())
            {
                items.Add(new ShoppingCartModel(
                    item.Id
                    ));
            }
            return items;
        }

        // GET: api/Shoppings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingCartModel>> GetShoppingCartEntity(int id)
        {
            var shoppingCartEntity = await _context.ShoppingCarts.FindAsync(id);

            if (shoppingCartEntity == null)
            {
                return NotFound();
            }

            return new ShoppingCartModel(
                shoppingCartEntity.Id
                );
        }

        // PUT: api/Shoppings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingCartEntity(int id, ShoppingCartModel shoppingCartModel)
        {
            var shoppingCartEntity = await _context.ShoppingCarts.FindAsync(id);

            _context.Entry(shoppingCartEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingCartEntityExists(id))
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

        // POST: api/Shoppings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<ShoppingCartModel>> PostShoppingCartEntity(ShoppingCartCreateModel shoppingCartCreateModel)
        //{
        //    var _shoppingCartEntity = new ShoppingCartEntity(
        //        shoppingCartCreateModel.Id, 
        //        shoppingCartCreateModel.BookList.Add(shoppingCartCreateModel.BookId)
        //        );

        //    _context.ShoppingCarts.Add(_shoppingCartEntity);
        //    await _context.SaveChangesAsync();

        //    var shoppingCartEntity = await _context.Genres.FirstOrDefaultAsync(x => x.Id == _shoppingCartEntity.Id);


        //    return CreatedAtAction("GetShoppingCartEntity", new { id = shoppingCartEntity.Id }, new ShoppingCartModel(
        //        shoppingCartEntity.Id
        //        ));
        //}

        // DELETE: api/Shoppings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingCartEntity(int id)
        {
            var shoppingCartEntity = await _context.ShoppingCarts.FindAsync(id);
            if (shoppingCartEntity == null)
            {
                return NotFound();
            }

            _context.ShoppingCarts.Remove(shoppingCartEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShoppingCartEntityExists(int id)
        {
            return _context.ShoppingCarts.Any(e => e.Id == id);
        }
    }
}
