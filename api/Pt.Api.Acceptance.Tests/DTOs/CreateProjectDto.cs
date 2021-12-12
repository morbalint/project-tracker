using System;

namespace Pt.Api.Acceptance.Tests.DTOs
{
    public class CreateProjectDto
    {
        public string Name { get; set; } = string.Empty;
        
        public string? Notes { get; set; }
        
        public DateTimeOffset? StartTime { get; set; } 
    }
}