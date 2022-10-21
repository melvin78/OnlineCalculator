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

    public static decimal GetAnswer(this string screenValue,decimal finalResult)
    {
     

        string defaultPattern = @"([+-]?\d*\.?\d+)+([-+⨉*÷x²])+([+-]?\d+\.?\d*)";

        var cc = screenValue.Length;

        var tt = Validator.IsPrime(screenValue.Length);

        var yui = tt;
        
         var finalScreenValue = string.Empty;

         switch (screenValue.Length)
         {
             case > 3 :
             {
                 var x = screenValue[^1];
                 var z = screenValue[^2];
                 var p = x.ToString();
                 var y = z.ToString();

                 if (screenValue.Length % 2 > 0)
                 {
                     finalScreenValue = $"{finalResult.ToString()}{screenValue[^2]}{screenValue[^1]}";
                     
                     foreach (Match m in Regex.Matches(finalScreenValue, defaultPattern))
                     {
                         if (m.Groups[1].Success && m.Groups[2].Success && m.Groups[3].Success)
                         {
                             decimal value1 = decimal.Parse(m.Groups[1].Value);
                             decimal value2 = decimal.Parse(m.Groups[3].Value);
                             switch (m.Groups[2].Value)
                             {
                                 case "⨉":
                                     finalResult = PerformMultiplication(value1, value2);
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
                   
                     }


                 }
                 
                 
             
              
                 break;
             }
             case 3 :
             {
                 foreach (Match m in Regex.Matches(screenValue, defaultPattern))
                 {
                     decimal value1 = decimal.Parse(m.Groups[1].Value);
                     decimal value2 = decimal.Parse(m.Groups[3].Value);
                     switch (m.Groups[2].Value)
                     {
                         case "⨉":
                             finalResult = PerformMultiplication(value1, value2);
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

                 break;
             }
         }


         return finalResult;




    }
}