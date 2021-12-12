using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pt.Api.Acceptance.Tests.DTOs;
using RestSharp;

namespace Pt.Api.Acceptance.Tests.Drivers
{
    public interface IProjectsApiDriver
    {
        public Task<IRestResponse<Guid>> CreateProject(CreateProjectDto dto);

        public Task<IRestResponse<IEnumerable<ProjectSummaryDto>>> ListAllProjects();
        
        public Task<IRestResponse<ProjectDto>> GetProjectById(Guid id);
    }
}
