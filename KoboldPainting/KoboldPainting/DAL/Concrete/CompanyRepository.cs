using System.Diagnostics;
using KoboldPainting.Models;
using KoboldPainting.DAL.Abstract;

namespace KoboldPainting.DAL.Concrete
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(KoboldPaintingDbContext context) : base(context)
        {
        }
    }
}