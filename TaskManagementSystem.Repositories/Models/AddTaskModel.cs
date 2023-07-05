namespace TaskManagementSystem.Repositories.Models
{
    public class AddTaskModel
    {
        public int TaskId { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

    }
}
