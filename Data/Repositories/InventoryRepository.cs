using Itransition_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Itransition_Project.Data.Repositories;

public class InventoryRepository(ApplicationDbContext context) : IInventoryRepository
{
    private readonly ApplicationDbContext _context = context;
    
    public async Task<IEnumerable<Inventory>> GetAllAsync()
    {
        return await _context.Inventories.
            AsNoTracking().
            ToListAsync();
    }

    public async Task<Inventory?> GetByIdAsync(int id)
    {
        return await _context.Inventories.
            AsNoTracking().
            FirstOrDefaultAsync(i => i.Id == id);  
    }

    public async Task AddAsync(Inventory entity)
    {
        await _context.Inventories.AddAsync(entity);
    }

    public void Update(Inventory entity)
    {
        _context.Inventories.Update(entity);
    }

    public void Delete(Inventory entity)
    {
        _context.Inventories.Remove(entity);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

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
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == id);
    }
}