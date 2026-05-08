using Itransition_Project.Data.Repositories.Interfaces;
using Itransition_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Itransition_Project.Data.Repositories;

public class TagRepository(ApplicationDbContext context) : ITagRepository
{
    public async Task<IEnumerable<Tag>> GetAllAsync()
    {
        return await context.Tags.
            AsNoTracking()
            .ToListAsync();
    }

    public async Task<Tag?> GetByIdAsync(int id)
    {
        return await context.Tags.
            AsNoTracking().
            FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Tag entity)
    {
        await context.Tags.AddAsync(entity);
    }

    public void Update(Tag entity)
    {
        context.Tags.Update(entity);
    }

    public void Delete(Tag entity)
    {
        context.Tags.Remove(entity);
    }

    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }
    //todo use this method to search for unique tags when trying to create new tag
    public Task<Tag?> GetByNameAsync(string name)
    {
        return context.Tags.Where(x => x.Name == name).FirstOrDefaultAsync();
    }
}