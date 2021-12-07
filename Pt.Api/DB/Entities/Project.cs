using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace ProjectTracker.Api.DB.Entities;

public class Project
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = null!; // Required. 
    
    public Instant StartDate { get; set; }
    
    public string? Notes { get; set; }

    [InverseProperty(nameof(Api.DB.Entities.WorkedOnDay.ProjectLink))]
    public ISet<Api.DB.Entities.WorkedOnDay> WorkedOnDays { get; set; } = new HashSet<Api.DB.Entities.WorkedOnDay>();
}
