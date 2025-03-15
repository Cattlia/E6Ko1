namespace E6Ko.Models;

public class Folder
{
    public int Id { get; set; }
    public string? Content { get; set; } // Folder name or description
    public bool IsEmpty => string.IsNullOrWhiteSpace(Content);
}