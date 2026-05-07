namespace Itransition_Project.Models;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<InventoryTag> InventoryTags { get; set; } = new List<InventoryTag>();
}