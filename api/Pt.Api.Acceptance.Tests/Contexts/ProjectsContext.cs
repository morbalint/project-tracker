using System;
using Pt.Api.Acceptance.Tests.DTOs;

namespace Pt.Api.Acceptance.Tests.Contexts
{
    public class ProjectsContext
    {
        public CreateProjectDto? CreateDto { get; set; }
        
        public Guid? Id { get; set; }
        
        public ProjectDto? DetailDto { get; set; }
        
        public ProjectSummaryDto[]? ListOfProjects { get; set; }
    }
}
