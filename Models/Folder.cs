namespace E6Ko.Models;

public class Folder
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public string? Icon { get; set; } // Added to store the selected Bootstrap Icon class
    public bool IsEmpty => string.IsNullOrWhiteSpace(Content);
}