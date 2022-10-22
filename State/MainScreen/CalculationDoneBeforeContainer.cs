namespace OnlineCalculator.State.MainScreen;

public class CalculationDoneBeforeContainer
{
    private bool? IsDoneBefore;
    
    public bool Property
    {
        get => IsDoneBefore ?? false;
        set
        {
            IsDoneBefore = value;
            NotifyStateChanged();
        }
    }

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}