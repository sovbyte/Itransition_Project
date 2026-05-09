using Itransition_Project.Models;

namespace Itransition_Project.Data.Repositories.Interfaces;

public interface ICommentRepository
{
    Task<IEnumerable<Comment>> GetByInventoryIdAsync(int inventoryId, int take = 50);
    
    Task<int>  GetCommentsCountByInventoryIdAsync(int inventoryId);
}
