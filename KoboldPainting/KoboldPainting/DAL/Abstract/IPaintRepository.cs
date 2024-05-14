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
        public List<Paint> FuzzySearch(string paintName, int percentage);

        public List<Paint> searchPaints(string PaintName, int CompanyID);
        /// <summary>
        /// Get all paints that are owned by a user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Returns List of Type Paint</returns>
        public List<Paint> GetUserOwnedPaints(int userId);
        /// <summary>
        /// Get all paints that are wanted by a user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Returns List of Type Paint</returns>
        public List<Paint> GetUserWantedPaints(int userId);
        /// <summary>
        /// Get all paints that need to be refilled by a user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Returns List of Type Paint</returns>
        public List<Paint> GetUserRefillPaints(int userId);
        
    }
}