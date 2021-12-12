using System;

namespace Pt.Api.Acceptance.Tests.DTOs
{
    public class ProjectSummaryDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; } = string.Empty;
        
        public uint TotalDaysWorkedOn { get; set; }
        
        public uint TotalHoursWorkedOn { get; set; }
        
        public DateTimeOffset StartTime { get; set; }
    }
}