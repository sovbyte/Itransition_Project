using Itransition_Project.Data.Repositories.Interfaces;
using Itransition_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Itransition_Project.Data.Repositories;

public class TagRepository(ApplicationDbContext context) : BaseRepository<Tag>(context), ITagRepository
{
    private readonly ApplicationDbContext _context = context;
    
    //todo use this method to search for unique tags when trying to create new tag
    public Task<Tag?> GetByNameAsync(string name)
    {
        return _context.Tags.Where(x => x.Name == name)
            .AsNoTracking().
            FirstOrDefaultAsync();
    }
}