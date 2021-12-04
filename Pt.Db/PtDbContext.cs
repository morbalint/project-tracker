using Microsoft.EntityFrameworkCore;
using ProjectTracker.Db.Entities;

namespace ProjectTracker.Db;

public class PtDbContext : DbContext
{
    public PtDbContext()
    {
    }

    public PtDbContext(DbContextOptions<PtDbContext> options) : base(options)
    {
    }
    
    public DbSet<Project> Projects { get; set; } = null!;

    public DbSet<WorkedOnDay> WorkedOnDays { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WorkedOnDay>()
            .HasKey(nameof(WorkedOnDay.ProjectId), nameof(WorkedOnDay.Day));
        
        base.OnModelCreating(modelBuilder);
    }
}
