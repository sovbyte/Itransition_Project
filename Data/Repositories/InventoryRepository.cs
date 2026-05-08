using Itransition_Project.Data.Repositories.Interfaces;
using Itransition_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Itransition_Project.Data.Repositories;

public class InventoryRepository(ApplicationDbContext context) : BaseRepository<Inventory>(context), IInventoryRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<Inventory>> GetByCreatorIdAsync(string userId)
    {
        return await _context.Inventories.Where(i => i.CreatorId == userId).ToListAsync();
    }

    public async Task<Inventory?> GetWithDetailsAsync(int id)
    {
        return await _context.Inventories
            .Include(i => i.Items)
            .Include(i => i.InventoryTags).ThenInclude(it => it.Tag)
            .Include(i => i.Category)
            .FirstOrDefaultAsync(i => i.Id == id);
    }
}