using ProjectTracker.Api.DTOs;

namespace ProjectTracker.Api.DB.Repositories;

public interface IProjectRepository
{
    Task<ProjectSummaryDto[]> GetAll();

    Task<Guid> AddNew(ProjectCreationDto project);

    Task<ProjectDto?> GetById(Guid Id);
    
    Task<ProjectSummaryDto[]> GetByName(string name);
}