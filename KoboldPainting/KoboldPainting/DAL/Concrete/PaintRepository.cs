using System.Diagnostics;
using KoboldPainting.Models;
using KoboldPainting.DAL.Abstract;
using FuzzySharp;

namespace KoboldPainting.DAL.Concrete
{
    public class PaintRepository : Repository<Paint>, IPaintRepository
    {
        public PaintRepository(KoboldPaintingDbContext context) : base(context)
        {
        }

        public List<Paint> FuzzySearch(string paintName, int percentage)
        {
            if (string.IsNullOrEmpty(paintName))
            {
                return new List<Paint>();
            }

            var potentialPaintMatches = GetAll().Where(p => p.PaintName.Contains(paintName)).ToList();
            var paintsToReturn = new List<Paint>();

            if (potentialPaintMatches.Count == 0)
            {
                // add paint there are no matches
                return new List<Paint>();
            }
            else
            {
                foreach (var paint in potentialPaintMatches)
                {
                    if (Fuzz.Ratio(paintName, paint.PaintName) > percentage)
                    {
                        paintsToReturn.Add(paint);
                    }
                }
            }
            return paintsToReturn;
        }

        public List<Paint> searchPaints(string PaintName, int CompanyID)
        {
            //use fuzzy 
            List<Paint> paintsToReturn = FuzzySearch(PaintName, 70);
            //if the company is not empty then filter it
            if (CompanyID != 1)
            {
                List<Paint> refinedList = paintsToReturn.Where(p => p.CompanyId == CompanyID).ToList();
                return refinedList;
            }


            return paintsToReturn;
        }
    }
}