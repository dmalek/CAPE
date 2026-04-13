namespace CAPE.Context.Models;

public class TodoItem
{
    public int ItemId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public string Status { get; set; } = string.Empty;

    // Navigation property
    public ICollection<ItemHistory> History { get; set; } = new List<ItemHistory>();
}
