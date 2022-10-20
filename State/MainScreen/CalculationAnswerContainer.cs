namespace OnlineCalculator.State.MainScreen;

public class CalculationAnswerContainer
{
    private string? Answer;
    
    public string? Property
    {
        get => Answer ?? string.Empty;
        set
        {
            Answer = value;
            NotifyStateChanged();
        }
    }

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}