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
    public class GenresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GenresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreModel>>> GetGenres()
        {
            var items = new List<GenreModel>();
            foreach (var item in await _context.Genres.ToListAsync())
            {
                items.Add(new GenreModel(
                    item.Id,
                    item.Name
                    ));
            }
            return items;
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreModel>> GetGenreEntity(int id)
        {
            var genreEntity = await _context.Genres.FindAsync(id);

            if (genreEntity == null)
            {
                return NotFound();
            }

            return new GenreModel(
                genreEntity.Id,
                genreEntity.Name
                );
        }

        // PUT: api/Genres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenreEntity(int id, GenreModel genreModel)
        {
            var genreEntity = await _context.Genres.FindAsync(id);
            genreEntity.Name = genreModel.Name;

            _context.Entry(genreEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreEntityExists(id))
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

        // POST: api/Genres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GenreModel>> PostGenreEntity(GenreModel genreModel)
        {
            var genreEntity = new GenreEntity(
                genreModel.Id,
                genreModel.Name
                );

            _context.Genres.Add(genreEntity);
            await _context.SaveChangesAsync();

            var _genreEntity = await _context.Genres.FirstOrDefaultAsync(x => x.Id == genreEntity.Id);


            return CreatedAtAction("GetGenreEntity", new { id = genreEntity.Id }, new GenreModel(
                genreEntity.Id,
                genreEntity.Name
                ));
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenreEntity(int id)
        {
            var genreEntity = await _context.Genres.FindAsync(id);
            if (genreEntity == null)
            {
                return NotFound();
            }

            _context.Genres.Remove(genreEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GenreEntityExists(int id)
        {
            return _context.Genres.Any(e => e.Id == id);
        }
    }
}
