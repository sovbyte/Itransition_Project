using Itransition_Project.Data.Repositories.Interfaces;
using Itransition_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Itransition_Project.Data.Repositories;

public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
{
    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await context.Categories.
            AsNoTracking()
            .ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await context.Categories.
            AsNoTracking().
            FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Category entity)
    {
         await context.Categories.AddAsync(entity);
    }

    public void Update(Category entity)
    { 
        context.Categories.Update(entity);
    }

    public void Delete(Category entity)
    {
        context.Categories.Remove(entity);
    }

    public async Task SaveAsync()
    { 
        await context.SaveChangesAsync();
    }
}