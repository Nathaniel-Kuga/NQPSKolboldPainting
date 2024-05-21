using KoboldPainting.Models;

namespace KoboldPainting.DAL.Abstract
{
    /// <summary>
    /// Interface for common and CRUD operations on Paint entities
    /// </summary>
    public interface IOwnedPaintRepository : IRepository<OwnedPaint>
    {
        public Task<List<OwnedPaint>> GetUserOwnedPaintsAsync(int userId);       
        
        public Task<bool> AddToOwnedPaints(KoboldUser koboldUser, Paint paint);
    }
}