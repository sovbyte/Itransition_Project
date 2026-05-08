using Itransition_Project.Data.Repositories.Interfaces;
using Itransition_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Itransition_Project.Data.Repositories;

public class BaseRepository<T>(ApplicationDbContext context) : IRepository<T> where T : BaseEntity
{
    public virtual async Task<IEnumerable<T>> GetAllAsync() =>
        await context.Set<T>().AsNoTracking().ToListAsync();

    public virtual async Task<T?> GetByIdAsync(int id) =>
        await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    
    public virtual async Task AddAsync(T entity) =>
        await context.Set<T>().AddAsync(entity);    

    public virtual void Update(T entity) => context.Set<T>().Update(entity);
    
    public virtual void Delete(T entity) => context.Set<T>().Remove(entity);

    public virtual async Task SaveAsync() => await context.SaveChangesAsync();
}