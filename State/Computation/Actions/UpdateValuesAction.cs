using OnlineCalculator.Model;

namespace OnlineCalculator.State.Computation.Actions;

public class UpdateValuesAction
{
    public List<ScreenContentModel> ScreenContentModels { get; }

    public UpdateValuesAction(List<ScreenContentModel> screenContentModels, ScreenContentModel screenContentModel)
    {
        screenContentModels.Add(screenContentModel);
        
        ScreenContentModels = screenContentModels;
        
    }
}