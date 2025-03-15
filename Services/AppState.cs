namespace E6Ko.Services;

public class AppState
{
    public bool IsLoggedIn { get; set; } = true; // Manual override for testing
    public event Action? OnChange;

    public void SetLoginState(bool isLoggedIn)
    {
        IsLoggedIn = isLoggedIn;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}