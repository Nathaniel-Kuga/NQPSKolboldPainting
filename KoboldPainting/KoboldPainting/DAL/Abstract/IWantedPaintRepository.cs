using KoboldPainting.Models;

namespace KoboldPainting.DAL.Abstract
{
    /// <summary>
    /// Interface for common and CRUD operations on WantedPaint entities
    /// </summary>
    public interface IWantedPaintRepository : IRepository<WantedPaint>
    {
        /// <summary>
        /// Get all paints wanted by a user
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a list of WantedPaint objects for a given user.</returns>
        public Task<List<WantedPaint>> GetUserWantedPaintsAsync(int userId);
        /// <summary>
        /// Add a paint to a user's wanted list
        /// </summary>
        /// <param name="koboldUser"></param>
        /// <param name="paint"></param>
        /// <returns>Returns true if the paint was successfully added to the user's wanted list, false otherwise.</returns>
        public Task<bool> AddToWantedPaints(KoboldUser koboldUser, Paint paint);
    }
}