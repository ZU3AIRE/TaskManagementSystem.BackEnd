using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Database.Entities;
using Task = TaskManagementSystem.Database.Entities.Task;
using TaskStatus = TaskManagementSystem.Database.Entities.TaskStatus;

namespace TaskManagementSystem.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions Options) : base(Options) { }


        // DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskStatus> TaskStatuses { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
    }
}
