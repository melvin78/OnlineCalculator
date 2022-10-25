using System.Text.RegularExpressions;
using OnlineCalculator.Constants;
using OnlineCalculator.Model;
using OnlineCalculator.State.MainScreen;

namespace OnlineCalculator.Extensions;

public  static class CalculatorService
{

    public static decimal PerformAddition(decimal valueOne, decimal valueTwo)
    {
        return Math.Round(valueOne + valueTwo, (int)RoundPlaces.Default);
    }

    public static decimal PerformSubtraction(this decimal valueOne, decimal valueTwo)
    {
        return Math.Round(valueOne - valueTwo,  (int)RoundPlaces.Default);
    }

    public static decimal PerformMultiplication(this decimal valueOne, decimal valueTwo)
    {
        return Math.Round(valueOne * valueTwo,  (int)RoundPlaces.Default);
    }

    public static decimal PerformDivision(this decimal valueOne, decimal valueTwo)
    {
        return Math.Round(valueOne / valueTwo,  (int)RoundPlaces.Default);
    }

    public static decimal PerformSquareRoot(this decimal valueOne)
    {
        return (decimal)Math.Round(Math.Sqrt((double)valueOne), (int) RoundPlaces.Default);
    }

    public static decimal PerformExponential(this decimal valueOne)
    {
        return (decimal)Math.Round(Math.Pow((double)valueOne,2), (int) RoundPlaces.Default);
    }

    public static ScreenContentModel GetAnswer(this string screenValue)
    {

        decimal? finalResult = null;

        string defaultPattern = @"^([+-]?\d*\.?\d+)+([-+⨉*÷x²])+([+-]?\d+\.?\d*)$";
        
        foreach (Match m in Regex.Matches(screenValue, defaultPattern))
        {
            if (!m.Groups[1].Success || !m.Groups[2].Success || !m.Groups[3].Success)
                continue;
            
            var value1 = decimal.Parse(m.Groups[1].Value);
            var value2 = decimal.Parse(m.Groups[3].Value);
            
            finalResult = m.Groups[2].Value switch
            {
                "⨉" => PerformMultiplication(value1, value2),
                "+" => PerformAddition(value1, value2),
                "÷" => PerformDivision(value1, value2),
                "-" => PerformSubtraction(value1, value2),
                _ => finalResult
            };

        }

        return new ScreenContentModel()
        {
            Value = finalResult,
            ValidExpression = true,
            UpdateCalculationHistory = true
        };

    }


    public static ScreenContentModel GetSuccessiveAnswers(this string screenValue, decimal screenResult, List<decimal> successiveResults, int expressionCounter)
    {
        string secondaryPattern = @".*([-+⨉*÷x²])+([+-]?\d+\.?\d*).*";
        
        string defaultPattern = @"^([+-]?\d*\.?\d+)+([-+⨉*÷x²])+([+-]?\d+\.?\d*)$";


        decimal finalResult = 0;

        string[] operators =  {"-","+","⨉","÷" };

        foreach (Match m in Regex.Matches(screenValue,defaultPattern))
        {
            if (!m.Groups[1].Success || !m.Groups[2].Success || !m.Groups[3].Success) continue;
            
            var value1 = decimal.Parse(m.Groups[1].Value);
            var value2 = decimal.Parse(m.Groups[3].Value);
            
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
               UpdateCalculationHistory = false,
               
              
            };
        {
            foreach (Match m in Regex.Matches(screenValue,secondaryPattern))
            {
                if (!m.Groups[1].Success || !m.Groups[2].Success) 
                    continue;
                
                
                
                var value = decimal.Parse(m.Groups[2].Value);

                var standInResult = successiveResults[expressionCounter];
                
                
                finalResult = m.Groups[1].Value switch
                {
                    "⨉" => PerformMultiplication(standInResult, value),
                    "+" => PerformAddition(standInResult, value),
                    "÷" => PerformDivision(standInResult, value),
                    "-" => PerformSubtraction(standInResult, value),
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