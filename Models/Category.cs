namespace Itransition_Project.Models;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<Inventory> Inventories { get; set; } =  new List<Inventory>();
}