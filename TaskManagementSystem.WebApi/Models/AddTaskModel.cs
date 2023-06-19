namespace TaskManagementSystem.WebApi.Models
{
    public class AddTaskModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public bool IsActive { get; set; }

    }
}
