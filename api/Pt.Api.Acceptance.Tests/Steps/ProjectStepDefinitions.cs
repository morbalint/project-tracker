using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Pt.Api.Acceptance.Tests.Contexts;
using Pt.Api.Acceptance.Tests.Drivers;
using Pt.Api.Acceptance.Tests.DTOs;
using RestSharp;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Pt.Api.Acceptance.Tests.Steps
{
    [Binding]
    public class ProjectStepDefinitions
    {
        private readonly ProjectsContext _context;
        private readonly IProjectsApiDriver _driver;
        private IRestResponse? _response;

        public ProjectStepDefinitions(
            ProjectsContext context,
            IProjectsApiDriver driver)
        {
            _context = context;
            _driver = driver;
        }

        [Given(@"a project")]
        public void GivenAProject(Table table)
        {
            var dto = table.CreateInstance<CreateProjectDto>();
            _context.CreateDto = dto;
        }

        [When(@"the projects POST endpoint is called")]
        public async Task WhenTheProjectsPostEndpointIsCalled()
        {
            _context.CreateDto.Should().NotBeNull();
            var response = await _driver.CreateProject(_context.CreateDto!);
            _context.Id = response.IsSuccessful ? response.Data : null;
            _response = response;
        }

        [Then(@"the response should be OK")]
        public void ThenTheResponseShouldBeOk()
        {
            _response.Should()
                .NotBeNull().And.Subject
                .As<IRestResponse>()
                .StatusCode.Should().Be(HttpStatusCode.OK, _response!.ErrorMessage);
        }
        
        [Then(@"the response should be a non null id")]
        public void ThenTheResponseShouldBeANonNullId()
        {
            _context.Id.Should().NotBeNull().And.NotBe(Guid.Empty);
        }

        [When(@"the projects GET endpoint is called with the context Id")]
        public async Task WhenTheProjectsGetEndpointIsCalledWithTheContextId()
        {
            _context.Id.Should().NotBeNull();
            var response = await _driver.GetProjectById(_context.Id!.Value);
            _context.DetailDto = response.IsSuccessful ? response.Data : null;
        }

        [Then(@"the response project should be the same")]
        public void ThenTheResponseProjectShouldBeTheSame(Table table)
        {
            var project = table.CreateInstance<ProjectDto>();
            project.Should().BeEquivalentTo(
                _context.DetailDto!,
                options => options
                    .Excluding(p => p.Id)
                    .Excluding(p => p.StartTime));
        }

        [When(@"the projects GET endpoint is called")]
        public async Task WhenTheProjectsGetEndpointIsCalled()
        {
            var response = await _driver.ListAllProjects();
            _context.ListOfProjects = response.IsSuccessful ? response.Data.ToArray() : null;
            _response = response;
        }


        [Then(@"the response should contain a project like this")]
        public void ThenTheResponseShouldContainAProjectLikeThis(Table table)
        {
            var projectToSearchFor = table.CreateInstance<ProjectSummaryDto>();
            _context.ListOfProjects.Should().Contain(dto =>
                dto.Name.Equals(projectToSearchFor.Name, StringComparison.InvariantCulture));
        }
    }
}