using System;

class Program
{
    static void Main(string[] args)
    {
        Fractions fraction1 = new Fractions();
        Console.WriteLine($"The default fraction is {fraction1.GetFractionString()}");
        Console.WriteLine($"The decimal value is {fraction1.GetDecimalValue()}");

        Fractions fraction2 = new Fractions(5);
        Console.WriteLine($"The fraction with whole number is {fraction2.GetFractionString()}");
        Console.WriteLine($"The decimal value is {fraction2.GetDecimalValue()}");

        Fractions fraction3 = new Fractions(3, 4);
        Console.WriteLine($"The fraction with top and bottom is {fraction3.GetFractionString()}");
        Console.WriteLine($"The decimal value is {fraction3.GetDecimalValue()}");

        
        Fractions fraction4 = new Fractions(1, 3);
        Console.WriteLine($"The fraction with top and bottom is {fraction4.GetFractionString()}");
        Console.WriteLine($"The decimal value is {fraction4.GetDecimalValue()}");
    }
}