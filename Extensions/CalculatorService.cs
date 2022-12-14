using System.Globalization;
using System.Text.RegularExpressions;
using OnlineCalculator.Constants;
using OnlineCalculator.Model;

namespace OnlineCalculator.Extensions;

public static class CalculatorService
{
    public static decimal PerformAddition(decimal valueOne, decimal valueTwo)
    {
        return Math.Round(valueOne + valueTwo, (int) RoundPlaces.Default);
    }

    public static decimal PerformSubtraction(this decimal valueOne, decimal valueTwo)
    {
        return Math.Round(valueOne - valueTwo, (int) RoundPlaces.Default);
    }

    public static decimal PerformMultiplication(this decimal valueOne, decimal valueTwo)
    {
        return Math.Round(valueOne * valueTwo, (int) RoundPlaces.Default);
    }

    public static decimal PerformDivision(this decimal valueOne, decimal valueTwo)
    {
        return Math.Round(valueOne / valueTwo, (int) RoundPlaces.Default);
    }

    public static decimal PerformSquareRoot(this decimal valueOne)
    {
        return (decimal) Math.Round(Math.Sqrt((double) valueOne), (int) RoundPlaces.Default);
    }

    public static decimal PerformExponential(this decimal valueOne)
    {
        return (decimal) Math.Round(Math.Pow((double) valueOne, 2), (int) RoundPlaces.Default);
    }

    public static ScreenContentModel GetAnswer(this string screenValue)
    {
        decimal? finalResult = null;

        string defaultPattern = @"^([+-]?\d*\.?\d+)+([-+⨉*÷x²][-]?)+([+-]?\d+\.?\d*)$";

        var symbol = string.Empty;

        foreach (Match m in Regex.Matches(screenValue, defaultPattern))
        {

            var answerShouldBeNegative = m.Groups[2].Value.Contains('-') && m.Groups[2].Value.EndsWith('-');
            
            if (!m.Groups[1].Success || !m.Groups[2].Success || !m.Groups[3].Success)
                continue;

            var value1 = decimal.Parse(m.Groups[1].Value,NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
            var value2 = decimal.Parse(m.Groups[3].Value,NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
            symbol = answerShouldBeNegative ? m.Groups[2].Value.First().ToString() : m.Groups[2].Value.Last().ToString();
            
            finalResult = symbol switch 
            {
                "⨉" => PerformMultiplication(value1, value2),
                "+" => PerformAddition(value1, value2),
                "÷" => PerformDivision(value1, value2),
                "-" => PerformSubtraction(value1, value2),
                _ => finalResult
            };

            if (answerShouldBeNegative)
            {
                finalResult *= -1;
            }
        }

       
        
        return new ScreenContentModel()
        {
            Value = finalResult,
            ValidExpression = true,
            UpdateCalculationHistory = true
        };
    }


    public static ScreenContentModel GetSuccessiveAnswers(this string screenValue, decimal screenResult, List<decimal> successiveResults)
    {
        string secondaryPattern = @".*([-+⨉*÷x²])+([+-]?\d+\.?\d*).*";

        string defaultPattern = @"^([+-]?\d*\.?\d+)+([-+⨉*÷x²])+([+-]?\d+\.?\d*)$";
        
        decimal finalResult = 0;

        string[] operators = {"-", "+", "⨉", "÷"};

        foreach (Match m in Regex.Matches(screenValue, defaultPattern))
        {
            if (!m.Groups[1].Success || !m.Groups[2].Success || !m.Groups[3].Success) continue;

            var value1 = decimal.Parse(m.Groups[1].Value,NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
            var value2 = decimal.Parse(m.Groups[3].Value,NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);

            finalResult = m.Groups[2].Value switch
            {
                "⨉" => PerformMultiplication(value1, value2),
                "+" => PerformAddition(value1, value2),
                "÷" => PerformDivision(value1, value2),
                "-" => PerformSubtraction(value1, value2),
                _ => finalResult
            };

            return new ScreenContentModel()
            {
                ValidExpression = true,
                UpdateCalculationHistory = true,
                Value = finalResult,
            };
        }

        if (operators.Any(screenValue.EndsWith))
            return new ScreenContentModel()
            {
                Value = screenResult,
                ValidExpression = false,
                UpdateCalculationHistory = true,
            };
        {
            foreach (Match m in Regex.Matches(screenValue, secondaryPattern))
            {
                if (!m.Groups[1].Success || !m.Groups[2].Success)
                    continue;

                var value = decimal.Parse(m.Groups[2].Value,NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);

                var lastResult = successiveResults.Last();

                finalResult = m.Groups[1].Value switch
                {
                    "⨉" => PerformMultiplication(lastResult, value),
                    "+" => PerformAddition(lastResult, value),
                    "÷" => PerformDivision(lastResult, value),
                    "-" => PerformSubtraction(lastResult, value),
                    _ => finalResult
                };
            }
        }


        return new ScreenContentModel()
        {
            Value = finalResult,
            ValidExpression = true,
            UpdateCalculationHistory = false,
        };
    }
}