namespace TaskManagementSystem.WebApi.Models
{
    public class TaskStatusModel
    {
        public int TaskStatusID { get; set; }
        public string Status { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
