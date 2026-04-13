using CAPE.Context;
using CAPE.Context.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CAPE.Tests.Context;

public class AppDbContextTests
{
    private AppDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public void TodoItem_CanBeCreatedWithValidProperties()
    {
        // Arrange
        var todoItem = new TodoItem
        {
            ItemId = 1,
            Title = "Test Task",
            Description = "Test Description",
            UserEmail = "user@example.com",
            DueDate = DateTime.Now.AddDays(1),
            Status = "Pending"
        };

        // Assert
        Assert.Equal(1, todoItem.ItemId);
        Assert.Equal("Test Task", todoItem.Title);
        Assert.Equal("Test Description", todoItem.Description);
        Assert.Equal("user@example.com", todoItem.UserEmail);
        Assert.Equal("Pending", todoItem.Status);
    }

    [Fact]
    public void ItemHistory_CanBeCreatedWithValidProperties()
    {
        // Arrange
        var history = new ItemHistory
        {
            HistoryId = 1,
            ItemId = 1,
            Action = "Created",
            Timestamp = DateTime.Now
        };

        // Assert
        Assert.Equal(1, history.HistoryId);
        Assert.Equal(1, history.ItemId);
        Assert.Equal("Created", history.Action);
    }

    [Fact]
    public async Task CanAddTodoItemToDatabase()
    {
        // Arrange
        using (var context = CreateDbContext())
        {
            var todoItem = new TodoItem
            {
                Title = "Test Task",
                Description = "Test Description",
                UserEmail = "user@example.com",
                DueDate = DateTime.Now.AddDays(1),
                Status = "Pending"
            };

            // Act
            context.TodoItems.Add(todoItem);
            await context.SaveChangesAsync();

            // Assert
            var result = await context.TodoItems.FirstOrDefaultAsync(t => t.Title == "Test Task");
            Assert.NotNull(result);
            Assert.Equal("Test Task", result.Title);
        }
    }

    [Fact]
    public async Task CanAddItemHistoryToDatabase()
    {
        // Arrange
        using (var context = CreateDbContext())
        {
            var todoItem = new TodoItem
            {
                Title = "Test Task",
                Description = "Test Description",
                UserEmail = "user@example.com",
                DueDate = DateTime.Now.AddDays(1),
                Status = "Pending"
            };

            context.TodoItems.Add(todoItem);
            await context.SaveChangesAsync();

            var history = new ItemHistory
            {
                ItemId = todoItem.ItemId,
                Action = "Created",
                Timestamp = DateTime.Now
            };

            // Act
            context.ItemHistories.Add(history);
            await context.SaveChangesAsync();

            // Assert
            var result = await context.ItemHistories.FirstOrDefaultAsync(h => h.Action == "Created");
            Assert.NotNull(result);
            Assert.Equal("Created", result.Action);
            Assert.Equal(todoItem.ItemId, result.ItemId);
        }
    }

    [Fact]
    public async Task TodoItemAndItemHistoryRelationshipWorks()
    {
        // Arrange
        using (var context = CreateDbContext())
        {
            var todoItem = new TodoItem
            {
                Title = "Test Task",
                Description = "Test Description",
                UserEmail = "user@example.com",
                DueDate = DateTime.Now.AddDays(1),
                Status = "Pending"
            };

            context.TodoItems.Add(todoItem);
            await context.SaveChangesAsync();

            var history1 = new ItemHistory
            {
                ItemId = todoItem.ItemId,
                Action = "Created",
                Timestamp = DateTime.Now
            };

            var history2 = new ItemHistory
            {
                ItemId = todoItem.ItemId,
                Action = "Updated",
                Timestamp = DateTime.Now.AddHours(1)
            };

            context.ItemHistories.Add(history1);
            context.ItemHistories.Add(history2);
            await context.SaveChangesAsync();

            // Act
            var retrievedItem = await context.TodoItems
                .Include(t => t.History)
                .FirstOrDefaultAsync(t => t.ItemId == todoItem.ItemId);

            // Assert
            Assert.NotNull(retrievedItem);
            Assert.Equal(2, retrievedItem.History.Count);
            Assert.Contains(retrievedItem.History, h => h.Action == "Created");
            Assert.Contains(retrievedItem.History, h => h.Action == "Updated");
        }
    }
}
