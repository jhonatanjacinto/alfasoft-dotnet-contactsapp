using Alfasoft.ContactManager.Models;
using Microsoft.EntityFrameworkCore;

namespace Alfasoft.ContactManager.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options, IWebHostEnvironment env) : DbContext(options)
{
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<User> Users { get; set; }

    // Configuration for logging and detailed errors only in development environment
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (env.IsDevelopment())
        {
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasIndex(e => e.Email).IsUnique();
            entity.HasIndex(e => e.Phone).IsUnique();
            entity.Property(e => e.Status).HasConversion(
                status => status.ToString(), 
                value => Enum.Parse<Enums.ContactStatus>(value));
            
            // Seed some sample contacts
            entity.HasData(new List<Contact>
            {
                new() { Id = 1, Name = "John Doe", Email = "johndoe@gmail.com", Phone = "123456789", Status = Enums.ContactStatus.Active },
                new() { Id = 2, Name = "Jane Smith", Email = "janesmith@gmail.com", Phone = "333666444", Status = Enums.ContactStatus.Active },
                new() { Id = 3, Name = "Alice Johnson", Email = "alicejohnson@outlook.com", Phone = "111555777", Status = Enums.ContactStatus.Active }
            });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Username).IsUnique();
            const string passwordHash = "$2a$11$DVqwQNn1c.Ve.P9VQ/gmUeY3Xk9sKlb80KfZllr.q.XTW/DFkJFm2";
            entity.HasData(new List<User>
            {
                new() { Id = 1, Name = "Super Admin User", Username = "admin", PasswordHash = passwordHash } // password: admin
            });
        });
    }
}