namespace TaskManagementSystem.Database.Entities
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;


        // Navigation Property for making one-to-one relationship
        public TaskStatus Status { get; set; }
        public bool IsActive { get; set; } = true;
        // Navigation Property for making one-to-many relationship
        //public Developer Developers { get; set; }
    }
}
