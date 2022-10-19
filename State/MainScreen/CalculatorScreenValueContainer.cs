using Fluxor;

namespace OnlineCalculator.State.MainScreen;

[FeatureState]
public class CalculatorScreenValueContainer
{
    
    private string? ScreenValue;
    
    public string Property
    {
        get => ScreenValue ?? string.Empty;
        set
        {
            ScreenValue += value;
            NotifyStateChanged();
        }
    }

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}