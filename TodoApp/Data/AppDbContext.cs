using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<TodoItem> TodoItems { get; set; }  // Adjust if named differently

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<TodoItem>(entity =>
        {
            entity.HasKey(e => e.Id);  // Explicit PK
                entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd();  // Tells EF: Auto-generate on insert
                entity.Property(e => e.IsCompleted)
                  .HasColumnType("boolean");  // Native bool
                entity.Property(e => e.Title)
                  .HasMaxLength(200)
                  .IsRequired(false);  // Adjust as needed
            });
    }
}