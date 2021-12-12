using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pt.Api.Acceptance.Tests.Config;
using Pt.Api.Acceptance.Tests.DTOs;
using RestSharp;

namespace Pt.Api.Acceptance.Tests.Drivers
{
    public class ProjectsApiDriver : IProjectsApiDriver
    {
        private const string ProjectsEndpoint = "projects";
        
        private readonly IRestClient _client;

        public ProjectsApiDriver(IRestClient client)
        {
            _client = client;
        }
        
        public Task<IRestResponse<Guid>> CreateProject(CreateProjectDto dto)
        {
            var request = new RestRequest(ProjectsEndpoint, Method.POST)
            {
                RequestFormat = DataFormat.Json,
            };
            request.AddBody(dto);
            return _client.ExecuteAsync<Guid>(request);
        }

        public Task<IRestResponse<IEnumerable<ProjectSummaryDto>>> ListAllProjects()
        {
            var request = new RestRequest(ProjectsEndpoint, Method.GET);
            return _client.ExecuteAsync<IEnumerable<ProjectSummaryDto>>(request);
        }

        public Task<IRestResponse<ProjectDto>> GetProjectById(Guid id)
        {
            var request = new RestRequest(ProjectsEndpoint + "/{id}", Method.GET);
            request.AddParameter("id", id, ParameterType.UrlSegment);
            return _client.ExecuteAsync<ProjectDto>(request);
        }
    }
}
