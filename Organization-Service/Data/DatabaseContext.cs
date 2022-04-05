using Microsoft.EntityFrameworkCore;
using Organization_Service.Models;

namespace Organization_Service.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
    
    public DbSet<Organization> Organization { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Organization>().ToTable("Organization");
    }

}