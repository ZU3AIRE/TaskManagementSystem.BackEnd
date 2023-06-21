namespace TaskManagementSystem.Data.Entities
{
    public class TaskStatus
    {
        public int TaskStatusID { get; set; }
        public string Status { get; set; } = string.Empty;

        public bool IsActive { get; set; }

    }
}
