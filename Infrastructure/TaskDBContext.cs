using Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class TaskDbContext : IdentityDbContext<IdentityUser>
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }
        public DbSet<Core.Task> Tasks { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Core.Task>(entity =>
            {
                entity.HasKey(t => t.Id); // Primary Key
                entity.Property(t => t.Name)
                      .IsRequired()
                      .HasMaxLength(100); // Max length and required
                entity.Property(t => t.Description)
                      .HasMaxLength(500); // Optional, with max length
                entity.Property(t => t.Assignee)
                      .HasMaxLength(50); // Optional field
                entity.Property(t => t.Status);
                      
                entity.Property(t => t.Priority)
                      .HasMaxLength(20)
                      .IsRequired(false); // Optional priority field
                entity.Property(t => t.DueDate)
                      .IsRequired(); // Required field

                // Seed Data
                entity.HasData(
                    new Core.Task
                    {
                        Id = 1,
                        Name = "Setup Project",
                        Description = "Initialize the team task management app",
                        Assignee = "John Doe",
                        Status = Core.TaskStatus.InProgress,
                        Priority = Core.PriorityLevel.High,
                        DueDate = DateTime.UtcNow.AddDays(7)
                    },
                    new Core.Task
                    {
                        Id = 2,
                        Name = "Add Authentication",
                        Description = "Implement user authentication",
                        Assignee = "Jane Smith",
                        Status = Core.TaskStatus.ToDo,
                        Priority =Core.PriorityLevel.Medium,
                        DueDate = DateTime.UtcNow.AddDays(14)
                    }
                );
            });
        }
    }
}
