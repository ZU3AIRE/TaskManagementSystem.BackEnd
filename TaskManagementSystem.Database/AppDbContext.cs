using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Database.Entities;
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
        public DbSet<FileSaving> FileSavings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskStatus>().HasData(
                new TaskStatus { TaskStatusID = 1, Status = "Pending", IsActive = true },
                new TaskStatus { TaskStatusID = 2, Status = "Development", IsActive = true },
                new TaskStatus { TaskStatusID = 3, Status = "Closed", IsActive = true }
            );

            // Seeding Developers 
            modelBuilder.Entity<Developer>().HasData(
                new Developer { DeveloperId = 1, Name = "Zubair Jamil", Email = "zubair@gmail.com", Password = "123", IsActive = true },
                new Developer { DeveloperId = 2, Name = "Gullzaib Khan", Email = "gullzaib@yahoo.com", Password = "123", IsActive = true },
                new Developer { DeveloperId = 3, Name = "Usama Akram", Email = "usama@bing.com", Password = "123", IsActive = true }

            );
       

            base.OnModelCreating(modelBuilder);
        }

    }
}
