using NodaTime;
using ProjectTracker.Api.DTOs;

namespace ProjectTracker.Api.Services;

public class ProjectsService : IProjectsService
{
    private readonly IClock _clock;
    private Dictionary<Guid, ProjectDto> _projects = new Dictionary<Guid, ProjectDto>();

    public ProjectsService(IClock clock)
    {
        _clock = clock;
    }
    
    public Task<ProjectDto[]> GetAll()
    {
        return Task.FromResult(_projects.Values.ToArray());
    }

    public Task<Guid> AddNew(ProjectCreationDto project2Create)
    {
        var creationTime = project2Create.StartTime ?? _clock.GetCurrentInstant();
        var project = new ProjectDto(Guid.NewGuid(), project2Create.Name!, creationTime, Array.Empty<Instant>());
        _projects[project.Id] = project;
        return Task.FromResult(project.Id);
    }

    public Task<ProjectDto?> GetById(Guid Id)
    {
        var result = _projects.TryGetValue(Id, out var project) ? project : null;
        return Task.FromResult(result);
    }

    public Task<ProjectDto[]> GetByName(string name)
    {
        var result = _projects.Values.Where(p => p.Name.StartsWith(name)).ToArray();
        return Task.FromResult(result);
    }
}
