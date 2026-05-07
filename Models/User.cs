using Microsoft.AspNetCore.Identity;

namespace Itransition_Project.Models;

public class User : IdentityUser
{
    public bool IsBlocked { get; set; }
    
    public virtual ICollection<Inventory> OwnedInventories { get; set; } = new List<Inventory>();
}