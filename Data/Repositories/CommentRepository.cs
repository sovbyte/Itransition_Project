using Itransition_Project.Data.Repositories.Interfaces;
using Itransition_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Itransition_Project.Data.Repositories;

public class CommentRepository(ApplicationDbContext context) : BaseRepository<Comment>(context), ICommentRepository
{
    private readonly ApplicationDbContext _context = context;
    
    public async Task<IEnumerable<Comment>> GetByInventoryIdAsync(int inventoryId, int take = 50)
    {
        return await  _context.Comments
            .Where(c => c.InventoryId == inventoryId)
            .Include(c => c.User)
            .OrderByDescending(c => c.CreatedAt)
            .Take(take)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<int> GetCommentsCountByInventoryIdAsync(int inventoryId)
    {
        return await _context.Comments
            .CountAsync(c => c.InventoryId == inventoryId);
    }
}