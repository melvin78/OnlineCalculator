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
     

        string defaultPattern = @"^([+-]?\d*\.?\d+)+([-+⨉*÷x²])+([+-]?\d+\.?\d*)$";

      
         var finalScreenValue = string.Empty;
         
         // finalScreenValue = $"{finalResult.ToString()}{screenValue[^2]}{screenValue[^1]}";
                     
         foreach (Match m in Regex.Matches(screenValue, defaultPattern))
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
                     case "÷":
                         finalResult = PerformDivision(value1, value2);
                         break;
                     case "-":
                         finalResult = PerformSubtraction(value1, value2);
                         break;
                 }
             }
                   
         }

         return finalResult;


         // switch (screenValue.Length)
         // {
         //     case > 3 :
         //     {
         //      
         //        
         //         break;
         //     }
         //     case 3 :
         //     {
         //         foreach (Match m in Regex.Matches(screenValue, defaultPattern))
         //         {
         //             decimal value1 = decimal.Parse(m.Groups[1].Value);
         //             decimal value2 = decimal.Parse(m.Groups[3].Value);
         //             switch (m.Groups[2].Value)
         //             {
         //                 case "⨉":
         //                     finalResult = PerformMultiplication(value1, value2);
         //                     break;
         //                 case "+":
         //                     finalResult = PerformAddition(value1, value2);
         //                     break;
         //                 case "÷":
         //                     finalResult = PerformDivision(value1, value2);
         //                     break;
         //                 case "-":
         //                     finalResult = PerformSubtraction(value1, value2);
         //                     break;
         //             }
         //         }
         //
         //         break;
         //     }
         // }
         //
         //
         // return finalResult;




    }
}