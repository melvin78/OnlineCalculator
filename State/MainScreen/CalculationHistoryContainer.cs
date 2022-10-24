namespace OnlineCalculator.State.MainScreen;

public class CalculationHistoryContainer
{
    public List<decimal> Property { get; } = new();


    public event Action? OnAddNewItem; 
    

    private void NotifyItemAdded() => OnAddNewItem?.Invoke();
}