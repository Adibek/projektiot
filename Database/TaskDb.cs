using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Database.Entities;

namespace TaskManager.Database
{
    public class TaskDb: DbContext
    {
        public TaskDb(DbContextOptions<TaskDb> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           ConfigureTaskEntity(modelBuilder.Entity<TaskEntity>());
        }

        private void ConfigureTaskEntity(EntityTypeBuilder<TaskEntity> entity)
        {
            entity.ToTable("Task");
            entity.Property(p => p.AdminName).IsRequired().HasMaxLength(200);
            entity.Property(p => p.Name).IsRequired().HasMaxLength(200);
            entity.Property(p => p.Task).IsRequired().HasMaxLength(200);
            entity.Property(p => p.TaskDesc).IsRequired().HasMaxLength(400);
            entity.Property(p => p.Status).IsRequired();
        }

        public DbSet<TaskEntity> Tasks{get;set;}
    }


}