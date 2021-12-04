using System;
using System.Threading.Tasks;
using FluentAssertions;
using NodaTime;
using ProjectTracker.Api.Services;
using Xunit;
using NodaTime.Testing;
using ProjectTracker.Api.DTOs;

namespace ProjectTracker.Api.Unit.Test;

public class ProjectServiceTests
{
    private readonly FakeClock _clock = FakeClock.FromUtc(2021, 12, 3);
    private readonly IProjectsService _sut;

    public ProjectServiceTests()
    {
        _sut = new ProjectsService(_clock);
    }

    [Fact]
    public async Task GetAllProjects_NoProjects_ReturnEmpty()
    {
        // Act
        var projects = await _sut.GetAll();
        
        // Assert
        projects.Should().BeEmpty();
    }
    
    [Fact]
    public async Task AddProject_NoProjects_ReturnNewGuid()
    {
        // Arrange
        var projectToAdd = new ProjectCreationDto()
        {
            Name = "ProjectTracerApp",
            StartTime = Instant.FromUtc(2021, 12, 3, 19, 0, 0),
        };
        
        // Act
        var id = await _sut.AddNew(projectToAdd);
        
        // Assert
        id.Should().NotBe(Guid.Empty);
    }
    
    [Fact]
    public async Task AddProject_Twice_ReturnsDifferentGuids()
    {
        // Arrange
        var projectToAdd = new ProjectCreationDto()
        {
            Name = "ProjectTracerApp",
            StartTime = Instant.FromUtc(2021, 12, 3, 19, 0, 0),
        };
        
        // Act
        var id1 = await _sut.AddNew(projectToAdd);
        var id2 = await _sut.AddNew(projectToAdd);
        
        // Assert
        id1.Should().NotBe(id2);
    }
}
