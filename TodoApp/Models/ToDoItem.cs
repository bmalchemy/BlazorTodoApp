using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models;

public class TodoItem
{
    [Key]
    public int Id { get; set; }  // EF Core will auto-generate this as identity in PostgreSQL

    public string? Title { get; set; }  // Or string Title { get; set; } if non-nullable

    public bool IsCompleted { get; set; }  // bool maps to boolean natively
}