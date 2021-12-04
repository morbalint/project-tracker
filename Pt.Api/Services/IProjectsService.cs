using ProjectTracker.Api.DTOs;

namespace ProjectTracker.Api.Services;

public interface IProjectsService
{
    Task<ProjectDto[]> GetAll();

    Task<Guid> AddNew(ProjectCreationDto project);

    Task<ProjectDto?> GetById(Guid Id);
    
    Task<ProjectDto[]> GetByName(string name);
}