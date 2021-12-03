using System.ComponentModel.DataAnnotations;
using NodaTime;

namespace ProjectTracker.Api.DTOs;

public class ProjectCreationDto
{
    [Required]
    public string? Name { get; set; }
    
    public Instant? StartTime { get; set; }
}