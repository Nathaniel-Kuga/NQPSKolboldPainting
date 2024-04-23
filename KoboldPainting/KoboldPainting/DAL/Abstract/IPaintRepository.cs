using KoboldPainting.Models;

namespace KoboldPainting.DAL.Abstract
{
    /// <summary>
    /// Interface for common and CRUD operations on Paint entities
    /// </summary>
    public interface IPaintRepository : IRepository<Paint>
    {
        // Add any additional methods needed for Paint entities
        /// <summary>
        /// Performs a Fuzzy String comparison on the paint name
        /// </summary>
        /// <param name="paintName"></param>
        /// <returns>Resturns list of games that contain the paint name</returns>
        public List<Paint> FuzzySearch(string paintName);
    }
}