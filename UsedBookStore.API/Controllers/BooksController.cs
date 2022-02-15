#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsedBookStore.API.Data;
using UsedBookStore.API.Filters;
using UsedBookStore.API.Models;
using UsedBookStore.API.Models.Entities;

namespace UsedBookStore.API.Controllers
{
    [ApiKeyAuth]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookModel>>> GetBooks()
        {
            var items = new List<BookModel>();
            foreach (var item in await _context.Books.Include(x => x.Genre).Include(x => x.Format).Include(x => x.Condition).ToListAsync())
            {
                items.Add(new BookModel(
                    item.Id,
                    item.Title,
                    item.Author,
                    item.ImageUrl,
                    item.Description,
                    item.ISBN,
                    item.Price,
                    new FormatModel(item.Format.Name),
                    new GenreModel(item.Genre.Name),
                    new ConditionModel(item.Condition.Name)
                    ));

            }

            return items;
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookModel>> GetBookEntity(int id)
        {
            var bookEntity = await _context.Books.Include(x => x.Genre).Include(x => x.Format).Include(x => x.Condition).FirstOrDefaultAsync(x => x.Id == id);

            if (bookEntity == null)
            {
                return NotFound();
            }
            return new BookModel(
                bookEntity.Id,
                bookEntity.Title,
                bookEntity.Author,
                bookEntity.ImageUrl,
                bookEntity.Description,
                bookEntity.ISBN,
                bookEntity.Price,
                new FormatModel(bookEntity.Format.Name),
                new GenreModel(bookEntity.Genre.Name),
                new ConditionModel(bookEntity.Condition.Name)
                );
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookEntity(int id, BookUpdateModel bookUpdateModel)
        {
            if (id != bookUpdateModel.Id)
            {
                return BadRequest();
            }
            var bookEntity = await _context.Books.FindAsync(id);
            bookEntity.Title = bookUpdateModel.Title;
            bookEntity.Author = bookUpdateModel.Author;
            bookEntity.ImageUrl = bookUpdateModel.ImageUrl;
            bookEntity.Description = bookUpdateModel.Description;
            bookEntity.ISBN = bookUpdateModel.ISBN;
            bookEntity.Price = bookUpdateModel.Price;
            bookEntity.FormatId = bookUpdateModel.FormatId;
            bookEntity.GenreId = bookUpdateModel.GenreId;
            bookEntity.ConditionId = bookUpdateModel.ConditionId;

            _context.Entry(bookEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookEntityExists(id))
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

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookModel>> PostBookEntity(BookCreateModel bookCreateModel)
        {
            var _bookEntity = new BookEntity(
                bookCreateModel.Id,
                bookCreateModel.Title,
                bookCreateModel.Author,
                bookCreateModel.ImageUrl,
                bookCreateModel.Description,
                bookCreateModel.ISBN,
                bookCreateModel.Price,
                bookCreateModel.FormatId,
                bookCreateModel.GenreId,
                bookCreateModel.ConditionId
                );

            _context.Books.Add(_bookEntity);
            await _context.SaveChangesAsync();

            var bookEntity = await _context.Books.Include(x => x.Format).Include(x => x.Genre).Include(x => x.Condition).FirstOrDefaultAsync(x => x.Id == _bookEntity.Id);

            return CreatedAtAction("GetBookEntity", new { id = bookEntity.Id }, new BookModel(
                bookEntity.Id,
                bookEntity.Title,
                bookEntity.Author,
                bookEntity.ImageUrl,
                bookEntity.Description,
                bookEntity.ISBN,
                bookEntity.Price,
                new FormatModel(bookEntity.Format.Id, bookEntity.Format.Name),
                new GenreModel(bookEntity.Genre.Id, bookEntity.Genre.Name),
                new ConditionModel(bookEntity.Condition.Id, bookEntity.Condition.Name)
                ));

        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookEntity(int id)
        {
            var bookEntity = await _context.Books.FindAsync(id);
            if (bookEntity == null)
            {
                return NotFound();
            }

            _context.Books.Remove(bookEntity);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool BookEntityExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
