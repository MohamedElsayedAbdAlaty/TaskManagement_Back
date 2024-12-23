using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class TaskSearchDto
    {
        public string? Name { get; set; }
        public int? Status { get; set; } // "New", "In Progress", "Completed"
        public int? Priority { get; set; } // "High", "Medium", "Low"
    }
    public enum PriorityLevel
    {
        High,
        Medium,
        Low
    }
}
