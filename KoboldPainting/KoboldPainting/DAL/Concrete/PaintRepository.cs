using System.Diagnostics;
using KoboldPainting.Models;
using KoboldPainting.DAL.Abstract;

namespace KoboldPainting.DAL.Concrete
{
    public class PaintRepository : Repository<Paint>, IPaintRepository
    {
        public PaintRepository(KoboldPaintingDbContext context) : base(context)
        {
        }
    }
}