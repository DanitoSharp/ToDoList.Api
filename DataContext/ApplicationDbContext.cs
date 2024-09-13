using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoList.Api.Models;

namespace ToDoList.Api.DataContext;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<ToDoModel> Todos => Set<ToDoModel>();
    public DbSet<Priority> Priority => Set<Priority>();
    public DbSet<Status> Status => Set<Status>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ToDoModel>().HasOne(t => t.User) // Navigation property
            .WithMany()                               // One user can have many todo items
            .HasForeignKey(t => t.UserId)             // Foreign key
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Priority>().HasData(
            new Priority{
                Id = 1,
                Name = "Low"
            },
            new Priority{
                Id = 2,
                Name = "Medium"
            },
            new Priority{
                Id = 3,
                Name = "High"
            },
            new Priority{
                Id = 4,
                Name = "Critical"
            },
            new Priority{
                Id = 5,
                Name = "Urgent"
            },
            new Priority{
                Id = 6,
                Name = "Deferred"
            }
        );
        modelBuilder.Entity<Status>().HasData(
            new Status{
                Id = 1,
                Name = "Not Started"
            },
            new Status{
                Id = 2,
                Name = "In Progress"
            },
            new Status{
                Id = 3,
                Name = "Completed"
            },
            new Status{
                Id = 4,
                Name = "Paused"
            },
            new Status{
                Id = 5,
                Name = "Waiting for Feedback"
            },
            new Status{
                Id = 6,
                Name = "Blocked"
            }
        );

    }

}
