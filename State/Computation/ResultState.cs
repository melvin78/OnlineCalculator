using Fluxor;
using OnlineCalculator.Model;

namespace OnlineCalculator.State.Computation;

[FeatureState]
public class ResultState
{
    public List<ScreenContentModel>? RScreenContentModels { get; } = new ();


    public ResultState()
    {
        
    }

    public ResultState(List<ScreenContentModel>? screenContentModels)
    {

        RScreenContentModels = screenContentModels;
    }
}