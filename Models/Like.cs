namespace Itransition_Project.Models;

public class Like
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public int ItemId { get; set; }
    public virtual Item Item { get; set; }
}