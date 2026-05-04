using Itransition_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Itransition_Project.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = null!;

}
