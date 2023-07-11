namespace TaskManagementSystem.Data.Entities
{
    public class Developer
    {
        public int DeveloperId { get; set; }
        public string DeveloperName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public bool IsActive { get; set; }


        // Navigation Property for one-to-many
        public List<Task> Tasks { get; set; } = new List<Task>();
    }
}
