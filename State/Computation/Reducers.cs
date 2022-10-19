using Fluxor;
using OnlineCalculator.State.Computation.Actions;

namespace OnlineCalculator.State.Computation;

[ReducerMethod]
public static class Reducers
{
    [ReducerMethod]
    public static ResultState AddNewValue(ResultState toDoState, AddValuesAction addValuesAction) =>
        new(screenContentModels: addValuesAction.ScreenContent);
}