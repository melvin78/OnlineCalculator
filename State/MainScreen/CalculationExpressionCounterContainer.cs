namespace OnlineCalculator.State.MainScreen;

public class CalculationExpressionCounterContainer
{
    private int CalculationExpressionCounter;
    
    public int Property
    {
        get => CalculationExpressionCounter;
        set
        {
            CalculationExpressionCounter = value;
            NotifyStateChanged();
        }
    }

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}