using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Data.Entities;
using Task = TaskManagementSystem.Data.Entities.Task;
using TaskStatus = TaskManagementSystem.Data.Entities.TaskStatus;

namespace TaskManagementSystem.Data
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
