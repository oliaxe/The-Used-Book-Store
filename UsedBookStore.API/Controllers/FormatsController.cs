#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsedBookStore.API.Data;
using UsedBookStore.API.Models;
using UsedBookStore.API.Models.Entities;

namespace UsedBookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormatsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FormatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Formats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormatModel>>> GetFormats()
        {
            var items = new List<FormatModel>();
            foreach (var item in await _context.Formats.ToListAsync())
            {
                items.Add(new FormatModel(
                    item.Id,
                    item.Name
                    ));
            }
            return items;
        }

        // GET: api/Formats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FormatModel>> GetFormatEntity(int id)
        {
            var formatEntity = await _context.Formats.FindAsync(id);

            if (formatEntity == null)
            {
                return NotFound();
            }

            return new FormatModel(
                formatEntity.Id,
                formatEntity.Name
                );
        }

        // PUT: api/Formats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormatEntity(int id, FormatModel formatModel)
        {
            var formatEntity = await _context.Conditions.FindAsync(id);
            formatEntity.Name = formatModel.Name;

            _context.Entry(formatEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormatEntityExists(id))
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

        // POST: api/Formats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FormatModel>> PostFormatEntity(FormatModel formatModel)
        {
            var formatEntity = new FormatEntity(
                formatModel.Id,
                formatModel.Name
                );

            _context.Formats.Add(formatEntity);
            await _context.SaveChangesAsync();

            var _formatEntity = await _context.Formats.FirstOrDefaultAsync(x => x.Id == formatEntity.Id);


            return CreatedAtAction("GetFormatEntity", new { id = formatEntity.Id }, new FormatModel(
                formatEntity.Id,
                formatEntity.Name
                ));
        }

        // DELETE: api/Formats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormatEntity(int id)
        {
            var formatEntity = await _context.Formats.FindAsync(id);
            if (formatEntity == null)
            {
                return NotFound();
            }

            _context.Formats.Remove(formatEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FormatEntityExists(int id)
        {
            return _context.Formats.Any(e => e.Id == id);
        }
    }
}
