using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Linq;
using TodoApp.Data;
using Microsoft.EntityFrameworkCore;
using TodoApp.Models;
using TodoApp.Components.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Forms;
using Xunit;

public class HomeTests : TestContext
{
    [Fact]
    public async void AddTodo_SubmitsFormAndUpdatesList()
    {
        // Arrange: Use EF In-Memory DB for simple async mocking (no Moq needed)
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestTodoDb")  // Unique name per test (avoids conflicts)
            .Options;

        using var context = new AppDbContext(options);  // Real DbContext with fake DB
        Services.AddScoped<AppDbContext>(sp => context);  // Register for DI

        // Pre-populate if desired (optional)
        context.TodoItems.Add(new TodoItem { Id = 1, Title = "Existing Todo", IsCompleted = false });
        await context.SaveChangesAsync();  // "Saves" to in-memory

        // Act
        var cut = RenderComponent<Home>();  // Auto-waits for OnInitializedAsync

        var inputElement = cut.Find("input");
        inputElement.Change(new ChangeEventArgs { Value = "Test Todo" });

        var button = cut.Find("button[type=submit]");
        button.Click();

        // Wait for post-submit refresh (short timeout)
        cut.WaitForState(() => cut.Instance.todos.Count == 2, TimeSpan.FromSeconds(1));  // 1 initial + 1 new

        // Assert
        Assert.Equal(2, cut.Instance.todos.Count);
        Assert.Equal("Test Todo", cut.Instance.todos[1].Title);
    }

}