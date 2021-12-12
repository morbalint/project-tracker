using System;

namespace Pt.Api.Acceptance.Tests.DTOs
{
    public class ProjectDto
    {
        public Guid Id { get; set; } 
        
        public string Name { get; set; } = null!; // Json deserialized, required parameter.
        
        public DateTimeOffset StartTime { get; set; }
        
        public string? Notes { get; set; }
        
        // TODO: Add working days when required.
    }
}