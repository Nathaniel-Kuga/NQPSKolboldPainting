using System.Collections.Generic;
using System.Linq.Expressions;
using KoboldPainting.DAL.Abstract;
using KoboldPainting.Models;

namespace KoboldPainting.DAL.Concrete
{
    public class WantedPaintRepository :Repository<WantedPaint>, IWantedPaintRepository
    {
        public WantedPaintRepository(KoboldPaintingDbContext context) : base(context)
        {
        }
    }
}