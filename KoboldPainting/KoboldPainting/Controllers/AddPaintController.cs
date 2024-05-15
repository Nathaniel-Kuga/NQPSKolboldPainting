using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KoboldPainting.Models;
using KoboldPainting.Models.DataTransferObjects;
namespace KoboldPainting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddPaintController : ControllerBase
    {
        private readonly KoboldPaintingDbContext _context;

        public AddPaintController(KoboldPaintingDbContext context)
        {
            _context = context;
        }

        // // GET: api/AddPaint
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<Paint>>> GetPaints()
        // {
        //   if (_context.Paints == null)
        //   {
        //       return NotFound();
        //   }
        //     return await _context.Paints.ToListAsync();
        // }

        // GET: api/AddPaint/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paint>> GetPaint(int id)
        {
            if (_context.Paints == null)
            {
                return NotFound();
            }
            var paint = await _context.Paints.FindAsync(id);

            if (paint == null)
            {
                return NotFound();
            }

            return paint;
        }

        // PUT: api/AddPaint/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaint(int id, Paint paint)
        {
            if (id != paint.Id)
            {
                return BadRequest();
            }

            _context.Entry(paint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaintExists(id))
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

        // POST: api/AddPaint
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Paint>> PostPaint(Paint paint)
        {
            if (_context.Paints == null)
            {
                return Problem("Entity set 'KoboldPaintingDbContext.Paints'  is null.");
            }
            _context.Paints.Add(paint);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaint", new { id = paint.Id }, paint);
        }

        // DELETE: api/AddPaint/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaint(int id)
        {
            if (_context.Paints == null)
            {
                return NotFound();
            }
            var paint = await _context.Paints.FindAsync(id);
            if (paint == null)
            {
                return NotFound();
            }

            _context.Paints.Remove(paint);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        //Post : api/AddPaintToCollection 
        // POST: api/AddPaint/AddPaintToCollection
        [HttpPost("AddPaintToCollection")]
        public async Task<ActionResult> AddPaintToCollection([FromBody] PaintDto paintDto)
        {

            // if (paintDto == null) return BadRequest();
            // Your code here

            return Ok();
        } 
        private bool PaintExists(int id)
        {
            return (_context.Paints?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }


}
