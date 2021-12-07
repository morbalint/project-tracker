using Microsoft.EntityFrameworkCore;
using Project = ProjectTracker.Api.DB.Entities.Project;
using WorkedOnDay = ProjectTracker.Api.DB.Entities.WorkedOnDay;

namespace ProjectTracker.Api.DB;

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
