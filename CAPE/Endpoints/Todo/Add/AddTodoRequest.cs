using System.ComponentModel.DataAnnotations;

namespace CAPE.Endpoints.Todo.Add;

public sealed class AddTodoRequest
{
    [Required]
    public string? Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    [Required]
    public string? UserEmail { get; set; } = null!;

    public DateTime? DueDate { get; set; } = null;

    [Required]
    public string Status { get; set; } = "BACKLOG";
}
