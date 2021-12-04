using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace ProjectTracker.Db.Entities;

public class WorkedOnDay
{
    public Guid ProjectId { get; set; }
    
    public Instant Day { get; set; }
    
    public uint Hours { get; set; }
    
    public string? Notes { get; set; }
    
    [ForeignKey(nameof(ProjectId))]
    public Project? ProjectLink { get; set; }
}
