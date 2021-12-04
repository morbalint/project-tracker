using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace ProjectTracker.Db.Entities;

public class Project
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = null!; // Required. 
    
    public Instant StartDate { get; set; }

    public Instant CreationDate { get; set; }

    [InverseProperty(nameof(WorkedOnDay.ProjectLink))]
    public ISet<WorkedOnDay> WorkedOnDays { get; set; } = new HashSet<WorkedOnDay>();
}
