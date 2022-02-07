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
    public class ConditionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ConditionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Conditions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConditionModel>>> GetConditions()
        {
            var items = new List<ConditionModel>();
            foreach (var item in await _context.Conditions.ToListAsync())
            {
                items.Add(new ConditionModel(
                    item.Id,
                    item.Name
                    ));
            }
            return items;
        }

        // GET: api/Conditions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConditionModel>> GetConditionEntity(int id)
        {
            var conditionEntity = await _context.Conditions.FindAsync(id);

            if (conditionEntity == null)
            {
                return NotFound();
            }

            return new ConditionModel(
                conditionEntity.Id,
                conditionEntity.Name
                );
        }

        // PUT: api/Conditions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConditionEntity(int id, ConditionModel conditionModel)
        {
            var conditionEntity = await _context.Conditions.FindAsync(id);
            conditionEntity.Name = conditionModel.Name;

            _context.Entry(conditionEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConditionEntityExists(id))
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

        // POST: api/Conditions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConditionModel>> PostConditionEntity(ConditionModel conditionModel)
        {
            var conditionEntity = new ConditionEntity(
                conditionModel.Id,
                conditionModel.Name
                );

            _context.Conditions.Add(conditionEntity);
            await _context.SaveChangesAsync();

            var _conditionEntity = await _context.Conditions.FirstOrDefaultAsync(x => x.Id == conditionEntity.Id);


            return CreatedAtAction("GetConditionEntity", new { id = conditionEntity.Id }, new ConditionModel(
                conditionEntity.Id,
                conditionEntity.Name
                ));
        }

        // DELETE: api/Conditions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConditionEntity(int id)
        {
            var conditionEntity = await _context.Conditions.FindAsync(id);
            if (conditionEntity == null)
            {
                return NotFound();
            }

            _context.Conditions.Remove(conditionEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConditionEntityExists(int id)
        {
            return _context.Conditions.Any(e => e.Id == id);
        }
    }
}
