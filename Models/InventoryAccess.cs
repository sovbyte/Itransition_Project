namespace Itransition_Project.Models;

public class InventoryAccess
{
    public int Id { get; set; }
    public int InventoryId { get; set; }
    public virtual Inventory Inventory { get; set; }
    public string UserId { get; set; }
    public virtual User User { get; set; }
}