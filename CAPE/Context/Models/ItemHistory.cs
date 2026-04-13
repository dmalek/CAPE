namespace CAPE.Context.Models;

public class ItemHistory
{
    public int HistoryId { get; set; }
    public int ItemId { get; set; }
    public string Action { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }

    // Navigation property
    public TodoItem? TodoItem { get; set; }
}
