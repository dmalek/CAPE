using CAPE.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace CAPE.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; }
    public DbSet<ItemHistory> ItemHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure TodoItem
        modelBuilder.Entity<TodoItem>()
            .HasKey(t => t.ItemId);

        modelBuilder.Entity<TodoItem>()
            .Property(t => t.Title)
            .IsRequired();

        modelBuilder.Entity<TodoItem>()
            .Property(t => t.Status)
            .IsRequired();

        // Configure ItemHistory
        modelBuilder.Entity<ItemHistory>()
            .HasKey(h => h.HistoryId);

        modelBuilder.Entity<ItemHistory>()
            .Property(h => h.Action)
            .IsRequired();

        // Configure relationship
        modelBuilder.Entity<ItemHistory>()
            .HasOne(h => h.TodoItem)
            .WithMany(t => t.History)
            .HasForeignKey(h => h.ItemId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
