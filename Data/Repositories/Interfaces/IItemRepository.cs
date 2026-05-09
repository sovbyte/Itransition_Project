using Itransition_Project.Models;

namespace Itransition_Project.Data.Repositories.Interfaces;

public interface IItemRepository : IRepository<Item>
{
    Task<IEnumerable<Item>> GetByInventoryIdAsync(int inventoryId, int skip, int take);
    
    Task<Item?> GetWithDetailsAsync(int id);
    
    Task<bool> ExistsByCustomIdAsync(int inventoryId,string customId);
}