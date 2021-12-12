using System.IO;
using BoDi;
using Microsoft.Extensions.Configuration;
using Pt.Api.Acceptance.Tests.Config;
using Pt.Api.Acceptance.Tests.Drivers;
using RestSharp;
using TechTalk.SpecFlow;

namespace Pt.Api.Acceptance.Tests.Hooks
{
    [Binding]
    public class Hooks
    {
        [BeforeScenario(Order = 10)]
        public void ConfigureDependencyInjection(IObjectContainer objectContainer)
        {
            // Configuration
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine("appsettings.json"), true, true)
                .AddEnvironmentVariables("TEST_PT_API_")
                .Build();

            objectContainer.RegisterInstanceAs(config);
            
            // API Config
            var apiConfig = new ApiConfig();
            config.Bind("api", apiConfig);
            objectContainer.RegisterInstanceAs(apiConfig);

            // 3rd party
            var restClient = new RestClient(apiConfig.Uri);
            objectContainer.RegisterInstanceAs<IRestClient>(restClient);

            // Projects API Driver
            objectContainer.RegisterTypeAs<ProjectsApiDriver, IProjectsApiDriver>();
        }
    }
}
