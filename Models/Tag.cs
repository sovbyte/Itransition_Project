namespace Itransition_Project.Models;

public class Tag : BaseEntity
{
    public string Name { get; set; }
    public ICollection<InventoryTag> InventoryTags { get; set; } = new List<InventoryTag>();
}