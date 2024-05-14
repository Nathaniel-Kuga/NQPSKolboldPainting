using System.Diagnostics;
using KoboldPainting.Models;
using KoboldPainting.DAL.Abstract;

namespace KoboldPainting.DAL.Concrete
{
    public class KoboldUserRepository : Repository<KoboldUser>, IKoboldUserRepository
    {
        public KoboldUserRepository(KoboldPaintingDbContext context) : base(context)
        {
        }
    }
}