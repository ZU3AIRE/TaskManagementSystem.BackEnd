﻿namespace TaskManagementSystem.WebApi.Database.Entities
{
    public class Developer
    {
        public int DeveloperId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;


        // Navigation Property for one-to-many
        public List<Task> Tasks { get; set; } = new List<Task>();
    }   
}
