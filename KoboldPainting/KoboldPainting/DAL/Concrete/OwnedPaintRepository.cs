using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using KoboldPainting.DAL.Abstract;
using KoboldPainting.Models;
using Microsoft.EntityFrameworkCore;

namespace KoboldPainting.DAL.Concrete
{
    public class OwnedPaintRepository :Repository<OwnedPaint>, IOwnedPaintRepository
    {
        public OwnedPaintRepository(KoboldPaintingDbContext context) : base(context)
        {
        }
        public async Task<List<OwnedPaint>> GetUserOwnedPaintsAsync(int userId) => await GetAll().Where(op => op.KoboldUserId == userId).ToListAsync();

        public async Task<bool> AddToOwnedPaints(KoboldUser koboldUser, Paint paint)
        {
            var ownedPaint = new OwnedPaint
            {
                KoboldUserId = koboldUser.Id,
                PaintId = paint.Id
            };
            try 
            {
                await AddOrUpdateAsync(ownedPaint);
                return true;
            }
            catch (ArgumentNullException e) 
            {
                Debug.WriteLine(e);
                return false;
            }
        }
    }
}