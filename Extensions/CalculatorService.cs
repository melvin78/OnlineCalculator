using System.Text.RegularExpressions;
using OnlineCalculator.Constants;

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

    public static decimal? GetAnswer(this string screenValue)
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

        return finalResult;

    }


    public static decimal GetSuccessiveAnswers(this string screenValue, decimal screenResult)
    {
        string secondaryPattern = @".*([-+⨉*÷x²])+([+-]?\d+\.?\d*).*";
        
        decimal finalResult = 0;

        string[] operators =  {"-","+","⨉","÷" };
        
        if (operators.Any(screenValue.EndsWith))
            return screenResult;
        {
            foreach (Match m in Regex.Matches(screenValue,secondaryPattern))
            {
                if (!m.Groups[1].Success || !m.Groups[2].Success) 
                    continue;
                
                var value = decimal.Parse(m.Groups[2].Value);
                
                finalResult = m.Groups[1].Value switch
                {
                    "⨉" => PerformMultiplication(screenResult, value),
                    "+" => PerformAddition(screenResult, value),
                    "÷" => PerformDivision(screenResult, value),
                    "-" => PerformSubtraction(screenResult, value),
                    _ => finalResult
                };

            }
        }


        return finalResult;
    }
    
}