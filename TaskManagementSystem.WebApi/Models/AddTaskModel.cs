﻿namespace TaskManagementSystem.WebApi.Models
{
    public class AddTaskModel
    {
        public int TaskId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
