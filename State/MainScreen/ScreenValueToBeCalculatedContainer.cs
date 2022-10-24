namespace OnlineCalculator.State.MainScreen;

public class ScreenValueToBeCalculatedContainer
{
    private string? ScreenValueToBeCalculated;
    
    public string? Property
    {
        get => ScreenValueToBeCalculated ?? string.Empty;
        set
        {
            ScreenValueToBeCalculated = value;
            NotifyStateChanged();
        }
    }

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}