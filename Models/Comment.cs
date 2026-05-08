namespace Itransition_Project.Models ;

public class Comment : BaseEntity
{
    public string Content { get; set; }
    
    public string UserId { get; set; }
    public virtual User User { get; set; }
    
    public int InventoryId { get; set; }
    public virtual Inventory Inventory { get; set; }
}