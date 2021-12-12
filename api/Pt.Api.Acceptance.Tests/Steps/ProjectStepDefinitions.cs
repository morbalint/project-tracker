using System;
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
        private IRestResponse<Guid>? _response;

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
            _response = await _driver.CreateProject(_context.CreateDto!);
        }

        [Then(@"the response should be OK")]
        public void ThenTheResponseShouldBeOk()
        {
            _response.Should()
                .NotBeNull().And.Subject
                .As<IRestResponse<Guid>>()
                .StatusCode.Should().Be(HttpStatusCode.OK, _response!.ErrorMessage);
        }
        
        [Then(@"the response should be a non null id")]
        public void ThenTheResponseShouldBeANonNullId()
        {
            _response!.Data.Should().NotBe(Guid.Empty);
        }
    }
}