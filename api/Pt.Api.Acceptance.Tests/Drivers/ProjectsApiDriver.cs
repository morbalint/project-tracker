using System;
using System.Threading.Tasks;
using Pt.Api.Acceptance.Tests.Config;
using Pt.Api.Acceptance.Tests.DTOs;
using RestSharp;

namespace Pt.Api.Acceptance.Tests.Drivers
{
    public class ProjectsApiDriver : IProjectsApiDriver
    {
        private readonly IRestClient _client;

        public ProjectsApiDriver(IRestClient client)
        {
            _client = client;
        }
        
        public Task<IRestResponse<Guid>> CreateProject(CreateProjectDto dto)
        {
            var request = new RestRequest("projects", Method.POST)
            {
                RequestFormat = DataFormat.Json,
            };
            request.AddBody(dto);
            return _client.ExecuteAsync<Guid>(request);
        }

        public Task<IRestResponse<ProjectSummaryDto[]>> ListAllProjects()
        {
            throw new NotImplementedException();
        }
    }
}
