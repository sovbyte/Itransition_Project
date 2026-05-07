namespace Itransition_Project.Models;

public class InventoryTag
{
    public int Id { get; set; }
    public int InventoryId { get; set; }
    public virtual Inventory Inventory { get; set; }
    public int TagId { get; set; }
    public virtual Tag Tag { get; set; }
}