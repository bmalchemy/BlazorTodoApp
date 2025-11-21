using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models;

public class TodoItem
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    [StringLength(200, ErrorMessage = "Title too long (max 200 chars)")]
    public string? Title { get; set; } = string.Empty;

    public bool IsCompleted { get; set; }
}