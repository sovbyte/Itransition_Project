using Itransition_Project.Models;

namespace Itransition_Project.Data.Repositories.Interfaces;

public interface ITagRepository : IRepository<Tag>
{
    public Task<Tag?> GetByNameAsync(string name);
}