using Itransition_Project.Models;

namespace Itransition_Project.Data.Repositories;

public interface IInventoryRepository : IRepository<Inventory>
{
    Task<IEnumerable<Inventory>> GetByCreatorIdAsync(string  userId);
    Task<Inventory?> GetWithDetailsAsync(int id);
}