using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Testing Constructors ---");

        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());
        
        Console.WriteLine("\n--- Testing Getters and Setters ---");
        
        Fraction f5 = new Fraction(2, 5);
        Console.WriteLine($"Initial fraction: {f5.GetFractionString()}");

        f5.SetTop(4);
        f5.SetBottom(7);

        int newTop = f5.GetTop();
        int newBottom = f5.GetBottom();
        Console.WriteLine($"New fraction from getters: {newTop}/{newBottom}");
        Console.WriteLine($"New decimal value: {f5.GetDecimalValue()}");
    }
}
