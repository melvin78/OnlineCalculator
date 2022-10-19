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

    public static decimal GetAnswer(this string screenValue)
    {
        decimal finalResult = 0;

        string defaultPattern = @"([+-]?\d*\.?\d+)+([-+⨉*÷x²])+([+-]?\d+\.?\d*)";
        

         string expressions = "9⨉9";
         string expressiosns = "21.90222⨉-7.122";
         string[] symbols = new[] {"+", "-","⨉", "÷", "√", "x²"};

        
         

        foreach (System.Text.RegularExpressions.Match m in System.Text.RegularExpressions.Regex.Matches(screenValue, defaultPattern))
            {
                decimal value1 = decimal.Parse(m.Groups[1].Value);
                decimal value2 = decimal.Parse(m.Groups[3].Value);
                switch (m.Groups[2].Value)
                {
                    case "⨉":
                        if (screenValue.Length ==  3)
                        {
                            finalResult = PerformMultiplication(value1, value2);
                        }

                        if (screenValue.Length > 3)
                        {
                            finalResult = finalResult.PerformMultiplication(decimal.Parse(screenValue.Split("X").Last()));
                        }
                       
                        break;
                    case "+":
                        finalResult = PerformAddition(value1, value2);
                        break;
                    case "*":
                        Console.WriteLine("{0} = {1}", m.Value, value1 * value2);
                        break;
                    case "/":
                        Console.WriteLine("{0} = {1:N2}", m.Value, value1 / value2);
                        break;
                }
            }
       

        

        return finalResult;




    }
}