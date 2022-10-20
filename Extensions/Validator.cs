namespace OnlineCalculator.Extensions;

public static class Validator
{
    public static bool IsPrime(int number)
    {
        if (number < 2) return false;
        
        if (number % 2 == 0) return (number == 2);
        
        var root = (int)Math.Sqrt(number);
        
        for (var i = 3; i <= root; i += 2)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
}