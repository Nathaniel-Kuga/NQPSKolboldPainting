using System.Diagnostics;
using KoboldPainting.Models;
using KoboldPainting.DAL.Abstract;

namespace KoboldPainting.DAL.Concrete
{
    public class PaintTypeRepository : Repository<PaintType>, IPaintTypeRepository
    {
        public PaintTypeRepository(KoboldPaintingDbContext context) : base(context)
        {
        }
    }
}