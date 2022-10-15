using System.ComponentModel;

namespace OnlineCalculator.Constants;

public enum CalculatorComponents
{
    [Description("+")]
    Addition,
    [Description("-")]
    Subtraction,
    [Description("⨉")]
    Multiplication,
    [Description("÷")]
    Division,
    [Description("C")]
    Clear,
    [Description("=")]
    Equal,
    [Description(".")]
    DecimalPoint,
    [Description("√")]
    SquareRoot,
    [Description("x²")]
    Exponential,
    [Description("7")]
    Seven,
    [Description("8")]
    Eight,
    [Description("9")]
    Nine,
    [Description("4")]
    Four,
    [Description("5")]
    Five,
    [Description("6")]
    Six,
    [Description("1")]
    One,
    [Description("2")]
    Two,
    [Description("3")]
    Three,
    [Description("0")]
    Zero,

}

public enum RoundPlaces
{
    Default = 5
}