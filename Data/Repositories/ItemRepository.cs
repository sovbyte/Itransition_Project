using Itransition_Project.Data.Repositories.Interfaces;
using Itransition_Project.Models;

namespace Itransition_Project.Data.Repositories;

public class ItemRepository(ApplicationDbContext context) : BaseRepository<Item>(context), IItemRepository
{
    //TODO
}