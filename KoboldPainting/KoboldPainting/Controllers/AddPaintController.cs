using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KoboldPainting.Models;
using KoboldPainting.Models.DataTransferObjects;
using KoboldPainting.DAL.Abstract;
using Microsoft.AspNetCore.Identity;
using KoboldPainting.Areas.Identity.Data;
namespace KoboldPainting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddPaintController : ControllerBase
    {
        private readonly KoboldPaintingDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IKoboldUserRepository _koboldUserRepository;
        private readonly IPaintRepository _paintRepository;
        private readonly IOwnedPaintRepository _ownedPaintRepository;
        private readonly IWantedPaintRepository _wantedPaintRepository;
        public AddPaintController(KoboldPaintingDbContext context,
                                  UserManager<ApplicationUser> userManager,
                                  IKoboldUserRepository koboldUserRepository,
                                  IPaintRepository paintRepository,
                                  IOwnedPaintRepository ownedPaintRepository,
                                  IWantedPaintRepository wantedPaintRepository)
        {
            _context = context;
            _userManager = userManager;
            _koboldUserRepository = koboldUserRepository;
            _paintRepository = paintRepository;
            _ownedPaintRepository = ownedPaintRepository;
            _wantedPaintRepository = wantedPaintRepository;
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

            if (paintDto.List == "Owned")
            {
                //! check for duplicate entry
                var currentUser = await _userManager.GetUserAsync(User);
                var koboldUser = _koboldUserRepository.GetAll().FirstOrDefault(u => u.AspNetUserId == currentUser.Id);
                var check = await _ownedPaintRepository.GetUserOwnedPaintsAsync(koboldUser.Id);
                if (check.Any(op => op.Paint.PaintName == paintDto.Name && op.Paint.Company.CompanyName == paintDto.Company))
                {
                    return BadRequest("You already own that paint.");
                }
                //! if not duplicate, proceed.
                var paint = _paintRepository.GetPaintByCompanyAndName(paintDto.Company, paintDto.Name);
                try 
                {
                    var result = await _ownedPaintRepository.AddToOwnedPaints(koboldUser, paint);
                    return Ok("Successfully added to owned paints.");
                }
                catch (ArgumentNullException e) 
                {
                    return BadRequest(e);
                }
            }
            else if (paintDto.List == "Wanted")
            {
                                //! check for duplicate entry
                var currentUser = await _userManager.GetUserAsync(User);
                var koboldUser = _koboldUserRepository.GetAll().FirstOrDefault(u => u.AspNetUserId == currentUser.Id);
                var check = await _wantedPaintRepository.GetUserWantedPaintsAsync(koboldUser.Id);
                if (check.Any(op => op.Paint.PaintName == paintDto.Name && op.Paint.Company.CompanyName == paintDto.Company))
                {
                    return BadRequest("You already own that paint.");
                }
                //! if not duplicate, proceed.
                var paint = _paintRepository.GetPaintByCompanyAndName(paintDto.Company, paintDto.Name);
                try 
                {
                    var result = await _ownedPaintRepository.AddToOwnedPaints(koboldUser, paint);
                    return Ok("Successfully added to owned paints.");
                }
                catch (ArgumentNullException e) 
                {
                    return BadRequest(e);
                }
                //get paint
                //get user
                //add to wanted paint table
            }
            else
            {
                return BadRequest();
            }

            return Ok("Successfully updated db.");
        }
        private bool PaintExists(int id)
        {
            return (_context.Paints?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }


}
