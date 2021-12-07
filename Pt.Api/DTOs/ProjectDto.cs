using NodaTime;

namespace ProjectTracker.Api.DTOs;

public record ProjectCreationDto(string Name, Instant? StartTime, string? Notes);

public record ProjectSummaryDto(Guid Id, string Name, uint TotalDaysWorkedOn, uint TotalHoursWorkedOn, Instant StartTime);

public record ProjectDto(Guid Id, string Name, Instant StartTime, String Notes, WorkOnDayDto[] DaysWorkedOn);

public record WorkOnDayDto(Instant Day, string Notes, uint? Hours);