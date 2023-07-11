namespace TaskManagementSystem.WebApi.Database.Entities
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        // Navigation Property for making one-to-one relationship
        public TaskStatus Status { get; set; }
        public List<Developer> Developers { get; set; } // List of developers assigned to the task

        // public int? AssignDeveloper { get; set; } 



    }
}
