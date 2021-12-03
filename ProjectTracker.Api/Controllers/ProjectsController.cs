using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Api.DTOs;
using ProjectTracker.Api.Services;

namespace ProjectTracker.Api.Controllers
{
    [ApiController]
    [Route("projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsService _service;

        public ProjectsController(IProjectsService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public Task<ProjectDto[]> Get(string? name)
        {
            return name is null ? _service.GetAll() : _service.GetByName(name);
        }

        [ProducesResponseType(typeof(ProjectDto), 200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> GetById(Guid id)
        {
            var project = await _service.GetById(id);
            return project is null ? NotFound() : Ok(project);
        }
        
        [HttpPost]
        public Task<Guid> Create(ProjectCreationDto project)
        {
            return _service.AddNew(project);
        }
    }
}
