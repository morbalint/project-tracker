using Microsoft.EntityFrameworkCore;
using NodaTime;
using ProjectTracker.Api.DTOs;
using ProjectTracker.Api.DB.Entities;
using Project = ProjectTracker.Api.DB.Entities.Project;

namespace ProjectTracker.Api.DB.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly IClock _clock;
    private readonly PtDbContext _ptDbContext;

    public ProjectRepository(IClock clock, PtDbContext ptDbContext)
    {
        _clock = clock;
        _ptDbContext = ptDbContext;
    }
    
    public Task<ProjectSummaryDto[]> GetAll()
    {
        return _ptDbContext.Projects.Select(p => new ProjectSummaryDto(
                p.Id, 
                p.Name, 
                (uint)p.WorkedOnDays.Count, 
                (uint)p.WorkedOnDays.Sum(d => d.Hours ?? 0u),
                p.StartDate))
            .ToArrayAsync();
    }

    public async Task<Guid> AddNew(ProjectCreationDto project2Create)
    {
        var creationTime = project2Create.StartTime ?? _clock.GetCurrentInstant();
        var project = new Project
        {
            Name = project2Create.Name,
            StartDate = creationTime,
            Notes = project2Create.Notes 
        };
        _ptDbContext.Projects.Add(project);
        await _ptDbContext.SaveChangesAsync();
        return project.Id;
    }

    public async Task<ProjectDto?> GetById(Guid id)
    {
        var project = await _ptDbContext.Projects
            .Include(p => p.WorkedOnDays)
            .FirstOrDefaultAsync(p => p.Id == id);

        return project switch
        {
            null => null,
            _ => new ProjectDto(
                project.Id, 
                project.Name,
                project.StartDate,
                project.Notes ?? string.Empty,
                project.WorkedOnDays
                    .Select(d => new WorkOnDayDto(d.Day, d.Notes ?? string.Empty, d.Hours))
                    .ToArray())
        };
    }

    public Task<ProjectSummaryDto[]> GetByName(string name)
    {
        return _ptDbContext.Projects.Where(project => project.Name.StartsWith(name))
            .Select(p => new ProjectSummaryDto(
                p.Id,
                p.Name,
                (uint)p.WorkedOnDays.Count,
                (uint)p.WorkedOnDays.Sum(d => d.Hours ?? 0u),
                p.StartDate))
            .ToArrayAsync();
    }
}
