namespace E6Ko.Models;

public class Note
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public int? FolderId { get; set; } // Nullable to allow notes without a folder
    public bool IsEmpty => string.IsNullOrWhiteSpace(Text);
}