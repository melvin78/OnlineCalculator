using OnlineCalculator.Model;

namespace OnlineCalculator.State.Computation.Actions;

public class AddValuesAction
{
    public List<ScreenContentModel>? ScreenContent { get; }

    public AddValuesAction(List<ScreenContentModel>? screenContentModels)
    {
        ScreenContent = screenContentModels;
    }
}