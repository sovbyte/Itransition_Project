using Itransition_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Itransition_Project.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<User>(options)
{
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<InventoryTag> InventoryTags { get; set; }
    public DbSet<InventoryUser> InventoryAccesses { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Like> Likes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<InventoryTag>()
            .HasKey(it => new { it.InventoryId, it.TagId });

        builder.Entity<InventoryUser>()
            .HasKey(ia => new { ia.InventoryId, ia.UserId });

        builder.Entity<Item>()
            .HasIndex(i => new { i.InventoryId, i.CustomIdValue })
            .IsUnique();

        builder.Entity<Like>()
            .HasIndex(l => new { l.UserId, l.ItemId })
            .IsUnique();

        builder.Entity<Inventory>()
            .HasMany(i => i.Items)
            .WithOne(i => i.Inventory)
            .HasForeignKey(it => it.InventoryId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<Comment>()
            .HasOne(c => c.Inventory)
            .WithMany(i => i.Comments)
            .HasForeignKey(ci => ci.InventoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity &&
                        (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            var entity = (BaseEntity)entityEntry.Entity;
            
            entity.UpdatedAt =  DateTime.UtcNow;

            if (entityEntry.State == EntityState.Added)
            {
                entity.CreatedAt = DateTime.UtcNow;
            }
        }
        
        return base.SaveChangesAsync(cancellationToken);
    }
}