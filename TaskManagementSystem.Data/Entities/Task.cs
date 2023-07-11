﻿namespace TaskManagementSystem.Data.Entities
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public bool IsActive { get; set; }


        // Navigation Property for one-to-many
        public List<Developer> DeveloperName { get; set; } = new List<Developer>();
        // Navigation Property for making one-to-one relationship
        public TaskStatus Status { get; set; }
    }
}
