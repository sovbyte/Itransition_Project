using Itransition_Project.Data.Repositories.Interfaces;
using Itransition_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Itransition_Project.Data.Repositories;

public class InventoryRepository(ApplicationDbContext context) : IInventoryRepository
{
    public async Task<IEnumerable<Inventory>> GetAllAsync()
    {
        return await context.Inventories.
            AsNoTracking().
            ToListAsync();
    }

    public async Task<Inventory?> GetByIdAsync(int id)
    {
        return await context.Inventories.
            AsNoTracking().
            FirstOrDefaultAsync(i => i.Id == id);  
    }

    public async Task AddAsync(Inventory entity)
    {
        await context.Inventories.AddAsync(entity);
    }

    public void Update(Inventory entity)
    {
        context.Inventories.Update(entity);
    }

    public void Delete(Inventory entity)
    {
        context.Inventories.Remove(entity);
    }

    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Inventory>> GetByCreatorIdAsync(string userId)
    {
        return await context.Inventories.Where(i => i.CreatorId == userId).ToListAsync();
    }

    public async Task<Inventory?> GetWithDetailsAsync(int id)
    {
        return await context.Inventories
            .Include(i => i.Items)
            .Include(i => i.InventoryTags).ThenInclude(it => it.Tag)
            .Include(i => i.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == id);
    }
}