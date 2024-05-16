using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using KoboldPainting.DAL.Abstract;
using KoboldPainting.Models;
using Microsoft.EntityFrameworkCore;

namespace KoboldPainting.DAL.Concrete
{
    public class WantedPaintRepository :Repository<WantedPaint>, IWantedPaintRepository
    {
        public WantedPaintRepository(KoboldPaintingDbContext context) : base(context)
        {
        }
        public async Task<List<WantedPaint>> GetUserWantedPaintsAsync(int userId) => await GetAll().Where(op => op.KoboldUserId == userId).ToListAsync();
        public async Task<bool> AddToWantedPaints(KoboldUser koboldUser, Paint paint)
        {
            var wantedPaint = new WantedPaint
            {
                KoboldUserId = koboldUser.Id,
                PaintId = paint.Id
            };
            try 
            {
                await AddOrUpdateAsync(wantedPaint);
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