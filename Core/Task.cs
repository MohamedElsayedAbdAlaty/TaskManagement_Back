namespace Core
{
   
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Assignee { get; set; }
        public TaskStatus? Status { get; set; } 
        public DateTime? DueDate { get; set; }
        public PriorityLevel? Priority { get; set; }
    }
    public enum TaskStatus
    {
        ToDo,
        InProgress,
        Completed
       
    }
}
