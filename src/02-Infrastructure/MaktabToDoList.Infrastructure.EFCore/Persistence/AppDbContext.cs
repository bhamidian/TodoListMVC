using MaktabToDoList.Domain.Core.Task.Entities;
using MaktabToDoList.Domain.Core.User.Entities;
using MaktabToDoList.Infrastructure.EFCore.Configurations;
using Microsoft.EntityFrameworkCore;

namespace MaktabToDoList.Infrastructure.EFCore.Persistence
{
    public class AppDbContext : DbContext
    {

        public DbSet<NormalUser> NormalUsers { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<TaskHistory> TaskHistories { get; set; }
        public DbSet<TaskComment> TaskComments { get; set; }
        public DbSet<TaskCategory> Categories { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ToDoListDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NormalUserConfigurations());
            modelBuilder.ApplyConfiguration(new TaskItemConfigurations());
            modelBuilder.ApplyConfiguration(new TaskCategoryConfigurations());
        }

    }
}
