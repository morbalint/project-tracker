using NodaTime;

namespace ProjectTracker.Api.DTOs;

public class ProjectDto
{
    public ProjectDto(Guid id, string name, Instant startTime, Instant[] datesWorkedOn)
    {
        Id = id;
        Name = name;
        StartTime = startTime;
        DatesWorkedOn = datesWorkedOn;
    }

    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public Instant StartTime { get; set; }

    public Instant[] DatesWorkedOn { get; set; } 
}
