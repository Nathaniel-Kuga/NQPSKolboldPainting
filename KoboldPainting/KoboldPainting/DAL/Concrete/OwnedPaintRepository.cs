using System.Collections.Generic;
using System.Linq.Expressions;
using KoboldPainting.DAL.Abstract;
using KoboldPainting.Models;

namespace KoboldPainting.DAL.Concrete
{
    public class OwnedPaintRepository :Repository<OwnedPaint>, IOwnedPaintRepository
    {
        public OwnedPaintRepository(KoboldPaintingDbContext context) : base(context)
        {
        }
    }
}