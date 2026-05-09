using Itransition_Project.Data.Repositories.Interfaces;
using Itransition_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Itransition_Project.Data.Repositories;

public class ItemRepository(ApplicationDbContext context) : BaseRepository<Item>(context), IItemRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<Item>> GetByInventoryIdAsync(int inventoryId, int skip, int take)
    {
        return await _context.Items.
            Where(i => i.InventoryId == inventoryId)
            .OrderByDescending(i => i.CreatedAt)
            .Skip(skip)
            .Take(take)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Item?> GetWithDetailsAsync(int id)
    {
        return await _context.Items
            .Include(i => i.Inventory)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<bool> ExistsByCustomIdAsync(int inventoryId, string customId)
    {
        return await _context.Items
            .AnyAsync(i => i.InventoryId == inventoryId && i.CustomIdValue == customId);
    }
}