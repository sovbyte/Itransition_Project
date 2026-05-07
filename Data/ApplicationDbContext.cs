using Itransition_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Itransition_Project.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<User>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<InventoryTag>()
            .HasKey(it => new { it.InventoryId, it.TagId });

        builder.Entity<InventoryAccess>()
            .HasKey(ia => new { ia.InventoryId, ia.UserId });

        builder.Entity<Item>()
            .HasIndex(i => new { i.InventoryId , i.CustomIdValue })
            .IsUnique();    
        
        builder.Entity<Like>()
            .HasIndex(l => new { l.UserId, l.ItemId })
            .IsUnique();
}
}