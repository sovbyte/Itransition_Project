namespace Itransition_Project.Models ;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public string UserId { get; set; }
    public virtual User User { get; set; }
    
    public int InventoryId { get; set; }
    public virtual Inventory Inventory { get; set; }
}