using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.WebApi.Database.Entities;
using Task = TaskManagementSystem.WebApi.Database.Entities.Task;
using TaskStatus = TaskManagementSystem.WebApi.Database.Entities.TaskStatus;

namespace TaskManagementSystem.WebApi.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions Options) : base(Options) { }


        // DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskStatus> TaskStatuses { get; set; }
    }
}
